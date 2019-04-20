using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Descriptor.Infrastructure.Requests
{
	public abstract class BaseEbayTradingRequest
	{
		public abstract string OperationName { get; }

		public string OutputSelector { get; set; }
		public RequesterCredentials RequesterCredentials { get; set; }

		public BaseEbayTradingRequest() { }

		public BaseEbayTradingRequest(string token)
		{
			RequesterCredentials = new RequesterCredentials(token);
		}
	}
}
