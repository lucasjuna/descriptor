using System;
using System.Collections.Generic;
using System.Text;

namespace Descriptor.Domain.Entities
{
	public class ProductImage
	{
		public long Id { get; set; }
		public long ItemId { get; set; }
		public SellerProduct Item { get; set; }
		public byte[] ImageData { get; set; }
	}
}
