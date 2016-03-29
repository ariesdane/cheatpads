using IdentityServer4.Core.Validation;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheatPads.IdentityServer.Identity
{
    // http://stackoverflow.com/questions/35304038/identityserver4-register-userservice-and-get-users-from-database-in-asp-net-core/

    public class IdentityResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        private readonly IdentityUserManager<AppUser> _userManager;

        public IdentityResourceOwnerPasswordValidator(IdentityUserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        async public Task<CustomGrantValidationResult> ValidateAsync(string userName, string password, ValidatedTokenRequest request)
        {
            var user = await _userManager.FindByNameAsync(userName);
            if (user != null && await _userManager.CheckPasswordAsync(user, password))
                return new CustomGrantValidationResult(user.Id, "password");

            return new CustomGrantValidationResult("Invalid username or password");
        }
    }
}
