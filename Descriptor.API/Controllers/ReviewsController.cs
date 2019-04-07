using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Descriptor.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Descriptor.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
		private readonly IMediator _mediator;

		public ReviewsController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpPut("init-reviewer")]
		public async Task<IActionResult> InitializeReviewer()
		{
			await _mediator.Send(new InitReviewerCommand());
			return Ok();
		}
    }
}