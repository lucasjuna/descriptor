using System;

namespace Descriptor.Infrastructure.Responses
{
	public class UserInfo
	{
		public string UserID { get; set; }
		public string Email { get; set; }
		public DateTime RegistrationDate { get; set; }
		public AddressInfo RegistrationAddress { get; set; }
	}
}
