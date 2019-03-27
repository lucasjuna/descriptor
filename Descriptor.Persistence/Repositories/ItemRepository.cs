using Descriptor.Domain.Entities;
using Descriptor.Domain.Repositories;
using Descriptor.Persistence.DataContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Descriptor.Persistence.Repositories
{
	public class ItemRepository : IItemRepository
	{
		private readonly DescriptorContext _context;

		public ItemRepository(DescriptorContext context)
		{
			_context = context;
		}

		public void Add(SellerProduct item)
		{
			_context.SellerProducts.Add(item);
		}

		public async Task<bool> Exists(string itemId)
		{
			return await _context.SellerProducts.AnyAsync(x => x.ItemId == itemId);
		}
	}
}
