using Descriptor.Application.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Descriptor.Application.Commands.LoadItems
{
	public class LoadItemsCommand : IRequest<ReviewsResultDto>
	{
		public string UserName { get; }

		public LoadItemsCommand(string userName)
		{
			UserName = userName;
		}
	}
}
