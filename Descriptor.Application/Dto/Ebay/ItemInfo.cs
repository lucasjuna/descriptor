namespace Descriptor.Application.Dto.Ebay
{
	public class ItemInfo
	{
		public string ItemID { get; set; }
		public string SKU { get; set; }
		public UserInfo Seller { get; set; }
		public PriceInfo BuyItNowPrice { get; set; }
		public string ViewItemURL { get; set; }
		public PictureDetailsInfo PictureDetails { get; set; }
	}
}
