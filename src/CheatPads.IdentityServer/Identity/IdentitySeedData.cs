using System;
using System.Linq;

namespace CheatPads.IdentityServer.Identity
{
    public static class IdentitySeedData
    {

        public static void EnsureSeeded(IdentityDbContext db)
        {
            var userId_Admin = "AFCF7980-4BA7-4DD2-879D-599D058F7E73";
            var userId_Jane = "EECEFCC1-8050-4A0F-A5A5-D7ED19A078A8";
            var userId_Joe = "13B2D0D1-F8A6-487E-9D60-A1E89DCC610B";

            if (!db.Roles.Any())
            {
                db.Roles.AddRange(new AppRole[] {
                    new AppRole() { Id = "admin", Name = "Administrators" },
                    new AppRole() { Id = "customer", Name = "Customers" },
                    new AppRole() { Id = "user", Name = "Valid Users" }
                });
            }


            if (!db.Users.Any())
            {
                db.Users.AddRange(new AppUser[] {
                    new AppUser()
                    {
                        Id = userId_Admin,
                        Email = "admin@admin.com",
                        NormalizedEmail = "admin@admin.com",
                        DisplayName = "Admin",
                        UserName = "admin",
                        EmailConfirmed = true,
                        PasswordHash = "admin||0", //pwd/salt/format 
                    },
                    new AppUser()
                    {
                        Id = userId_Joe,
                        Email = "joe@cheatpads.com",
                        NormalizedEmail = "joe@cheatpads.com",
                        DisplayName = "Joe",
                        UserName = "joe",
                        EmailConfirmed = true,
                        PasswordHash = "joe||0", //pwd/salt/format 
                    },
                    new AppUser()
                    {
                        Id = userId_Jane,
                        Email = "jane@cheatpads.com",
                        NormalizedEmail = "jane@cheatpads.com",
                        DisplayName = "Jane",
                        UserName = "jane",
                        EmailConfirmed = true,
                        PasswordHash = "jane||0", //pwd/salt/format 
                    }
                });

            }
            db.SaveChanges();

            if (!db.UserRoles.Any())
            {
                db.UserRoles.AddRange(new AppUserRole[]{
                    new AppUserRole() { UserId = userId_Admin, RoleId = "admin" },
                    new AppUserRole() { UserId = userId_Admin, RoleId = "user" },
                    new AppUserRole() { UserId = userId_Joe, RoleId = "user" },
                    new AppUserRole() { UserId = userId_Joe, RoleId = "customer" },
                    new AppUserRole() { UserId = userId_Jane, RoleId = "user" },
                    new AppUserRole() { UserId = userId_Jane, RoleId = "customer" },
                });
            }
            db.SaveChanges();
        }
    }
}
