using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Descriptor.Infrastructure.Responses
{
	public abstract class BaseEbayFindingResponse
	{
		[XmlElement(ElementName = "ack")]
		public string Ack { get; set; }
		[XmlElement(ElementName = "errorMessage")]
		public ResponseErrorMessage ErrorMessage { get; set; }

		public class ResponseErrorMessage
		{
			[XmlElement(ElementName = "error")]
			public ResponseError Error { get; set; }
		}

		public class ResponseError
		{
			[XmlElement(ElementName = "message")]
			public string Message { get; set; }
			[XmlElement(ElementName = "errorId")]
			public string ErrorID { get; set; }
			[XmlElement(ElementName = "parameter")]
			public string Parameter { get; set; }
		}
	}
}