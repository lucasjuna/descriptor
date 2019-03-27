using System;
using System.Collections.Generic;
using System.Text;

namespace Descriptor.Application.Dto
{
	public class ReviewsResultDto
	{
		public int Accepted { get; set; }
		public int Rejected { get; set; }
		public int Escalated { get; set; }
		public int Total { get; set; }
	}
}
