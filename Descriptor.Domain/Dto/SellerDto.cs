using System;
using System.Collections.Generic;
using System.Text;

namespace Descriptor.Domain.Dto
{
	public class SellerDto
	{
		public long Id { get; set; }
		public string EbaySellerUserName { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Address { get; set; }
		public string EmailAddress { get; set; }
		public int Accepted { get; set; }
		public int Rejected { get; set; }
		public int Escalated { get; set; }
		public int Total { get; set; }
	}
}
