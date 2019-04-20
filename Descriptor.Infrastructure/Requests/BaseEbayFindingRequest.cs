using System;
using System.Collections.Generic;
using System.Text;

namespace Descriptor.Infrastructure.Requests
{
	public abstract class BaseEbayFindingRequest
	{
		public abstract string OperationName { get; }
	}
}
