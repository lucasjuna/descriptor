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
    public class ItemReviewsController : ControllerBase
    {
		private readonly IMediator _mediator;

		public ItemReviewsController(IMediator mediator)
		{
			_mediator = mediator;
		}
    }
}