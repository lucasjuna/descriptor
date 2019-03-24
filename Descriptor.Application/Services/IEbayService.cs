using Descriptor.Application.Dto.Ebay;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Descriptor.Application.Services
{
	public interface IEbayService
	{
		Task<UserInfo> GetUser(string userName);
		Task<ICollection<ItemInfo>> GetSellerList(string userName);
	}
}
