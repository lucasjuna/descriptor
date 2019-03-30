using System;

namespace Descriptor.Application.Exceptions
{

	[Serializable]
	public class EbayException : Exception
	{
		public EbayException() { }
		public EbayException(string message) : base(message) { }
		public EbayException(string message, Exception inner) : base(message, inner) { }
		protected EbayException(
		  System.Runtime.Serialization.SerializationInfo info,
		  System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
	}
}
