using Descriptor.Application.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Descriptor.Application.Services
{
	public interface IIdentityService
	{
		UserDto GetUser();
	}
}
