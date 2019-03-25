using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Descriptor.API.AutofacModules;
using Descriptor.Persistence.DataContext;
using IdentityModel.AspNetCore.OAuth2Introspection;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
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
			var appSettigs = new AppSettings();
			Configuration.Bind(appSettigs);
			services.AddMvc(o =>
			{
				o.Filters.Add(new AuthorizeFilter());
			}).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
			services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
				.AddIdentityServerAuthentication(options =>
				{
					options.Authority = appSettigs.IdentityProviderHost;
					options.RequireHttpsMetadata = false;
					options.ApiName = appSettigs.ApiName;
					options.TokenRetriever = new Func<HttpRequest, string>(req =>
					{
						var fromHeader = TokenRetrieval.FromAuthorizationHeader();
						var fromQuery = TokenRetrieval.FromQueryString();
						return fromHeader(req) ?? fromQuery(req);
					});
				});
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
			app.UseAuthentication();
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
