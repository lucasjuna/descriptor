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
			var item = await _itemRepo.Find(itemId);
			return Ok(item);
		}
	}
}