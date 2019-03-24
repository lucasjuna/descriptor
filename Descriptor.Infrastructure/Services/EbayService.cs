using Descriptor.Application.Dto.Ebay;
using Descriptor.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Descriptor.Infrastructure.Services
{
	public class EbayService : IEbayService
	{
		public Task<ICollection<ItemInfo>> GetSellerList(string userName)
		{
			throw new NotImplementedException();
		}

		public Task<UserInfo> GetUser(string userName)
		{
			throw new NotImplementedException();
		}
	}
}
