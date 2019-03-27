using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Descriptor.Infrastructure.Requests
{
	[XmlRoot(ElementName = "GetItemRequest", Namespace = "urn:ebay:apis:eBLBaseComponents")]
	public class GetSellerListRequest : BaseEbayTradingRequest
	{
		public GetSellerListRequest() { }

		public GetSellerListRequest(string token) : base(token)
		{

		}
	}
}
