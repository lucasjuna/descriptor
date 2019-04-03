using Descriptor.Identity.Model;
using IdentityModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Descriptor.Identity
{
	public class ApplicationUserClaimsPrincipalFactory : UserClaimsPrincipalFactory<ApplicationUser, ApplicationRole>
	{
		public ApplicationUserClaimsPrincipalFactory(UserManager<ApplicationUser> userManager,
			RoleManager<ApplicationRole> roleManager, IOptions<IdentityOptions> optionsAccessor)
			: base(userManager, roleManager, optionsAccessor) { }

		public async override Task<ClaimsPrincipal> CreateAsync(ApplicationUser user)
		{
			var principal = await base.CreateAsync(user);
			((ClaimsIdentity)principal.Identity).AddClaims(new[]
			{
				new Claim(JwtClaimTypes.GivenName, user.FirstName),
				new Claim(JwtClaimTypes.FamilyName, user.LastName),
				new Claim(JwtClaimTypes.Email, user.Email),
				new Claim(JwtClaimTypes.Name, user.UserName),
				new Claim("employee_id", user.EmployeeId),
			});
			return principal;
		}
	}
}
