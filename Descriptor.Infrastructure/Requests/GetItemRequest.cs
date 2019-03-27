using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Descriptor.Infrastructure.Requests
{
	[XmlRoot(ElementName = "GetItemRequest", Namespace = "urn:ebay:apis:eBLBaseComponents")]
	public class GetItemRequest : BaseEbayTradingRequest
	{
		public GetItemRequest() { }

		public GetItemRequest(string token) : base(token)
		{

		}
	}
}
