using System;
using System.Collections.Generic;
using System.Text;
using Descriptor.Identity.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Descriptor.Identity.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options) { }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
			builder.Entity<ApplicationUser>();
			builder.Entity<ApplicationRole>();
		}
	}
}
