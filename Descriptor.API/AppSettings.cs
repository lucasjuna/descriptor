﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Descriptor.API
{
	public class AppSettings
	{
		public string ConnectionString { get; set; }
		public string IdentityProviderHost { get; set; }
		public string ApiName { get; set; }
	}
}
