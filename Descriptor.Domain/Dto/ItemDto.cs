using Descriptor.Domain.Enumerations;
using System;
using System.Collections.Generic;

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
		public ReviewStatus? Status { get; set; }
		public string ItemUrl { get; set; }
		public decimal Price { get; set; }
		public ReviewStatus? ItemStatus { get; set; }
		public ReviewStatus? ImagesStatus { get; set; }
		public ReviewStatus? PriceStatus { get; set; }
		public IList<DescriptionDto> Descriptions { get; set; }
		public string ImageUrls { get; set; }
	}
}
