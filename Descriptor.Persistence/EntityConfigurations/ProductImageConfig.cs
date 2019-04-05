using Descriptor.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Descriptor.Persistence.EntityConfigurations
{
	public class ProductImageConfig : IEntityTypeConfiguration<ProductImage>
	{
		public void Configure(EntityTypeBuilder<ProductImage> builder)
		{
			builder.ToTable("ProductImages");
			builder.HasOne(x => x.Item).WithMany().IsRequired().HasForeignKey(x => x.ItemId);
			builder.Property(x => x.ImageData).IsRequired();
		}
	}
}
