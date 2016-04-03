namespace CheatPads.IdentityServer.Configuration
{
    using System.Collections.Generic;

    using IdentityServer4.Core.Models;

    public class Scopes
    {
        public static IEnumerable<Scope> Get()
        {
            return new[]
            {
                // standard OpenID Connect scopes
                StandardScopes.OpenId,
                StandardScopes.ProfileAlwaysInclude,
                StandardScopes.EmailAlwaysInclude,
                StandardScopes.RolesAlwaysInclude,

                // API - access token will 
                // contain roles of user
                new Scope
                {
                    Name = "CheatPads.Api",
                    DisplayName = "CheatPads Store API",
                    Type = ScopeType.Resource,
                    IncludeAllClaimsForUser = true,
                    Required = true
                },
                new Scope
                {
                    Name = "CheatPads.Identity",
                    DisplayName = "CheatPads Identity Api",
                    Type = ScopeType.Identity,
                    IncludeAllClaimsForUser = true,
                    Required = true
                },
                new Scope
                {
                    Name = "CheatPads.Wallet",
                    DisplayName = "CheatPads Wallet Api",
                    Type = ScopeType.Resource,
                    IncludeAllClaimsForUser = true,
                }
            };
        }
    }
}