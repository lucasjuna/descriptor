using System;

namespace Descriptor.Application.Dto.Ebay
{
	public class UserInfo
	{
		public string UserName { get; set; }
		public string Email { get; set; }
		public DateTime RegistrationDate { get; set; }
		public AddressInfo RegistrationAddress { get; set; }
	}
}
