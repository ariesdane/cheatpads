using System;
using System.Collections.Generic;
using Microsoft.AspNet.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.OptionsModel;
using Microsoft.AspNet.Identity;

namespace CheatPads.IdentityServer.Identity
{
    public class IdentityRoleManager : RoleManager<AppRole>
    {
        public IdentityRoleManager(
            IRoleStore<AppRole> roleStore,
            IEnumerable<IRoleValidator<AppRole>> roleValidators,
            ILookupNormalizer keyNormalizer,
            IdentityErrorDescriber errors,
            ILogger<RoleManager<AppRole>> logger,
            IHttpContextAccessor contextAccessor
        ) : base( roleStore, roleValidators, keyNormalizer, errors, logger, contextAccessor)
        {

        }
    }
}
