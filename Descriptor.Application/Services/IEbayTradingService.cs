using Descriptor.Application.Dto.Ebay;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Descriptor.Application.Services
{
	public interface IEbayTradingService
	{
		Task<UserDto> GetUser(string userName);
		Task<ItemDto> GetItem(string itemId);
	}
}
