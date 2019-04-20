using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Descriptor.Infrastructure.Requests
{
	[XmlRoot(ElementName = "GetItemRequest", Namespace = "urn:ebay:apis:eBLBaseComponents")]
	public class GetItemRequest : BaseEbayTradingRequest
	{
		public override string OperationName => "GetItem";

		public string ItemID { get; set; }

		public GetItemRequest() { }

		public GetItemRequest(string token, string itemId) : base(token)
		{
			ItemID = itemId;
		}
	}
}
