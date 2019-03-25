using Descriptor.Identity.Data;
using Descriptor.Identity.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Descriptor.Identity.Validation
{
	public class ApplicationUserValidator : UserValidator<ApplicationUser>
	{
		private readonly ApplicationDbContext _context;

		public ApplicationUserValidator(ApplicationDbContext context)
		{
			_context = context;
		}

		public override async Task<IdentityResult> ValidateAsync(UserManager<ApplicationUser> manager, ApplicationUser user)
		{
			var errors = new List<IdentityError>();
			var users = _context.Set<ApplicationUser>();

			if (string.IsNullOrEmpty(user.FirstName))
				errors.Add(new IdentityError() { Description = "First name is required." });
			if (string.IsNullOrEmpty(user.FirstName))
				errors.Add(new IdentityError() { Description = "First name is required." });
			if (string.IsNullOrEmpty(user.EmployeeId))
				errors.Add(new IdentityError() { Description = "Employee ID is required." });
			else if (await users.AnyAsync(x => x.EmployeeId == user.EmployeeId))
				errors.Add(new IdentityError() { Description = $"Employee ID '{user.EmployeeId}' is already taken." });
			if (string.IsNullOrEmpty(user.Email))
				errors.Add(new IdentityError() { Description = "Email is required." });
			else if (await users.AnyAsync(x => x.NormalizedEmail == user.Email.ToUpper()))
				errors.Add(new IdentityError() { Description = $"Email '{user.Email}' is already taken." });

			if (errors.Any())
				return IdentityResult.Failed(errors.ToArray());
			else
				return IdentityResult.Success;
		}
	}
}
