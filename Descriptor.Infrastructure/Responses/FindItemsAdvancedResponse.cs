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
			[XmlElement(ElementName = "location")]
			public string Location { get; set; }
			[XmlElement(ElementName = "galleryURL")]
			public string GalleryUrl { get; set; }
			[XmlElement(ElementName = "viewItemURL")]
			public string ViewItemUrl { get; set; }
			[XmlElement(ElementName = "title")]
			public string Title { get; set; }
		}
	}
}
