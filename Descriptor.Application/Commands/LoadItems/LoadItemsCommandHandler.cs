using Descriptor.Application.Dto;
using Descriptor.Application.Services;
using Descriptor.Domain.Entities;
using Descriptor.Domain.Repositories;
using Descriptor.Domain.Seedwork;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Descriptor.Application.Commands.LoadItems
{
	public class LoadItemsCommandHandler : IRequestHandler<LoadItemsCommand, ReviewsResultDto>
	{
		private readonly IEbayTradingService _ebayTradingService;
		private readonly IEbayFindingService _ebayFindingService;
		private readonly ISellerRepository _sellerRepo;
		private readonly IItemRepository _itemRepo;
		private readonly IUnitOfWork _uow;

		public LoadItemsCommandHandler(IEbayTradingService ebayTradingService, IEbayFindingService ebayFindingService,
			IUnitOfWork uow, ISellerRepository sellerRepo, IItemRepository itemRepo)
		{
			_ebayTradingService = ebayTradingService;
			_ebayFindingService = ebayFindingService;
			_sellerRepo = sellerRepo;
			_itemRepo = itemRepo;
			_uow = uow;
		}

		public async Task<ReviewsResultDto> Handle(LoadItemsCommand request, CancellationToken cancellationToken)
		{
			var seller = await _sellerRepo.Find(request.UserName);
			var listedItems = await _ebayFindingService.FindItemsAdvanced(request.UserName);
			List<string> processed = new List<string>();
			foreach (var itemInfo in listedItems)
			{
				if (!processed.Contains(itemInfo.ItemId) && !await _itemRepo.Exists(itemInfo.ItemId))
				{
					var item = await _ebayTradingService.GetItem(itemInfo.ItemId);
					var product = new SellerProduct()
					{
						Country = itemInfo.Country,
						EbayBuyItNowPrice = item.EbayBuyItNowPrice,
						EbayDescription = itemInfo.EbayDescription,
						ItemId = item.ItemId,
						EbayItemLocation = itemInfo.EbayItemLocation,
						EbayItemPictureDetails = itemInfo.EbayItemPictureDetails,
						EbayViewItemUrl = itemInfo.EbayViewItemUrl,
						SKU = item.SKU,
						UserId = seller.Id,
						CrossboarderTrade = item.CrossboarderTrade
					};
					_itemRepo.Add(product);
					processed.Add(item.ItemId);
				}
			}
			await _uow.SaveEntitiesAsync();
			return new ReviewsResultDto
			{
				Escalated = processed.Count,
				Total = seller.Total + processed.Count
			};
		}
	}
}
