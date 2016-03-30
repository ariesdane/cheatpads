namespace CheatPads.IdentityServer.Configuration
{
    using System.Collections.Generic;
    using System.Security.Claims;
    using IdentityModel;
    using IdentityServer4.Core;
    using IdentityServer4.Core.Services.InMemory;

    static class Users
    {
        public static List<InMemoryUser> Get()
        {
            var users = new List<InMemoryUser>
            { 
                new InMemoryUser
                {
                    Subject = "AFCF7980-4BA7-4DD2-879D-599D058F7E73",
                    Username = "Admin",
                    Password = "Admin.1",
                    Claims = new Claim[]
                    {
                        new Claim(JwtClaimTypes.Name, "Aries"),
                        new Claim(JwtClaimTypes.GivenName, "Aries Dane"),
                        new Claim(JwtClaimTypes.Email, "admin@cheatpads.com"),
                        new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                        new Claim(JwtClaimTypes.Role, "admin"),
                        new Claim(JwtClaimTypes.Role, "user"),
                    }
                },
                new InMemoryUser
                {
                    Subject = "EECEFCC1-8050-4A0F-A5A5-D7ED19A078A8",
                    Username = "John",
                    Password = "John.1",
                    Claims = new Claim[]
                    {
                        new Claim(JwtClaimTypes.Name, "John"),
                        new Claim(JwtClaimTypes.GivenName, "John Doe"),
                        new Claim(JwtClaimTypes.Email, "john@cheatpads.com"),
                        new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                        new Claim(JwtClaimTypes.Role, "customer"),
                        new Claim(JwtClaimTypes.Role, "user")
                    }
                },
                new InMemoryUser
                {
                    Subject = "13B2D0D1-F8A6-487E-9D60-A1E89DCC610B",
                    Username = "Jane",
                    Password = "Jane.1",
                    Claims = new Claim[]
                    {
                        new Claim(JwtClaimTypes.Name, "Jane"),
                        new Claim(JwtClaimTypes.GivenName, "Jane Doe"),
                        new Claim(JwtClaimTypes.Email, "jane@cheatpads.com"),
                        new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                        new Claim(JwtClaimTypes.Role, "manager"),
                        new Claim(JwtClaimTypes.Role, "user")
                    }
                }
            };

            return users;
        }
    }
}