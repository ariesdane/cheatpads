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

                // API - access token will 
                // contain roles of user
                new Scope
                {
                    Name = "CheatPads.Api",
                    DisplayName = "CheatPads API Resource Scope",
                    Type = ScopeType.Resource,
                    IncludeAllClaimsForUser = true,
                    Claims = new List<ScopeClaim>
                    {
                        new ScopeClaim("role")
                    }
                }
            };
        }
    }
}