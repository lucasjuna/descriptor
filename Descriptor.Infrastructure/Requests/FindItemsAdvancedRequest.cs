using System.Xml.Serialization;

namespace Descriptor.Infrastructure.Requests
{
	[XmlRoot(ElementName = "findItemsAdvancedRequest", Namespace = "http://www.ebay.com/marketplace/search/v1/services")]
	public class FindItemsAdvancedRequest : BaseEbayFindingRequest
	{
		[XmlElement(ElementName = "itemFilter")]
		public Filter ItemFilter { get; set; }

		public FindItemsAdvancedRequest() { }

		public FindItemsAdvancedRequest(string userId)
		{
			ItemFilter = new Filter("Seller", userId);
		}

		public class Filter
		{
			[XmlElement(ElementName = "name")]
			public string Name { get; set; }
			[XmlElement(ElementName = "value")]
			public string Value { get; set; }

			public Filter() { }

			public Filter(string name, string value)
			{
				Name = name;
				Value = value;
			}
		}
	}
}
