using System;
using System.Linq;

namespace CheatPads.IdentityServer.Identity
{
    public static class IdentityData
    {

        public static void EnsureSeeded(IdentityDbContext db)
        {
            var userId_Admin = "AFCF7980-4BA7-4DD2-879D-599D058F7E73";
            var userId_Jane = "EECEFCC1-8050-4A0F-A5A5-D7ED19A078A8";
            var userId_Joe = "13B2D0D1-F8A6-487E-9D60-A1E89DCC610B";

            if (!db.Roles.Any())
            {
                db.Roles.AddRange(new AppRole[] {
                    new AppRole() { Id = "admin", Name = "Administrator" },
                    new AppRole() { Id = "customer", Name = "Customer" },
                    new AppRole() { Id = "manager", Name = "Product Manager" },
                    new AppRole() { Id = "user", Name = "Valid User" }
                });
            }

            if (!db.Users.Any())
            {
                db.Users.AddRange(new AppUser[] {
                    new AppUser()
                    {
                        Id = userId_Admin,
                        UserName = "admin",
                        Email = "admin@admin.com",
                        NormalizedEmail = "admin@admin.com",
                        EmailConfirmed = true,
                        FirstName = "Aries",
                        LastName = "Dane",
                        DisplayName = "Aries",
                        Gender = "M",
                        PasswordHash = "admin||0", //pwd/salt/format 
                    },
                    new AppUser()
                    {
                        Id = userId_Joe,
                        UserName = "john",
                        Email = "john@cheatpads.com",
                        NormalizedEmail = "john@cheatpads.com",
                        EmailConfirmed = true,
                        FirstName = "John",
                        LastName = "Doe",
                        DisplayName = "John D",
                        Gender = "M",
                        PasswordHash = "joe||0", //pwd/salt/format 
                    },
                    new AppUser()
                    {
                        Id = userId_Jane,
                        UserName = "jane",
                        Email = "jane@cheatpads.com",
                        NormalizedEmail = "jane@cheatpads.com",
                        EmailConfirmed = true,
                        FirstName = "Jane",
                        LastName = "Doe",
                        DisplayName = "Jane D",
                        Gender = "F",
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
                    new AppUserRole() { UserId = userId_Joe, RoleId = "customer" },
                    new AppUserRole() { UserId = userId_Joe, RoleId = "user" },
                    new AppUserRole() { UserId = userId_Jane, RoleId = "manager" },
                    new AppUserRole() { UserId = userId_Jane, RoleId = "user" },
                });
            }
            db.SaveChanges();
        }
    }
}
