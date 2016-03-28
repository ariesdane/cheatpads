﻿namespace IdentityServerAspNet5.Configuration
{
    using System.Collections.Generic;

    using IdentityServer4.Core.Models;

    public class Clients
    {
        public static List<Client> Get()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientName = "angularclient",
                    ClientId = "angularclient",
                    Flow = Flows.Implicit,
                    RedirectUris = new List<string>
                    {
                        "https://localhost:44347/identitytestclient.html",
                        "https://localhost:44347/authorized"

                    },
                    PostLogoutRedirectUris = new List<string>
                    {
                        "https://localhost:44347/identitytestclient.html",
                        "https://localhost:44347/authorized"
                    },
                    AllowedScopes = new List<string>
                    {
                        "openid",
                        "email",
                        "profile",
                        "userEvents"
                    },
                    RequireConsent = false

                },
                new Client
                {
                    ClientName = "CheatPads.com",
                    ClientId = "CheatPads.Web",
                    Flow = Flows.Implicit,
                    RedirectUris = new List<string>
                    {
                        "http://localhost:61739/",
                        "https://localhost:44327/"
                    },
                    PostLogoutRedirectUris = new List<string>
                    {
                        "http://localhost:61739/",
                        "https://localhost:44327/"
                    },
                    AllowedScopes = new List<string>
                    {
                        "openid",
                        "email",
                        "profile",
                        "userEvents"
                    }
                },
                new Client
                {
                    ClientName = "MVC6 Demo Client from Identity",
                    ClientId = "mvc6",
                    Flow = Flows.Implicit,
                    RedirectUris = new List<string>
                    {
                        "http://localhost:2221/",
                    },
                    PostLogoutRedirectUris = new List<string>
                    {
                        "http://localhost:2221/",
                    },
                    AllowedScopes = new List<string>
                    {
                        "openid",
                        "email",
                        "profile",
                        "userEvents"
                    }
                }
            };
        }
    }
}