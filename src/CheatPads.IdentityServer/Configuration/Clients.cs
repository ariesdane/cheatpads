using IdentityModel;
using System.Collections.Generic;
using System.Security.Claims;
using IdentityServer4.Core.Models;


namespace CheatPads.IdentityServer.Configuration
{
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
                        "CheatPads.Api",
                        "CheatPads.Identity",
                        "CheatPads.Wallet"
                    }
                },
                new Client
                {
                    ClientName = "CheatPads Console Client",
                    ClientId = "CheatPads.Clients.Console",
                    ClientSecrets = new List<Secret>()
                    {
                        new Secret("D7014A72BB75E3C".Sha256())
                    },
                    Claims = new List<Claim>()
                    {
                        new Claim(JwtClaimTypes.Role, "TrustedApps")
                    },
                    Flow = Flows.ClientCredentials,
                    AllowClientCredentialsOnly = true,
                    AllowAccessToAllCustomGrantTypes = true,
                    AllowedScopes = new List<string>
                    {
                        "openid",
                        "email",
                        "profile",
                        "CheatPads.Api",
                        "CheatPads.Identity",
                        "CheatPads.Wallet"
                    }
                },
                new Client
                {
                    ClientName = "CheatPads Console Client",
                    ClientId = "CheatPads.Clients.Console.User",
                    ClientSecrets = new List<Secret>()
                    {
                        new Secret("D7014A72BB75E3C".Sha256())
                    },
                    Flow = Flows.ResourceOwner,
                    AllowedScopes = new List<string>
                    {
                        "openid",
                        "email",
                        "profile",
                        "CheatPads.Api",
                        "CheatPads.Identity",
                        "CheatPads.Wallet"
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
                        "CheatPads.Api",
                        "CheatPads.Identity",
                        "CheatPads.Wallet"
                    }
                }
            };
        }
    }
}