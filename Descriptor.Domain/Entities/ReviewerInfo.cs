using System;
using System.Collections.Generic;
using System.Text;

namespace Descriptor.Domain.Entities
{
	public class ReviewerInfo
	{
		public string Id { get; set; }
		public string EmpId { get; set; }
		public string LoginName { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public DateTime LastLoginDateTime { get; set; }
	}
}
