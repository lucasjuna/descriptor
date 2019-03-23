using System;
using System.Collections.Generic;
using System.Text;

namespace Descriptor.Model.Entities
{
	public class ProductImage
	{
		public string ItemId { get; set; }
		public byte[] ImageData { get; set; }
	}
}
