using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using CheatPads.Api.Data;

namespace CheatPads.Api.Migrations
{
    [DbContext(typeof(ApiDbContext))]
    [Migration("20160403055118_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CheatPads.Api.Data.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:Schema", "Sales");

                    b.HasAnnotation("Relational:TableName", "Category");
                });

            modelBuilder.Entity("CheatPads.Api.Data.Models.Product", b =>
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

            modelBuilder.Entity("CheatPads.Api.Data.Models.Product", b =>
                {
                    b.HasOne("CheatPads.Api.Data.Models.Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");
                });
        }
    }
}
