namespace CheatPads.IdentityServer.Configuration
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
                new InMemoryUser{Subject = "48421155", Username = "Admin", Password = "Admin.1",
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
                },
                new InMemoryUser{Subject = "48421157", Username = "johndoe", Password = "John.1",
                    Claims = new Claim[]
                    {
                        new Claim(Constants.ClaimTypes.Name, "johndoe"),
                        new Claim(Constants.ClaimTypes.GivenName, "John Doe"),
                        new Claim(Constants.ClaimTypes.Email, "john@teacher.com"),
                        new Claim(Constants.ClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                        new Claim(Constants.ClaimTypes.Role, "Teacher"),
                        new Claim(Constants.ClaimTypes.Role, "Webmaster")
                    }
                },
                new InMemoryUser{Subject = "48421158", Username = "janedoe", Password = "Jane.1",
                    Claims = new Claim[]
                    {
                        new Claim(Constants.ClaimTypes.Name, "janedoe"),
                        new Claim(Constants.ClaimTypes.GivenName, "Jane Doe"),
                        new Claim(Constants.ClaimTypes.Email, "jane@student.com"),
                        new Claim(Constants.ClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                        new Claim(Constants.ClaimTypes.Role, "Student")
                    }
                }
            };

            return users;
        }
    }
}