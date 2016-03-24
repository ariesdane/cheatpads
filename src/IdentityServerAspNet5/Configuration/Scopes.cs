﻿namespace IdentityServerAspNet5.Configuration
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
                    Name = "userEvents",
                    DisplayName = "User Event Records Scope",
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