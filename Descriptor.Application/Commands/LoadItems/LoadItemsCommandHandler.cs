using Descriptor.Application.Dto;
using Descriptor.Application.Services;
using Descriptor.Domain.Entities;
using Descriptor.Domain.Repositories;
using Descriptor.Domain.Seedwork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
		private readonly IProductImageRepository _imageRepo;
		private readonly IUnitOfWork _uow;

		public LoadItemsCommandHandler(IEbayTradingService ebayTradingService, IEbayFindingService ebayFindingService,
			IUnitOfWork uow, ISellerRepository sellerRepo, IItemRepository itemRepo, IProductImageRepository imageRepo)
		{
			_ebayTradingService = ebayTradingService;
			_ebayFindingService = ebayFindingService;
			_sellerRepo = sellerRepo;
			_itemRepo = itemRepo;
			_imageRepo = imageRepo;
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
					string pictureUrls = null;
					if (item.PictureURLs?.Any() ?? false)
					{
						pictureUrls = string.Join(Environment.NewLine, item.PictureURLs);
						await LoadImages(item.PictureURLs, item.ItemId);
					}
					var product = new SellerProduct()
					{
						Country = itemInfo.Country,
						EbayBuyItNowPrice = item.EbayBuyItNowPrice,
						
						EbayDescription = itemInfo.EbayDescription,
						ItemId = item.ItemId,
						EbayItemLocation = itemInfo.EbayItemLocation,
						EbayItemPictureDetails = pictureUrls,
						EbayViewItemUrl = itemInfo.EbayViewItemUrl,
						SKU = item.SKU,
						UserId = seller.Id,
						CrossboarderTrade = item.CrossboarderTrade,
					};
					_itemRepo.Add(product);
					processed.Add(item.ItemId);
					await _uow.SaveEntitiesAsync();
				}
			}
			return new ReviewsResultDto
			{
				Escalated = processed.Count,
				Total = seller.Total + processed.Count
			};
		}

		private async Task LoadImages(IEnumerable<string> pictureUrls, string itemId)
		{
			using (var client = new HttpClient())
			{
				var getTasks = pictureUrls.Take(10).Select(x => client.GetByteArrayAsync(x));
				var imagesData = await Task.WhenAll(getTasks);
				var productImages = imagesData.Select(x => new ProductImage() { ImageData = x, ItemId = itemId });
				foreach (var img in productImages)
				{
					_imageRepo.Add(img);
				}
			}
		}
	}
}
