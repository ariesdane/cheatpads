using System;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CheatPads.IdentityServer.Identity
{

    public class AppUser : IdentityUser
    {
        // extend IdentityUser as needed
        public string DisplayName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get{ return FirstName + " " + LastName; }
        }
        public string Gender { get; set; } = "U";

        public DateTime? BirthDate { get; set; }

        public AppUser()
        {
            Id = Guid.NewGuid().ToString();
        }
    }

    public class AppRole : IdentityRole
    {

    }

    public class AppRoleClaim : IdentityRoleClaim<string>
    {

    }

    public class AppUserRole : IdentityUserRole<string>
    {

    }

    public class AppUserClaim : IdentityUserClaim<string>
    {

    }

    public class AppUserLogin : IdentityUserLogin<string>
    {

    }
}
