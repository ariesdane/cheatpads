using System;
using System.Collections.Generic;
using Microsoft.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Threading.Tasks;
using CheatPads.Data.Models;

namespace CheatPads.Data
{
    public class DataContext : IdentityDbContext<AppUser>
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public new DbSet<AppUser> Users { get; set; }
        public new DbSet<AppUserClaim> UserClaims { get; set; }
        public new DbSet<AppUserLogin> UserLogins { get; set; }
        public new DbSet<AppUserRole> UserRoles { get; set; }
        public new DbSet<AppRole> Roles { get; set; }
        public new DbSet<AppRoleClaim> RoleClaims { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            configureAuthModel(modelBuilder);
            configureCommerceModel(modelBuilder);
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

        private static void configureCommerceModel(ModelBuilder builder)
        {
            builder.Entity<Category>(entity =>
            {
                entity
                    .ToTable("Category", "Sales")
                    .HasKey(cat => cat.Id);

                entity
                    .HasMany<Product>(cat => cat.Products);
            });

            builder.Entity<Product>(entity =>
            {
                entity
                    .ToTable("Product", "Sales")
                    .HasKey(prod => prod.Sku);

                entity
                    .HasOne<Category>(prod => prod.Category)
                    .WithMany(cat => cat.Products)
                    .HasForeignKey(prod => prod.CategoryId);
            });
        }


        public void EnsureDbExists()
        {
            Database.EnsureCreated();

            SeedData.AuthData.EnsureSeeded(this);
            SeedData.ProductData.EnsureSeeded(this);
        }
    }

}
