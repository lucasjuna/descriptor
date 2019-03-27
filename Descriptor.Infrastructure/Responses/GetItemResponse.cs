using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Descriptor.Infrastructure.Responses
{
	[XmlRoot(ElementName = "GetItemResponse", Namespace = "urn:ebay:apis:eBLBaseComponents")]
	public class GetItemResponse : BaseEbayTradingResponse
	{
		public ItemInfo Item { get; set; }
	}
}
