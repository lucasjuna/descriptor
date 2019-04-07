using Descriptor.Application.Commands;
using Descriptor.Domain.Enumerations;
using Descriptor.Domain.Repositories;
using Descriptor.Domain.Seedwork;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Descriptor.Application.CommandHandlers
{
	public class ReviewItemCommandHandler : IRequestHandler<ReviewItemCommand>
	{
		private readonly IItemRepository _itemRepo;
		private readonly IUnitOfWork _uow;

		public ReviewItemCommandHandler(IItemRepository itemRepo, IUnitOfWork uow)
		{
			_itemRepo = itemRepo;
			_uow = uow;
		}

		public async Task<Unit> Handle(ReviewItemCommand request, CancellationToken cancellationToken)
		{
			var item = await _itemRepo.Find(request.ItemId);
			if (item != null)
			{
				item.ImagesStatus = request.ImagesStatus;
				item.PriceStatus = request.PriceStatus;
				item.CurrentDescriptionId = request.DescriptionId;
				foreach (var dbDescr in item.Descriptions)
				{
					var dtoDescr = request.Descriptions.SingleOrDefault(x => x.Id == dbDescr.Id);
					if (dtoDescr != null)
					{
						dbDescr.Status = dtoDescr.Status;
						dbDescr.Method = "Manual";
					}
				}

				if (request.ItemStatus == ReviewStatus.Accepted)
				{
					if (item.ImagesStatus == ReviewStatus.Accepted && item.PriceStatus == ReviewStatus.Accepted &&
						item.Descriptions.SingleOrDefault(x => x.Id == item.CurrentDescriptionId)?.Status == ReviewStatus.Accepted)
						item.ItemStatus = request.ItemStatus;
					else
						item.ItemStatus = null;
				}
				else
				{
					item.ItemStatus = request.ItemStatus;
				}

				await _uow.SaveEntitiesAsync();
			}
			return Unit.Value;
		}
	}
}
