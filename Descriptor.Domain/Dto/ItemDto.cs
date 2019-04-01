using System;
using System.Collections.Generic;
using System.Text;

namespace Descriptor.Domain.Dto
{
	public class ItemDto
	{
		public string Seller { get; set; }
		public string ItemId { get; set; }
		public string Description { get; set; }
		public DateTime? ReviewDate { get; set; }
		public long? DescriptionId { get; set; }
		public string ShortDescription { get; set; }
		public string Reviewer { get; set; }
		public ReviewStatus Status { get; set; }
	}
}
