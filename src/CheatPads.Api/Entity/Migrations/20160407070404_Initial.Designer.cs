using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using CheatPads.Api.Entity;

namespace CheatPads.Api.Migrations
{
    [DbContext(typeof(ApiDbContext))]
    [Migration("20160407070404_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CheatPads.Api.Entity.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:Schema", "Sales");

                    b.HasAnnotation("Relational:TableName", "Category");
                });

            modelBuilder.Entity("CheatPads.Api.Entity.Models.Color", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Hex");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:Schema", "Sales");

                    b.HasAnnotation("Relational:TableName", "Color");
                });

            modelBuilder.Entity("CheatPads.Api.Entity.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created");

                    b.Property<double>("ProductCost");

                    b.Property<DateTime>("ShippedOn");

                    b.Property<double>("ShippingCost");

                    b.Property<int>("Status");

                    b.Property<double>("Tax");

                    b.Property<double>("TotalCost");

                    b.Property<string>("TrackingNumber");

                    b.Property<DateTime>("Updated");

                    b.Property<string>("UserId");

                    b.Property<string>("ZipCode");

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:Schema", "Sales");

                    b.HasAnnotation("Relational:TableName", "Order");
                });

            modelBuilder.Entity("CheatPads.Api.Entity.Models.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ColorId");

                    b.Property<double>("ExtendedCost");

                    b.Property<int>("OrderId");

                    b.Property<string>("ProductSku");

                    b.Property<int>("Quantity");

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:Schema", "Sales");

                    b.HasAnnotation("Relational:TableName", "OrderItem");
                });

            modelBuilder.Entity("CheatPads.Api.Entity.Models.Product", b =>
                {
                    b.Property<string>("Sku");

                    b.Property<int>("CategoryId");

                    b.Property<string>("Details");

                    b.Property<string>("Image");

                    b.Property<decimal>("Price");

                    b.Property<string>("Title");

                    b.HasKey("Sku");

                    b.HasAnnotation("Relational:Schema", "Sales");

                    b.HasAnnotation("Relational:TableName", "Product");
                });

            modelBuilder.Entity("CheatPads.Api.Entity.Models.OrderItem", b =>
                {
                    b.HasOne("CheatPads.Api.Entity.Models.Color")
                        .WithMany()
                        .HasForeignKey("ColorId");

                    b.HasOne("CheatPads.Api.Entity.Models.Order")
                        .WithMany()
                        .HasForeignKey("OrderId");

                    b.HasOne("CheatPads.Api.Entity.Models.Product")
                        .WithMany()
                        .HasForeignKey("ProductSku");
                });

            modelBuilder.Entity("CheatPads.Api.Entity.Models.Product", b =>
                {
                    b.HasOne("CheatPads.Api.Entity.Models.Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");
                });
        }
    }
}
