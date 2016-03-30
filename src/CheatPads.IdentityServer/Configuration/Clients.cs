namespace CheatPads.IdentityServer.Configuration
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
                    ClientName = "CheatPads.com",
                    ClientId = "CheatPads.Clients.Web",
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
                        "CheatPads.Api"
                    }
                },
                new Client
                {
                    ClientName = "CheatPads Console Client",
                    ClientId = "CheatPads.Clients.Console",
                    ClientSecrets = new List<Secret>()
                    {
                        new Secret("D7014A72BB75E3C")
                    },
                    Flow = Flows.ClientCredentials,
                    AllowClientCredentialsOnly = true,
                    AllowedScopes = new List<string>
                    {
                        "openid",
                        "email",
                        "profile",
                        "CheatPads.Api"
                    }
                },
                new Client
                {
                    ClientName = "CheatPads MVC Client",
                    ClientId = "CheatPads.Clients.MVC",
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
                        "CheatPads.Api"
                    }
                }
            };
        }
    }
}