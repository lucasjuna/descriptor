using Descriptor.Application.Commands;
using Descriptor.Domain.Dto;
using Descriptor.Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;
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

		[HttpGet("{itemId}")]
		public async Task<ActionResult<ItemDto>> Get(string itemId)
		{
			var item = await _itemRepo.FindDto(itemId);
			if (item == null)
				return NotFound();
			return Ok(item);
		}

		[HttpPut("{itemId}")]
		public async Task<IActionResult> Put([FromRoute] string itemId, [FromBody]ItemDto item)
		{
			await _mediator.Send(new ReviewItemCommand(item.ItemId, item.DescriptionId, item.ItemStatus,
				item.ImagesStatus, item.PriceStatus, item.Descriptions));
			return Ok();
		}

		[HttpGet("{itemId}/descriptions/{descriptionId}")]
		public async Task<ActionResult<ItemDto>> Get(string itemId, long descriptionId)
		{
			var description = await _itemRepo.FindDescription(itemId, descriptionId);
			if (description == null)
				return NotFound();
			return Ok(description);
		}
	}
}