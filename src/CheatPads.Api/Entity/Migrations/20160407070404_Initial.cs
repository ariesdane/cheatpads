using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Metadata;

namespace CheatPads.Api.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema("Sales");
            migrationBuilder.CreateTable(
                name: "Category",
                schema: "Sales",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });
            migrationBuilder.CreateTable(
                name: "Color",
                schema: "Sales",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Hex = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Color", x => x.Id);
                });
            migrationBuilder.CreateTable(
                name: "Order",
                schema: "Sales",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(nullable: false),
                    ProductCost = table.Column<double>(nullable: false),
                    ShippedOn = table.Column<DateTime>(nullable: false),
                    ShippingCost = table.Column<double>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Tax = table.Column<double>(nullable: false),
                    TotalCost = table.Column<double>(nullable: false),
                    TrackingNumber = table.Column<string>(nullable: true),
                    Updated = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    ZipCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                });
            migrationBuilder.CreateTable(
                name: "Product",
                schema: "Sales",
                columns: table => new
                {
                    Sku = table.Column<string>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false),
                    Details = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Sku);
                    table.ForeignKey(
                        name: "FK_Product_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "Sales",
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "OrderItem",
                schema: "Sales",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ColorId = table.Column<int>(nullable: false),
                    ExtendedCost = table.Column<double>(nullable: false),
                    OrderId = table.Column<int>(nullable: false),
                    ProductSku = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItem_Color_ColorId",
                        column: x => x.ColorId,
                        principalSchema: "Sales",
                        principalTable: "Color",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItem_Order_OrderId",
                        column: x => x.OrderId,
                        principalSchema: "Sales",
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItem_Product_ProductSku",
                        column: x => x.ProductSku,
                        principalSchema: "Sales",
                        principalTable: "Product",
                        principalColumn: "Sku",
                        onDelete: ReferentialAction.Restrict);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "OrderItem", schema: "Sales");
            migrationBuilder.DropTable(name: "Color", schema: "Sales");
            migrationBuilder.DropTable(name: "Order", schema: "Sales");
            migrationBuilder.DropTable(name: "Product", schema: "Sales");
            migrationBuilder.DropTable(name: "Category", schema: "Sales");
        }
    }
}
