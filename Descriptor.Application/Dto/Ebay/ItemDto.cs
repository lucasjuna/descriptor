namespace Descriptor.Application.Dto.Ebay
{
	public class ItemDto
	{
		public string ItemId { get; set; }
		public string UserId { get; set; }
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
