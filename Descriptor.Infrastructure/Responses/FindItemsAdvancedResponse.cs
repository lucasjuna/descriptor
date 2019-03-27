using System.Collections.Generic;
using System.Xml.Serialization;

namespace Descriptor.Infrastructure.Responses
{
	[XmlRoot(ElementName = "findItemsAdvancedResponse", Namespace = "http://www.ebay.com/marketplace/search/v1/services")]
	public class FindItemsAdvancedResponse : BaseEbayFindingResponse
	{
		[XmlArray(ElementName = "searchResult")]
		[XmlArrayItem(ElementName = "item")]
		public List<Item> SearchResult { get; set; }

		public FindItemsAdvancedResponse() { }

		public class Item
		{
			[XmlElement(ElementName = "itemId")]
			public string ItemId { get; set; }
			[XmlElement(ElementName = "country")]
			public string Country { get; set; }
		}
	}
}
