using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Descriptor.API.AutofacModules;
using Descriptor.Persistence.DataContext;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Descriptor.API
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public IServiceProvider ConfigureServices(IServiceCollection services)
		{
			services.Configure<AppSettings>(Configuration);
			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
			services.AddDbContext<DescriptorContext>((provider, options) =>
			{
				var appSettings = provider.GetRequiredService<IOptions<AppSettings>>().Value;
				options.UseSqlServer(appSettings.ConnectionString, sqlOptions =>
				{
					sqlOptions.EnableRetryOnFailure(maxRetryCount: 10, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
					sqlOptions.MigrationsAssembly(typeof(DescriptorContext).Assembly.FullName);
				});
			}, ServiceLifetime.Scoped);
			var container = new ContainerBuilder();
			container.Populate(services);
			container.RegisterModule(new ApplicationModule());
			return new AutofacServiceProvider(container.Build());
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseCors(builder =>
				{
					builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().AllowCredentials();
				});
			}
			app.UseStaticFiles();
			app.UseMvc(routes =>
			{
				routes.MapRoute(
					name: "default",
					template: "{controller=Home}/{action=Index}/{id?}");

				// Catch all Route - catches anything not caught be other routes
				routes.MapRoute(
					name: "catch-all",
					template: "{*url}",
					defaults: new { controller = "Home", action = "Index" }
				);
			});
		}
	}
}
