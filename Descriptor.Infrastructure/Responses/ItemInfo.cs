using System.Collections.Generic;
using System.Xml.Serialization;

namespace Descriptor.Infrastructure.Responses
{
	public class ItemInfo
	{
		public string ItemID { get; set; }
		public string SKU { get; set; }
		public UserInfo Seller { get; set; }
		public PriceInfo BuyItNowPrice{ get; set; }
		public string ViewItemURL { get; set; }
		[XmlArrayItem(ElementName = "PictureURL")]
		public List<string> PictureDetails { get; set; }
		public string CrossBorderTrade { get; set; }
		public string Description { get; set; }

		public class PriceInfo
		{
			[XmlText]
			public decimal Value { get; set; }
			[XmlAttribute("currencyID")]
			public string CurrencyID { get; set; }
		}
	}
}
