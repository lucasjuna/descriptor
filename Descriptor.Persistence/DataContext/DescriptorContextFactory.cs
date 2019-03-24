using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;

namespace Descriptor.Persistence.DataContext
{
	public class DescriptorContextFactory : IDesignTimeDbContextFactory<DescriptorContext>
	{
		public DescriptorContext CreateDbContext(string[] args)
		{
			IConfigurationRoot config = new ConfigurationBuilder()
			   .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
			   .AddJsonFile("appsettings.Migrations.json", optional: false)
			   .Build();

			var optionsBuilder = new DbContextOptionsBuilder<DescriptorContext>();
			optionsBuilder.UseSqlServer(config["ConnectionString"]);

			return new DescriptorContext(optionsBuilder.Options);
		}
	}
}
