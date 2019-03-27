using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Descriptor.Application.Commands.LoadItems
{
	public class LoadItemsCommand : IRequest
	{
		public string UserName { get; }

		public LoadItemsCommand(string userName)
		{
			UserName = userName;
		}
	}
}
