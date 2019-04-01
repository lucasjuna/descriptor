using Descriptor.Domain.Dto;
using Descriptor.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Descriptor.Domain.Repositories
{
	public interface IItemRepository
	{
		Task<bool> Exists(string itemId);
		void Add(SellerProduct item);
		Task<IList<ItemDto>> Find(string userName);
	}
}
