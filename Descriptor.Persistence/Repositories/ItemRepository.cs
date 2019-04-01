﻿using Descriptor.Domain.Dto;
using Descriptor.Domain.Entities;
using Descriptor.Domain.Repositories;
using Descriptor.Persistence.DataContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

		public async Task<IList<ItemDto>> Find(string userName)
		{
			return await _context.SellerProducts.Where(x => x.User.EbaySellerUserName == userName)
				.Select(x => new ItemDto
				{
					Description = x.EbayDescription,
					ItemId = x.ItemId,
					Seller = x.User.EbaySellerUserName,
					Status = ReviewStatus.Escalated,
					ReviewDate = DateTime.Today
				}).ToListAsync();
		}
	}
}
