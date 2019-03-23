using System;
using System.Collections.Generic;
using System.Text;

namespace Descriptor.Domain.Entities
{
	public class ProductImage
	{
		public long Id { get; set; }
		public string ItemId { get; set; }
		public byte[] ImageData { get; set; }
	}
}
