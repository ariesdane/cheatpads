namespace IdentityServerAspNet5WithIdentity.Configuration
{
    using System.Collections.Generic;
    using System.Security.Claims;

    using IdentityServer4.Core;
    using IdentityServer4.Core.Services.InMemory;

    static class Users
    {
        public static List<InMemoryUser> Get()
        {
            var users = new List<InMemoryUser>
            {
                new InMemoryUser{Subject = "48421155", Username = "Admin", Password = "Admin.2",
                    Claims = new Claim[]
                    {
                        new Claim(Constants.ClaimTypes.Name, "Aries"),
                        new Claim(Constants.ClaimTypes.GivenName, "Aries Dane"),
                        new Claim(Constants.ClaimTypes.Email, "ariesdane@hotmail.com"),
                        new Claim(Constants.ClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                        new Claim(Constants.ClaimTypes.Role, "Administrator"),
                        new Claim(Constants.ClaimTypes.Role, "Developer")
                    }
                },
                new InMemoryUser{Subject = "48421156", Username = "damienbod", Password = "damienbod",
                    Claims = new Claim[]
                    {
                        new Claim(Constants.ClaimTypes.Name, "damienbod"),
                        new Claim(Constants.ClaimTypes.GivenName, "damienbod"),
                        new Claim(Constants.ClaimTypes.Email, "damien_bod@hotmail.com"),
                        new Claim(Constants.ClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                        new Claim(Constants.ClaimTypes.Role, "Developer")
                    }
                }
            };

            return users;
        }
    }
}