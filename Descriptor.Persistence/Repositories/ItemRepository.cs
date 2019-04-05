using Descriptor.Domain.Dto;
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

		public async Task<IList<ItemDto>> FindByUser(string userName)
		{
			return await _context.SellerProducts.Where(x => x.User.EbaySellerUserName == userName)
				.Select(x => new ItemDto
				{
					Description = x.EbayDescription,
					ItemId = x.ItemId,
					Seller = x.User.EbaySellerUserName,
					Status = x.ItemStatus,
					ReviewDate = DateTime.Today
				}).ToListAsync();
		}

		public async Task<ItemDto> Find(string itemId)
		{
			return await _context.SellerProducts.Where(x => x.ItemId == itemId)
				.Select(x => new ItemDto
				{
					Description = x.EbayDescription,
					ItemId = x.ItemId,
					Seller = x.User.EbaySellerUserName,
					Status = x.ItemStatus,
					ReviewDate = DateTime.Today,
					ShortDescription = x.CurrentDescription.ShortDescription,
					DescriptionId = x.CurrentDescriptionId,
					Reviewer = $"{x.CurrentDescription.Reviewer.FirstName} {x.CurrentDescription.Reviewer.LastName}",
					ImagesStatus = x.ImagesStatus,
					ItemStatus = x.ItemStatus,
					PriceStatus = x.PriceStatus,
					Price = x.EbayBuyItNowPrice,
					ItemUrl = x.EbayViewItemUrl,
					Descriptions = x.Descriptions.Select(d => new DescriptionDto
					{
						Id = d.Id,
						ShortDescription = d.ShortDescription,
						Status = d.Status
					}).ToList()
				}).SingleOrDefaultAsync();
		}
	}
}
