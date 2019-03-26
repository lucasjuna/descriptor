using Descriptor.Application.Commands.AddSeller;
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
	public class SellersController : ControllerBase
	{
		private readonly ISellerRepository _sellerRepo;
		private readonly IMediator _mediator;

		public SellersController(ISellerRepository sellerRepo, IMediator mediator)
		{
			_sellerRepo = sellerRepo;
			_mediator = mediator;
		}

		[HttpGet]
		public async Task<IList<SellerDto>> Get()
		{
			return await _sellerRepo.All();
		}

		[HttpGet("{userName}")]
		public async Task<ActionResult<SellerDto>> Get(string userName)
		{
			var seller = await _sellerRepo.Find(userName);
			if (seller == null)
				return NotFound();
			else
				return Ok(seller);
		}

		[HttpPost("{userName}")]
		public async Task<ActionResult<SellerDto>> Add(string userName)
		{
			await _mediator.Send(new AddSellerCommand(userName));
			var seller = await _sellerRepo.Find(userName);
			return Ok(seller);
		}
	}
}