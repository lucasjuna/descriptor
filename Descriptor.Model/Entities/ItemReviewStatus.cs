using System;
using System.Collections.Generic;
using System.Text;

namespace Descriptor.Model.Entities
{
	public class ItemReviewStatus
	{
		public long Id { get; set; }
		public string ItemId { get; set; }
		public DateTime ReviewDate { get; set; }
		public string HsCode { get; set; }
		public string ShortDescription { get; set; }
		public string Status { get; set; }
		public string Method { get; set; }
		public long ReviewerId { get; set; }
		public ReviewerInfo Reviewer { get; set; }
	}
}
