﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Descriptor.Application.Dto
{
	public class UserDto
	{
		public string Id { get; set; }
		public string UserName { get; set; }
		public string Email { get; set; }
		public string EmployeeId { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public DateTime LoginTime { get; set; }
	}
}
