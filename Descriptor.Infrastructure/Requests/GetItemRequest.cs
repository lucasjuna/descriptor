using System;
using System.Collections.Generic;
using System.Text;

namespace Descriptor.Infrastructure.Requests
{

	class GetItemRequest : BaseEbayRequest
	{
		public GetItemRequest(string token) : base(token)
		{

		}
	}
}
