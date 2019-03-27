using Descriptor.Application.Dto.Ebay;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Descriptor.Application.Services
{
	public interface IEbayFindingService
	{
		Task<ICollection<ItemInfo>> FindItemsAdvanced(string userName);
	}
}
