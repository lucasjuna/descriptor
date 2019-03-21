using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Descriptor.Identity
{
	public class AppSettings
	{
		public string ConnectionStringUsers { get; set; }
		public string ConnectionStringClients { get; set; }
		public string ConnectionStringGrants { get; set; }
		public string SendGridKey { get; set; }
		public string SendGridEmail { get; set; }
	}
}
