using Descriptor.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Descriptor.Persistence.EntityConfigurations
{
	public class ItemReviewStatusConfig : IEntityTypeConfiguration<ItemReviewStatus>
	{
		public void Configure(EntityTypeBuilder<ItemReviewStatus> builder)
		{
			builder.ToTable("ItemReviewStatus");
			builder.HasOne(x => x.Reviewer).WithMany().IsRequired().HasForeignKey(x => x.ReviewerId);
			builder.HasOne(x => x.Item).WithMany(x => x.Descriptions).IsRequired().HasForeignKey(x => x.ItemId);
		}
	}
}
