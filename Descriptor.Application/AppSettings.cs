﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Descriptor.Application
{
	public class AppSettings
	{
		public string ConnectionString { get; set; }
		public string IdentityProviderHost { get; set; }
		public string ApiName { get; set; }
		public string EbayApiTradingHost { get; set; }
		public string EbayApiFindingHost { get; set; }
		public string EbayApiToken { get; set; }
		public string EbayApiDevId { get; set; }
		public string EbayApiAppId { get; set; }
		public string EbayApiCertId { get; set; }
	}
}
