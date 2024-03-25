﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ApiSln.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ParentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Priorty = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BrandId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Details",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Details", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Details_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CategoryProduct",
                columns: table => new
                {
                    CategoriesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryProduct", x => new { x.CategoriesId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_CategoryProduct_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryProduct_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "CreateDate", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { new Guid("3d403e8f-6634-47c1-869e-803e27ea5c50"), new DateTime(2024, 3, 25, 23, 26, 31, 12, DateTimeKind.Local).AddTicks(4261), null, "Music, Beauty & Electronics" },
                    { new Guid("6e3e8ed0-1300-4dfa-8855-25724576c837"), new DateTime(2024, 3, 25, 23, 26, 31, 12, DateTimeKind.Local).AddTicks(3929), null, "Industrial" },
                    { new Guid("7e7ed1a0-670f-4b2f-8e55-e79f6f71aca6"), new DateTime(2024, 3, 25, 23, 26, 31, 12, DateTimeKind.Local).AddTicks(4281), null, "Industrial, Books & Sports" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreateDate", "ModifiedDate", "Name", "ParentId", "Priorty" },
                values: new object[,]
                {
                    { new Guid("2dbc5f92-fa5c-4b2e-b6d2-b22cde7a5e3a"), new DateTime(2024, 3, 25, 23, 26, 31, 12, DateTimeKind.Local).AddTicks(7191), null, "Moda", new Guid("11111111-1111-1111-1111-111111111111"), 2 },
                    { new Guid("6ebed990-84e9-44fa-b36e-f124e14a0118"), new DateTime(2024, 3, 25, 23, 26, 31, 12, DateTimeKind.Local).AddTicks(7201), null, "Bilgisayar", new Guid("8765ef17-5245-4499-b6bd-bb428a1b0249"), 1 },
                    { new Guid("8765ef17-5245-4499-b6bd-bb428a1b0249"), new DateTime(2024, 3, 25, 23, 26, 31, 12, DateTimeKind.Local).AddTicks(7188), null, "Elektronik", new Guid("11111111-1111-1111-1111-111111111111"), 1 },
                    { new Guid("9e611ff4-2260-4ba8-932c-163c2ed4465e"), new DateTime(2024, 3, 25, 23, 26, 31, 12, DateTimeKind.Local).AddTicks(7203), null, "Kadın", new Guid("2dbc5f92-fa5c-4b2e-b6d2-b22cde7a5e3a"), 1 }
                });

            migrationBuilder.InsertData(
                table: "Details",
                columns: new[] { "Id", "CategoryId", "CreateDate", "Description", "ModifiedDate", "Title" },
                values: new object[,]
                {
                    { new Guid("1ba3f044-6632-486b-978f-7aee1784fa83"), new Guid("2dbc5f92-fa5c-4b2e-b6d2-b22cde7a5e3a"), new DateTime(2024, 3, 25, 23, 26, 31, 14, DateTimeKind.Local).AddTicks(2931), "Quasi ut blanditiis sıradanlıktan.", null, "Totam." },
                    { new Guid("3b18453b-4f06-433b-ac95-7e933016216c"), new Guid("8765ef17-5245-4499-b6bd-bb428a1b0249"), new DateTime(2024, 3, 25, 23, 26, 31, 14, DateTimeKind.Local).AddTicks(2867), "Adanaya cesurca mıknatıslı bundan.", null, "Ut." },
                    { new Guid("d6f5ad11-c86e-4c9d-ba00-9f5c8685f455"), new Guid("6ebed990-84e9-44fa-b36e-f124e14a0118"), new DateTime(2024, 3, 25, 23, 26, 31, 14, DateTimeKind.Local).AddTicks(2902), "Tv bahar uzattı odit.", null, "Ab non." }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CreateDate", "Description", "Discount", "ModifiedDate", "Price", "Title" },
                values: new object[,]
                {
                    { new Guid("201e8fc5-4c29-4045-82e1-7cc418311594"), new Guid("7e7ed1a0-670f-4b2f-8e55-e79f6f71aca6"), new DateTime(2024, 3, 25, 23, 26, 31, 15, DateTimeKind.Local).AddTicks(9743), "The Football Is Good For Training And Recreational Purposes", 6.429604018810496m, null, 899.08m, "Incredible Metal Tuna" },
                    { new Guid("95ce32b1-ab53-4898-b95b-1e13c8d17f6d"), new Guid("6e3e8ed0-1300-4dfa-8855-25724576c837"), new DateTime(2024, 3, 25, 23, 26, 31, 15, DateTimeKind.Local).AddTicks(9705), "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", 3.206909398377712m, null, 601.73m, "Awesome Steel Sausages" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryProduct_ProductsId",
                table: "CategoryProduct",
                column: "ProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_Details_CategoryId",
                table: "Details",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_BrandId",
                table: "Products",
                column: "BrandId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryProduct");

            migrationBuilder.DropTable(
                name: "Details");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Brands");
        }
    }
}
