using Descriptor.Application.Commands;
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
				item.ItemStatus = request.ItemStatus;
				item.ImagesStatus = request.ImagesStatus;
				item.PriceStatus = request.PriceStatus;
				item.CurrentDescriptionId = request.DescriptionId;
				foreach (var d in item.Descriptions)
				{
					d.Status = request.Descriptions.SingleOrDefault(x => x.Id == d.Id)?.Status ?? d.Status;
				}
				await _uow.SaveEntitiesAsync();
			}
			return Unit.Value;
		}
	}
}
