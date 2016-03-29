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
                new InMemoryUser{Subject = "48421155", Username = "Admin", Password = "Admin.1",
                    Claims = new Claim[]
                    {
                        new Claim(JwtClaimTypes.Name, "Aries"),
                        new Claim(JwtClaimTypes.GivenName, "Aries Dane"),
                        new Claim(JwtClaimTypes.Email, "ariesdane@hotmail.com"),
                        new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                        new Claim(JwtClaimTypes.Role, "Administrator"),
                        new Claim(JwtClaimTypes.Role, "Developer")
                    }
                },
                new InMemoryUser{Subject = "48421156", Username = "damienbod", Password = "damienbod",
                    Claims = new Claim[]
                    {
                        new Claim(JwtClaimTypes.Name, "damienbod"),
                        new Claim(JwtClaimTypes.GivenName, "damienbod"),
                        new Claim(JwtClaimTypes.Email, "damien_bod@hotmail.com"),
                        new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                        new Claim(JwtClaimTypes.Role, "Developer")
                    }
                },
                new InMemoryUser{Subject = "48421157", Username = "johndoe", Password = "John.1",
                    Claims = new Claim[]
                    {
                        new Claim(JwtClaimTypes.Name, "johndoe"),
                        new Claim(JwtClaimTypes.GivenName, "John Doe"),
                        new Claim(JwtClaimTypes.Email, "john@teacher.com"),
                        new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                        new Claim(JwtClaimTypes.Role, "Teacher"),
                        new Claim(JwtClaimTypes.Role, "Webmaster")
                    }
                },
                new InMemoryUser{Subject = "48421158", Username = "janedoe", Password = "Jane.1",
                    Claims = new Claim[]
                    {
                        new Claim(JwtClaimTypes.Name, "janedoe"),
                        new Claim(JwtClaimTypes.GivenName, "Jane Doe"),
                        new Claim(JwtClaimTypes.Email, "jane@student.com"),
                        new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                        new Claim(JwtClaimTypes.Role, "Student")
                    }
                }
            };

            return users;
        }
    }
}