using Descriptor.Domain.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Descriptor.Domain.Entities
{
	public class ItemReviewStatus
	{
		public long Id { get; set; }
		public long ItemId { get; set; }
		public SellerProduct Item { get; set; }
		public DateTime ReviewDate { get; set; }
		public string HsCode { get; set; }
		public string ShortDescription { get; set; }
		public ReviewStatus? Status { get; set; }
		public string Method { get; set; }
		public string ReviewerId { get; set; }
		public ReviewerInfo Reviewer { get; set; }
	}
}
