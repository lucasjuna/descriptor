using System;
using System.Collections.Generic;
using System.Text;

namespace Descriptor.Domain.Dto
{
	public class SellerDto
	{
		public string EbaySellerUserName { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Address { get; set; }
		public string EmailAddress { get; set; }
		public int Escalated { get; set; }
	}
}
