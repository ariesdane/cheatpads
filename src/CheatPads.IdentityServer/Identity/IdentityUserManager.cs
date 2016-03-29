using System;
using System.Collections.Generic;
using Microsoft.AspNet.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.OptionsModel;
using Microsoft.AspNet.Identity;

namespace CheatPads.IdentityServer.Identity
{
    public class IdentityUserManager<AppUser> : UserManager<AppUser> where AppUser : class
    {
        public IdentityUserManager(
            IUserStore<AppUser> userStore, 
            IOptions<IdentityOptions> options, 
            IPasswordHasher<AppUser> passwordHasher,
            IEnumerable<IUserValidator<AppUser>> userValidators,
            IEnumerable<IPasswordValidator<AppUser>> passwordValidators,
            ILookupNormalizer keyNormalizer,
            IdentityErrorDescriber errors,
            IServiceProvider services,
            ILogger<UserManager<AppUser>> logger,
            IHttpContextAccessor contextAccessor

        ) : base(userStore, options, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger, contextAccessor)
        {
            // stub class... to be customized later
        }
    }
}
