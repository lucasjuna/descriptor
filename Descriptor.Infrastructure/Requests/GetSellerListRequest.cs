using System;
using System.Collections.Generic;
using System.Text;

namespace Descriptor.Infrastructure.Requests
{
	class GetSellerListRequest : BaseEbayRequest
	{
		public GetSellerListRequest(string token) : base(token)
		{

		}
	}
}
