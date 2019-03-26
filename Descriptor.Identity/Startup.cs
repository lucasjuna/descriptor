using Descriptor.Identity.Data;
using Descriptor.Identity.Model;
using Descriptor.Identity.Services;
using Descriptor.Identity.Validation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;

namespace Descriptor.Identity
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.Configure<AppSettings>(Configuration);
			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

			services.AddDbContext<ApplicationDbContext>((provider, options) =>
			{
				var appSettings = provider.GetRequiredService<IOptions<AppSettings>>().Value;
				options.UseSqlServer(appSettings.ConnectionStringUsers, sqlOptions =>
				{
					sqlOptions.EnableRetryOnFailure(maxRetryCount: 10, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
					sqlOptions.MigrationsAssembly(typeof(SeedUsers).Assembly.FullName);
				});
			}, ServiceLifetime.Scoped);

			services.AddIdentity<ApplicationUser, ApplicationRole>()
				.AddEntityFrameworkStores<ApplicationDbContext>()
				.AddDefaultTokenProviders()
				.AddUserValidator<ApplicationUserValidator>();

			services.AddIdentityServer()

				.AddDeveloperSigningCredential()
				.AddConfigurationStore(config =>
				{
					config.ResolveDbContextOptions = (provider, options) =>
					 {
						 var appSettings = provider.GetRequiredService<IOptions<AppSettings>>().Value;
						 options.UseSqlServer(appSettings.ConnectionStringClients, sqlOptions =>
						 {
							 sqlOptions.EnableRetryOnFailure(maxRetryCount: 10, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
							 sqlOptions.MigrationsAssembly(typeof(SeedClients).Assembly.FullName);
						 });
					 };
				})
				.AddOperationalStore(config =>
				{
					config.ResolveDbContextOptions = (provider, options) =>
					{
						var appSettings = provider.GetRequiredService<IOptions<AppSettings>>().Value;
						options.UseSqlServer(appSettings.ConnectionStringGrants, sqlOptions =>
						{
							sqlOptions.EnableRetryOnFailure(maxRetryCount: 10, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
							sqlOptions.MigrationsAssembly(typeof(SeedClients).Assembly.FullName);
						});
					};
				})
				.AddAspNetIdentity<ApplicationUser>();

			services.AddScoped<IUserClaimsPrincipalFactory<ApplicationUser>, ApplicationUserClaimsPrincipalFactory>();
			services.AddTransient<IEmailSender, EmailSender>();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
			}

			app.UseStaticFiles();
			app.UseIdentityServer();
			app.UseCookiePolicy();

			app.UseMvc(routes =>
			{
				routes.MapRoute(
					name: "default",
					template: "{controller=Home}/{action=Index}/{id?}");
			});
		}
	}
}
