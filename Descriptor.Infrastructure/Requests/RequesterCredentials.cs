using System;
using System.Collections.Generic;
using System.Text;

namespace Descriptor.Infrastructure.Requests
{
	public class RequesterCredentials
	{
		public string eBayAuthToken { get; set; }

		public RequesterCredentials() { }

		public RequesterCredentials(string token)
		{
			eBayAuthToken = token;
		}
	}
}
