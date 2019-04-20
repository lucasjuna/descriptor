using Descriptor.Domain.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Descriptor.Domain.Dto
{
	public class DescriptionDto
	{
		public long Id { get; set; }
		public string ShortDescription { get; set; }
		public string LongDescription { get; set; }
		public ReviewStatus? Status { get; set; }
	}
}
