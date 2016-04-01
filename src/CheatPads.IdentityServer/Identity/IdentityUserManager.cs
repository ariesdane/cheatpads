using System;
using System.Collections.Generic;
using Microsoft.AspNet.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.OptionsModel;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;

namespace CheatPads.IdentityServer.Identity
{
    public class IdentityUserManager : UserManager<AppUser>
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


        public override async Task<bool> CheckPasswordAsync(AppUser user , string password)
        {
            // developers can user plain text passwords for test
            if (user != null && user.PasswordHash.EndsWith("||0")) { 
                return (user.PasswordHash == password + "||0");
            }

            // otherwise use base method to validate against hashed passwords
            return await base.CheckPasswordAsync(user, password);
        }
    }
}
