using Descriptor.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Descriptor.Persistence.EntityConfigurations
{
	public class SellerInfoConfig : IEntityTypeConfiguration<SellerInfo>
	{
		public void Configure(EntityTypeBuilder<SellerInfo> builder)
		{
			builder.ToTable("SellerInfo");
			builder.Property(x => x.EbaySellerUserName).IsRequired();
			builder.HasIndex(x => x.EbaySellerUserName).IsUnique();
		}
	}
}
