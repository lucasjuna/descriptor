using Descriptor.Application.Dto.Ebay;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Descriptor.Infrastructure.Responses
{
	[XmlRoot(ElementName = "GetUserResponse", Namespace = "urn:ebay:apis:eBLBaseComponents")]
	public class GetUserResponse : BaseEbayTradingResponse
	{
		public UserInfo User { get; set; }
	}
}
