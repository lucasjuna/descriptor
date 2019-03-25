using Descriptor.Identity.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Descriptor.Identity.Data
{
	public static class SeedUsers
	{
		public static async Task EnsureSeedDataAsync(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, ApplicationDbContext appContext)
		{
			appContext.Database.Migrate();
			await SeedRolesDataAsync(roleManager);
			await SeedUsersDataAsync(userManager);
		}

		private static async Task SeedUsersDataAsync(UserManager<ApplicationUser> userManager)
		{
			if (await userManager.FindByNameAsync("user1") == null)
			{
				ApplicationUser user = new ApplicationUser
				{
					UserName = "user1",
					Email = "user1@localhost",
					FirstName = "John",
					LastName = "Smith",
					EmployeeId = "001"
				};

				IdentityResult result = await userManager.CreateAsync(user, "User.1");

				if (result.Succeeded)
				{
					await userManager.AddToRoleAsync(user, "NormalUser");
				}
			}

			if (await userManager.FindByNameAsync("admin") == null)
			{
				ApplicationUser user = new ApplicationUser
				{
					UserName = "admin",
					Email = "admin@localhost",
					FirstName = "Robert",
					LastName = "Williams",
					EmployeeId = "002"
				};

				IdentityResult result = await userManager.CreateAsync(user, "Admin.1");

				if (result.Succeeded)
				{
					await userManager.AddToRoleAsync(user, "Administrator");
				}
			}
		}

		private static async Task SeedRolesDataAsync(RoleManager<ApplicationRole> roleManager)
		{
			if (!await roleManager.RoleExistsAsync("NormalUser"))
			{
				ApplicationRole role = new ApplicationRole
				{
					Name = "NormalUser"
				};
				IdentityResult roleResult = await roleManager.CreateAsync(role);
			}

			if (!await roleManager.RoleExistsAsync("Administrator"))
			{
				ApplicationRole role = new ApplicationRole
				{
					Name = "Administrator"
				};
				IdentityResult roleResult = await roleManager.CreateAsync(role);
			}
		}
	}
}
