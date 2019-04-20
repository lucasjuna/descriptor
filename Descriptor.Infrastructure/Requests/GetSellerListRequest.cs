using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Descriptor.Infrastructure.Requests
{
	[XmlRoot(ElementName = "GetSellerListRequest", Namespace = "urn:ebay:apis:eBLBaseComponents")]
	public class GetSellerListRequest : BaseEbayTradingRequest
	{
		public override string OperationName => "GetSellerList";

		public GetSellerListRequest() { }

		public GetSellerListRequest(string token) : base(token)
		{

		}
	}
}
