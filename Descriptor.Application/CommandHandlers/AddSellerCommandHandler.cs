using Descriptor.Application.Commands;
using Descriptor.Application.Services;
using Descriptor.Domain.Entities;
using Descriptor.Domain.Repositories;
using Descriptor.Domain.Seedwork;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Descriptor.Application.CommandHandlers
{
	public class AddSellerCommandHandler : IRequestHandler<AddSellerCommand>
	{
		private readonly IEbayTradingService _ebayService;
		private readonly ISellerRepository _sellerRepo;
		private readonly IUnitOfWork _uow;

		public AddSellerCommandHandler(IEbayTradingService ebayService, IUnitOfWork uow, ISellerRepository sellerRepo)
		{
			_ebayService = ebayService;
			_sellerRepo = sellerRepo;
			_uow = uow;
		}

		public async Task<Unit> Handle(AddSellerCommand request, CancellationToken cancellationToken)
		{
			var userInfo = await _ebayService.GetUser(request.UserName);
			if (userInfo != null)
			{
				var seller = new SellerInfo
				{
					EmailAddress = userInfo.Email?.Contains("@") ?? false ? userInfo.Email : null,
					EbaySellerUserName = userInfo.UserName.ToLower(),
					Address1 = userInfo.Street,
					Address2 = userInfo.Street1,
					Address3 = userInfo.Street2,
					City = userInfo.City,
					State = userInfo.State,
					Zip = userInfo.Zip,
					DateAdded = userInfo.RegistrationDate,
					FirstName = userInfo.FirstName,
					LastName = userInfo.LastName,
					LastProcessDate = DateTime.UtcNow,
				};
				_sellerRepo.Add(seller);
				await _uow.SaveEntitiesAsync();
			}
			return Unit.Value;
		}
	}
}
