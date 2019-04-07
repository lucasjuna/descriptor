using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Descriptor.Application.Commands;
using Descriptor.Domain.Dto;
using Descriptor.Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Descriptor.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewersController : ControllerBase
	{
		private readonly IMediator _mediator;
		private readonly IReviewerRepository _reviewerRepo;

		public ReviewersController(IMediator mediator, IReviewerRepository reviewerRepo)
		{
			_mediator = mediator;
			_reviewerRepo = reviewerRepo;
		}

		[HttpPut("init-reviewer")]
		public async Task<IActionResult> InitializeReviewer()
		{
			await _mediator.Send(new InitReviewerCommand());
			return Ok();
		}

		[HttpGet]
		public async Task<ActionResult<IList<ReviewerDto>>> GetAll()
		{
			var reviewers = await _reviewerRepo.All();
			return Ok(reviewers);
		}
	}
}