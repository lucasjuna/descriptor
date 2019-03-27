using Descriptor.Application.Services;
using Descriptor.Domain.Entities;
using Descriptor.Domain.Repositories;
using Descriptor.Domain.Seedwork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Descriptor.Application.Commands.LoadItems
{
	public class LoadItemsCommandHandler : IRequestHandler<LoadItemsCommand>
	{
		private readonly IEbayTradingService _ebayTradingService;
		private readonly IEbayFindingService _ebayFindingService;
		private readonly ISellerRepository _sellerRepo;
		private readonly IUnitOfWork _uow;

		public LoadItemsCommandHandler(IEbayTradingService ebayTradingService, IEbayFindingService ebayFindingService,
			IUnitOfWork uow, ISellerRepository sellerRepo)
		{
			_ebayTradingService = ebayTradingService;
			_ebayFindingService = ebayFindingService;
			_sellerRepo = sellerRepo;
			_uow = uow;
		}

		public async Task<Unit> Handle(LoadItemsCommand request, CancellationToken cancellationToken)
		{
			var itemInfo = await _ebayFindingService.FindItemsAdvanced(request.UserName);
			return Unit.Value;
		}
	}
}
