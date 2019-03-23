using System;
using System.Collections.Generic;
using System.Text;

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
		public decimal EbayBuyItNowPrice { get; set; }
		public string EbayViewItemUrl { get; set; }
		public string EbayItemLocation { get; set; }
		public string EbayItemPictureDetails { get; set; }
	}
}
