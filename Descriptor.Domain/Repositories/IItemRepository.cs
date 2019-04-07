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
		Task<IList<ItemDto>> FindDtoByUser(string userName);
		Task<ItemDto> FindDto(string itemId);
		Task<SellerProduct> Find(string itemId);
		Task<DescriptionDto> FindDescription(string itemId, long descriptionId);
	}
}
