﻿using Descriptor.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Descriptor.Persistence.EntityConfigurations
{
	public class SellerProductConfig : IEntityTypeConfiguration<SellerProduct>
	{
		public void Configure(EntityTypeBuilder<SellerProduct> builder)
		{
			builder.ToTable("SellerProductList");
			builder.HasOne(x => x.User).WithMany(x => x.Products).IsRequired().HasForeignKey(x => x.UserId);
			builder.Property(x => x.ItemId).IsRequired();
			builder.HasIndex(x => x.ItemId).IsUnique();
			builder.HasOne(x => x.CurrentDescription).WithOne().HasForeignKey<SellerProduct>(x => x.CurrentDescriptionId);
		}
	}
}
