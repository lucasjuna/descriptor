using Descriptor.Application.Dto;
using Descriptor.Application.Services;
using IdentityModel;
using Microsoft.AspNetCore.Http;
using System;
using System.Security.Claims;

namespace Descriptor.API.Service
{
	public class IdentityService : IIdentityService
	{
		private readonly IHttpContextAccessor _httpContextAccessor;

		public IdentityService(IHttpContextAccessor httpContextAccessor)
		{
			_httpContextAccessor = httpContextAccessor;
		}

		public UserDto GetUser()
		{
			return new UserDto
			{
				Id = _httpContextAccessor.HttpContext.User.FindFirstValue(JwtClaimTypes.Subject),
				UserName = _httpContextAccessor.HttpContext.User.FindFirstValue(JwtClaimTypes.Name),
				Email = _httpContextAccessor.HttpContext.User.FindFirstValue(JwtClaimTypes.Email),
				FirstName = _httpContextAccessor.HttpContext.User.FindFirstValue(JwtClaimTypes.GivenName),
				LastName = _httpContextAccessor.HttpContext.User.FindFirstValue(JwtClaimTypes.FamilyName),
				EmployeeId = _httpContextAccessor.HttpContext.User.FindFirstValue("employee_id"),
				LoginTime = DateTimeOffset.FromUnixTimeSeconds(long.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(JwtClaimTypes.AuthenticationTime))).UtcDateTime,
			};
		}
	}
}
