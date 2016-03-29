using System;
using System.Collections.Generic;
using Microsoft.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Threading.Tasks;
using CheatPads.Data.Models;

namespace CheatPads.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            configureCommerceModel(modelBuilder);
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

            SeedData.ProductData.EnsureSeeded(this);
        }
    }

}
