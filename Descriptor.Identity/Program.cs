using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Descriptor.Identity.Data;
using Descriptor.Identity.Model;
using IdentityServer4.EntityFramework.DbContexts;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Descriptor.Identity
{
	public class Program
	{
		public static async Task Main(string[] args)
		{
			var host = CreateWebHostBuilder(args).Build();
			await InitializeDatabaseAsync(host);
			host.Run();
		}

		public static IWebHostBuilder CreateWebHostBuilder(string[] args)
		{
			return WebHost.CreateDefaultBuilder(args).UseStartup<Startup>();
		}

		private static async Task InitializeDatabaseAsync(IWebHost host)
		{
			using (var scope = host.Services.CreateScope())
			{
				var services = scope.ServiceProvider;
				var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
				var roleManager = services.GetRequiredService<RoleManager<ApplicationRole>>();
				var appContext = services.GetRequiredService<ApplicationDbContext>();
				await SeedUsers.EnsureSeedDataAsync(userManager, roleManager, appContext);
				var grantContext = services.GetRequiredService<PersistedGrantDbContext>();
				var configContext = services.GetRequiredService<ConfigurationDbContext>();
				await SeedClients.EnsureSeedDataAsync(grantContext, configContext);
			}
		}
	}
}
