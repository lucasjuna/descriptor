using Descriptor.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Descriptor.Persistence.EntityConfigurations
{
	public class ItemReviewStatusConfig : IEntityTypeConfiguration<ItemReviewStatus>
	{
		public void Configure(EntityTypeBuilder<ItemReviewStatus> builder)
		{
			builder.ToTable("ItemReviewStatus");
			builder.HasOne(x => x.Reviewer).WithMany().IsRequired().HasForeignKey(x => x.ReviewerId);
		}
	}
}
