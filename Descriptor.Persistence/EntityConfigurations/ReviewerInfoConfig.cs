using Descriptor.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Descriptor.Persistence.EntityConfigurations
{
	public class ReviewerInfoConfig : IEntityTypeConfiguration<ReviewerInfo>
	{
		public void Configure(EntityTypeBuilder<ReviewerInfo> builder)
		{
			builder.ToTable("ReviewerInfo");
			builder.HasKey(x => x.Id);
			builder.Property(x => x.Id).ValueGeneratedNever();
		}
	}
}
