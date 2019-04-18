using System.Xml.Serialization;

namespace Descriptor.Infrastructure.Requests
{
	[XmlRoot(ElementName = "findItemsAdvancedRequest", Namespace = "http://www.ebay.com/marketplace/search/v1/services")]
	public class FindItemsAdvancedRequest : BaseEbayFindingRequest
	{
		[XmlElement(ElementName = "itemFilter")]
		public Filter[] ItemFilters { get; set; }
		[XmlElement(ElementName = "paginationInput")]
		public Pagination PaginationInput { get; set; }

		public FindItemsAdvancedRequest() { }

		public FindItemsAdvancedRequest(string userId, int entriesPerPage, int pageNumber, bool hideDuplicates)
		{
			ItemFilters = new[]
			{
				new Filter("Seller", userId),
				new Filter("HideDuplicateItems", hideDuplicates.ToString())
			};
			PaginationInput = new Pagination(entriesPerPage, pageNumber);
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

		public class Pagination
		{
			[XmlElement(ElementName = "entriesPerPage")]
			public int EntriesPerPage { get; set; }
			[XmlElement(ElementName = "pageNumber")]
			public int PageNumber { get; set; }

			public Pagination() { }

			public Pagination(int entriesPerPage, int pageNumber)
			{
				EntriesPerPage = entriesPerPage;
				PageNumber = pageNumber;
			}
		}
	}
}
