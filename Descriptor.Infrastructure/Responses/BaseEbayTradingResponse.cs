using System;
using System.Collections.Generic;
using System.Text;

namespace Descriptor.Infrastructure.Responses
{
	public abstract class BaseEbayTradingResponse
	{
		public string Ack { get; set; }
		public ResponseErrors Errors { get; set; }

		public class ResponseErrors
		{
			public string ShortMessage { get; set; }
			public string LongMessage { get; set; }
			public string ErrorCode { get; set; }
		}
	}
}
