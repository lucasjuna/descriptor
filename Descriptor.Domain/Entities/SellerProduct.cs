using Descriptor.Domain.Enumerations;
using System.Collections.Generic;

namespace Descriptor.Domain.Entities
{
	public class SellerProduct
	{
		public long Id { get; set; }
		public long UserId { get; set; }
		public SellerInfo User { get; set; }
		public string ItemId { get; set; }
		public string Country { get; set; }
		public string CrossboarderTrade { get; set; }
		public string SKU { get; set; }
		public string EbayDescription { get; set; }
		public string EbayLongDescription { get; set; }
		public decimal EbayBuyItNowPrice { get; set; }
		public string EbayViewItemUrl { get; set; }
		public string EbayItemLocation { get; set; }
		public string EbayItemPictureDetails { get; set; }
		public ReviewStatus? ItemStatus { get; set; }
		public ReviewStatus? ImagesStatus { get; set; }
		public ReviewStatus? PriceStatus { get; set; }
		public long? CurrentDescriptionId { get; set; }
		public ItemReviewStatus CurrentDescription { get; set; }
		public ICollection<ItemReviewStatus> Descriptions { get; set; }
	}
}
