using System;
using System.Collections.Generic;
using Microsoft.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Threading.Tasks;
using CheatPads.Api.Entity.Models;

namespace CheatPads.Api.Entity
{
    public class ApiDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Color> Colors { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            configureProductModel(modelBuilder);
            configureOrderModel(modelBuilder);
        }


        private static void configureProductModel(ModelBuilder builder)
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

        private static void configureOrderModel(ModelBuilder builder)
        {
            builder.Entity<Order>(entity =>
            {
                entity
                    .ToTable("Order", "Sales")
                    .HasKey(x => x.Id);

                entity
                    .Property(x => x.Id)
                    .UseSqlServerIdentityColumn(); 

                entity
                    .HasMany<OrderItem>(x => x.Items)
                    .WithOne(x => x.Order)
                    .HasForeignKey(x => x.OrderId);           
            });

            builder.Entity<OrderItem>(entity =>
            {
                entity
                    .ToTable("OrderItem", "Sales")
                    .HasKey(x => x.Id);
                    
                entity
                   .Property(x => x.Id)
                   .UseSqlServerIdentityColumn();

                //entity
                //    .HasAlternateKey(x => new { x.OrderId, x.ProductSku, x.ColorId });
                //    .ForSqlServerIsClustered();


                entity
                    .HasOne(x => x.Color)
                    .WithMany()
                    .HasForeignKey(x => x.ColorId);

                entity
                    .HasOne(x => x.Product)
                    .WithMany()
                    .HasForeignKey(x => x.ProductSku);
            });

            builder.Entity<Color>(entity =>
            {
                entity
                    .ToTable("Color", "Sales")
                    .HasKey(x => x.Id);

            });
        }

        public void EnsureDbExists()
        {
            Database.Migrate();
            ApiData.EnsureSeeded(this);
        }
    }

}
