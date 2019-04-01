using Descriptor.Application.Commands.LoadItems;
using Descriptor.Domain.Dto;
using Descriptor.Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Descriptor.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ItemsController : ControllerBase
	{
		private readonly IMediator _mediator;
		private readonly IItemRepository _itemRepo;

		public ItemsController(IMediator mediator, IItemRepository itemRepo)
		{
			_mediator = mediator;
			_itemRepo = itemRepo;
		}

		[HttpPut("{userName}")]
		public async Task<ActionResult<SellerDto>> LoadItems(string userName)
		{
			var result = await _mediator.Send(new LoadItemsCommand(userName));

			return Ok(result);
		}

		[HttpGet("{userName}")]
		public async Task<ActionResult<IList<ItemDto>>> Get(string userName)
		{
			var result = await _itemRepo.Find(userName);
			return Ok(result);
		}
	}
}