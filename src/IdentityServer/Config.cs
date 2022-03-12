﻿// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace IdentityServer
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            { 
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            { };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                new Client
                {
                    ClientId = "wasmappauth-client",
                    ClientName = "Blazor Webassembly App Client",
                    RequireClientSecret = false,

                    AllowedGrantTypes = GrantTypes.Code,
                    RequirePkce = true,

                    AllowedCorsOrigins = { "https://localhost:5015" },
                    RedirectUris = { "https://localhost:5015/authentication/login-callback" },
                    PostLogoutRedirectUris = { "https://localhost:5015/authentication/logout-callback" },

                    AllowedScopes = {"openid", "profile"},
                },

                // WebForm Client
                new Client
                {
                    ClientId = "WebForm",
                    ClientName = "WebForm Client",
                    AllowedGrantTypes = GrantTypes.Code,
                    RequireClientSecret = false,

                    RedirectUris =           { "https://localhost:44360/Login.aspx?callback=1" },
                    PostLogoutRedirectUris = { "https://localhost:44360/Login.aspx" },
                    AllowedCorsOrigins =     { "https://localhost:44360" },

                    AllowedScopes =
                    {
                        "openid", "profile"
                    }
                },

                // JavaScript Client
                new Client
                {
                    ClientId = "js",
                    ClientName = "JavaScript Client",
                    AllowedGrantTypes = GrantTypes.Code,
                    RequireClientSecret = false,

                    RedirectUris =           { "https://localhost:5003/callback.html" },
                    PostLogoutRedirectUris = { "https://localhost:5003/index.html" },
                    AllowedCorsOrigins =     { "https://localhost:5003" },

                    AllowedScopes =
                    {
                        "openid", "profile"
                    }
                }
            };
    }
}