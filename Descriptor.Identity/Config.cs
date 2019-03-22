// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;
using System.Security.Claims;

namespace Descriptor.Identity
{
	public static class Config
	{
		public static IEnumerable<IdentityResource> GetIdentityResources()
		{
			return new IdentityResource[]
			{
				new IdentityResources.OpenId(),
				new IdentityResources.Profile(),
			};
		}

		public static IEnumerable<ApiResource> GetApis()
		{
			return new ApiResource[]
			{
				new ApiResource("descriptor", "Descriptor")
				{
					UserClaims = { ClaimTypes.Role }
				}
			};
		}

		public static IEnumerable<Client> GetClients()
		{
			return new[]
			{
				new Client
				{
					ClientId = "js",
					ClientName = "JS Client",
					AllowedGrantTypes = GrantTypes.Implicit,
					AllowAccessTokensViaBrowser = true,
					AccessTokenLifetime = 120000,
					RedirectUris =
					{
						"http://localhost:3000/callback",
						"http://localhost:3000/silent-renew",
						"http://localhost:8080/callback",
						"http://localhost:8080/silent-renew"
					},
					RequireConsent = false,
					PostLogoutRedirectUris =
					{
						"http://localhost:3000/",
						"http://localhost:8080/"
					},
					AllowedCorsOrigins = {
						"http://localhost:3000",
						"http://localhost:8080"
					},
					AllowedScopes =
					{
						IdentityServerConstants.StandardScopes.OpenId,
						IdentityServerConstants.StandardScopes.Profile,
						"descriptor",
					}
				}
			};
		}
	}
}
