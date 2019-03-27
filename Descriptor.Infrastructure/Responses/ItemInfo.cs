using System.Collections.Generic;

namespace Descriptor.Infrastructure.Responses
{
	public class ItemInfo
	{
		public string ItemID { get; set; }
		public string SKU { get; set; }
		public UserInfo Seller { get; set; }
		public PriceInfo BuyItNowPrice { get; set; }
		public string ViewItemURL { get; set; }
		public PictureDetailsInfo PictureDetails { get; set; }
		public string CrossBorderTrade { get; set; }

		public class PictureDetailsInfo
		{
			public ExtendedPictureDetailsInfo ExtendedPictureDetails { get; set; }
		}

		public class PriceInfo
		{
			public decimal Price { get; set; }
			public string CurrencyID { get; set; }
		}

		public class ExtendedPictureDetailsInfo
		{
			public List<string> PictureURLs { get; set; }
		}
	}
}
