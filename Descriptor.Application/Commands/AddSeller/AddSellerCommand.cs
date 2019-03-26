using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Descriptor.Application.Commands.AddSeller
{
	public class AddSellerCommand : IRequest
	{
		public string UserName { get; }

		public AddSellerCommand(string userName)
		{
			UserName = userName;
		}
	}
}
