using Descriptor.Application.Commands.LoadItems;
using Descriptor.Domain.Dto;
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

		public ItemsController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpPut("{userName}")]
		public async Task<ActionResult<SellerDto>> LoadItems(string userName)
		{
			var result = await _mediator.Send(new LoadItemsCommand(userName));

			return Ok(result);
		}
	}
}