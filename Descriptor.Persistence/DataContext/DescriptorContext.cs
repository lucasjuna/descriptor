using Descriptor.Domain.Entities;
using Descriptor.Domain.Seedwork;
using Descriptor.Persistence.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Descriptor.Persistence.DataContext
{
	public class DescriptorContext : DbContext, IUnitOfWork
	{
		public DbSet<ItemReviewStatus> ItemReviewStatus { get; set; }
		public DbSet<ProductImage> ProductImages { get; set; }
		public DbSet<ReviewerInfo> ReviewerInfo { get; set; }
		public DbSet<SellerInfo> SellerInfo { get; set; }
		public DbSet<SellerProduct> SellerProducts { get; set; }

		public DescriptorContext(DbContextOptions options) : base(options) { }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new ItemReviewStatusConfig());
			modelBuilder.ApplyConfiguration(new ProductImageConfig());
			modelBuilder.ApplyConfiguration(new ReviewerInfoConfig());
			modelBuilder.ApplyConfiguration(new SellerInfoConfig());
			modelBuilder.ApplyConfiguration(new SellerProductConfig());
		}

		public async Task SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken))
		{
			await SaveChangesAsync(cancellationToken);
		}
	}
}
