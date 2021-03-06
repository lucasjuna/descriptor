﻿using System.Xml.Serialization;

namespace Descriptor.Infrastructure.Requests
{
	[XmlRoot(ElementName = "GetUserRequest", Namespace = "urn:ebay:apis:eBLBaseComponents")]
	public class GetUserRequest : BaseEbayTradingRequest
	{
		public override string OperationName => "GetUser";

		public string UserID { get; set; }

		public GetUserRequest() { }

		public GetUserRequest(string token, string userId) : base(token)
		{
			UserID = userId;
		}
	}
}
