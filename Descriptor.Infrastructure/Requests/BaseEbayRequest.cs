using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Descriptor.Infrastructure.Requests
{
	public class BaseEbayRequest
	{
		public RequesterCredentials RequesterCredentials { get; set; }

		public BaseEbayRequest() { }

		public BaseEbayRequest(string token)
		{
			RequesterCredentials = new RequesterCredentials(token);
		}
	}
}
