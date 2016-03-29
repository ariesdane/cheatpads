using System;
using System.Collections.Generic;
using Microsoft.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Threading.Tasks;

namespace CheatPads.IdentityServer.Identity
{
    public class IdentityDbContext : IdentityDbContext<AppUser>
    {
        public new DbSet<AppUser> Users { get; set; }
        public new DbSet<AppUserClaim> UserClaims { get; set; }
        public new DbSet<AppUserLogin> UserLogins { get; set; }
        public new DbSet<AppUserRole> UserRoles { get; set; }
        public new DbSet<AppRole> Roles { get; set; }
        public new DbSet<AppRoleClaim> RoleClaims { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            configureAuthModel(modelBuilder);
        }


        private static void configureAuthModel(ModelBuilder builder)
        {
            builder.Entity<AppUser>().ToTable("User", "Auth");
            builder.Entity<IdentityRole>().ToTable("Role", "Auth");
            builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogin", "Auth");
            builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaim", "Auth");
            builder.Entity<IdentityUserRole<string>>().ToTable("UserRole", "Auth");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaim", "Auth");
        }

        public void EnsureDbExists()
        {
            Database.EnsureCreated();
            IdentitySeedData.EnsureSeeded(this);
        }
    }

}
