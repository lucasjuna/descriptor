using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Descriptor.API.AutofacModules;
using Descriptor.Application;
using Descriptor.Application.Services;
using Descriptor.Infrastructure.Services;
using Descriptor.Persistence.DataContext;
using Hangfire;
using Hangfire.SqlServer;
using IdentityModel.AspNetCore.OAuth2Introspection;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

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

			// Add Hangfire services.
			services.AddHangfire(configuration => configuration
				.SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
				.UseSimpleAssemblyNameTypeSerializer()
				.UseRecommendedSerializerSettings()
				.UseSqlServerStorage(appSettigs.ConnectionString, new SqlServerStorageOptions
				 {
					 PrepareSchemaIfNecessary = true,
					 CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
					 SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
					 QueuePollInterval = TimeSpan.Zero,
					 UseRecommendedIsolationLevel = true,
					 UsePageLocksOnDequeue = true,
					 DisableGlobalLocks = true
				 }));

			// Add the processing server as IHostedService
			services.AddHangfireServer();

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
			services.AddHttpContextAccessor();

			services.AddHttpClient<IEbayTradingService, EbayTradingService>((provider, config) =>
			{
				var appSettings = provider.GetRequiredService<IOptions<AppSettings>>().Value;
				config.BaseAddress = new Uri(appSettings.EbayApiTradingHost);
				config.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
				config.DefaultRequestHeaders.Add("X-EBAY-API-COMPATIBILITY-LEVEL", "967");
				config.DefaultRequestHeaders.Add("X-EBAY-API-SITEID", "0");
			});
			services.AddHttpClient<IEbayFindingService, EbayFindingService>((provider, config) =>
			{
				var appSettings = provider.GetRequiredService<IOptions<AppSettings>>().Value;
				config.BaseAddress = new Uri(appSettings.EbayApiFindingHost);
				config.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
			});

			var container = new ContainerBuilder();
			container.Populate(services);
			container.RegisterModule(new ApplicationModule());
			container.RegisterModule(new MediatrModule());
			return new AutofacServiceProvider(container.Build());
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseCors(builder =>
				{
					builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().AllowCredentials();
				});
			}
			app.UseExceptionHandler(a => a.Run(async context =>
			{
				var feature = context.Features.Get<IExceptionHandlerPathFeature>();
				var exception = feature.Error;

				var result = JsonConvert.SerializeObject(new { message = exception.Message });
				context.Response.ContentType = "application/json";
				await context.Response.WriteAsync(result);
			}));
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
