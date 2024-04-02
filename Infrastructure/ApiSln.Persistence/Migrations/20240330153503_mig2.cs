using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiSln.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefreshTokenExpiryTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("3d403e8f-6634-47c1-869e-803e27ea5c50"),
                columns: new[] { "CreateDate", "Name" },
                values: new object[] { new DateTime(2024, 3, 30, 18, 35, 3, 696, DateTimeKind.Local).AddTicks(8706), "Tools, Music & Computers" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("6e3e8ed0-1300-4dfa-8855-25724576c837"),
                columns: new[] { "CreateDate", "Name" },
                values: new object[] { new DateTime(2024, 3, 30, 18, 35, 3, 696, DateTimeKind.Local).AddTicks(8683), "Electronics & Sports" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("7e7ed1a0-670f-4b2f-8e55-e79f6f71aca6"),
                columns: new[] { "CreateDate", "Name" },
                values: new object[] { new DateTime(2024, 3, 30, 18, 35, 3, 696, DateTimeKind.Local).AddTicks(8713), "Home" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("2dbc5f92-fa5c-4b2e-b6d2-b22cde7a5e3a"),
                column: "CreateDate",
                value: new DateTime(2024, 3, 30, 18, 35, 3, 697, DateTimeKind.Local).AddTicks(4816));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6ebed990-84e9-44fa-b36e-f124e14a0118"),
                column: "CreateDate",
                value: new DateTime(2024, 3, 30, 18, 35, 3, 697, DateTimeKind.Local).AddTicks(4819));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("8765ef17-5245-4499-b6bd-bb428a1b0249"),
                column: "CreateDate",
                value: new DateTime(2024, 3, 30, 18, 35, 3, 697, DateTimeKind.Local).AddTicks(4812));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("9e611ff4-2260-4ba8-932c-163c2ed4465e"),
                column: "CreateDate",
                value: new DateTime(2024, 3, 30, 18, 35, 3, 697, DateTimeKind.Local).AddTicks(4827));

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: new Guid("1ba3f044-6632-486b-978f-7aee1784fa83"),
                columns: new[] { "CreateDate", "Description", "Title" },
                values: new object[] { new DateTime(2024, 3, 30, 18, 35, 3, 700, DateTimeKind.Local).AddTicks(5492), "Çıktılar sit minima beatae.", "Ad." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: new Guid("3b18453b-4f06-433b-ac95-7e933016216c"),
                columns: new[] { "CreateDate", "Description", "Title" },
                values: new object[] { new DateTime(2024, 3, 30, 18, 35, 3, 700, DateTimeKind.Local).AddTicks(5415), "Consectetur ekşili ve quis.", "Dolorem." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: new Guid("d6f5ad11-c86e-4c9d-ba00-9f5c8685f455"),
                columns: new[] { "CreateDate", "Description", "Title" },
                values: new object[] { new DateTime(2024, 3, 30, 18, 35, 3, 700, DateTimeKind.Local).AddTicks(5461), "Modi consequatur hesap vel.", "Gördüm layıkıyla." });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("201e8fc5-4c29-4045-82e1-7cc418311594"),
                columns: new[] { "CreateDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2024, 3, 30, 18, 35, 3, 704, DateTimeKind.Local).AddTicks(8716), "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", 1.546511940575136m, 854.23m, "Rustic Metal Cheese" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("95ce32b1-ab53-4898-b95b-1e13c8d17f6d"),
                columns: new[] { "CreateDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2024, 3, 30, 18, 35, 3, 704, DateTimeKind.Local).AddTicks(8673), "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", 1.598380273698872m, 389.16m, "Refined Fresh Towels" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("3d403e8f-6634-47c1-869e-803e27ea5c50"),
                columns: new[] { "CreateDate", "Name" },
                values: new object[] { new DateTime(2024, 3, 28, 22, 55, 54, 546, DateTimeKind.Local).AddTicks(5142), "Toys, Beauty & Kids" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("6e3e8ed0-1300-4dfa-8855-25724576c837"),
                columns: new[] { "CreateDate", "Name" },
                values: new object[] { new DateTime(2024, 3, 28, 22, 55, 54, 546, DateTimeKind.Local).AddTicks(5118), "Sports & Books" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("7e7ed1a0-670f-4b2f-8e55-e79f6f71aca6"),
                columns: new[] { "CreateDate", "Name" },
                values: new object[] { new DateTime(2024, 3, 28, 22, 55, 54, 546, DateTimeKind.Local).AddTicks(5159), "Computers, Baby & Health" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("2dbc5f92-fa5c-4b2e-b6d2-b22cde7a5e3a"),
                column: "CreateDate",
                value: new DateTime(2024, 3, 28, 22, 55, 54, 546, DateTimeKind.Local).AddTicks(8668));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6ebed990-84e9-44fa-b36e-f124e14a0118"),
                column: "CreateDate",
                value: new DateTime(2024, 3, 28, 22, 55, 54, 546, DateTimeKind.Local).AddTicks(8672));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("8765ef17-5245-4499-b6bd-bb428a1b0249"),
                column: "CreateDate",
                value: new DateTime(2024, 3, 28, 22, 55, 54, 546, DateTimeKind.Local).AddTicks(8666));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("9e611ff4-2260-4ba8-932c-163c2ed4465e"),
                column: "CreateDate",
                value: new DateTime(2024, 3, 28, 22, 55, 54, 546, DateTimeKind.Local).AddTicks(8675));

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: new Guid("1ba3f044-6632-486b-978f-7aee1784fa83"),
                columns: new[] { "CreateDate", "Description", "Title" },
                values: new object[] { new DateTime(2024, 3, 28, 22, 55, 54, 548, DateTimeKind.Local).AddTicks(4822), "Camisi sed ratione makinesi.", "Layıkıyla." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: new Guid("3b18453b-4f06-433b-ac95-7e933016216c"),
                columns: new[] { "CreateDate", "Description", "Title" },
                values: new object[] { new DateTime(2024, 3, 28, 22, 55, 54, 548, DateTimeKind.Local).AddTicks(4756), "İusto kutusu yazın consequuntur.", "Quasi." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: new Guid("d6f5ad11-c86e-4c9d-ba00-9f5c8685f455"),
                columns: new[] { "CreateDate", "Description", "Title" },
                values: new object[] { new DateTime(2024, 3, 28, 22, 55, 54, 548, DateTimeKind.Local).AddTicks(4794), "Orta kapının et veniam.", "Quia olduğu." });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("201e8fc5-4c29-4045-82e1-7cc418311594"),
                columns: new[] { "CreateDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2024, 3, 28, 22, 55, 54, 551, DateTimeKind.Local).AddTicks(993), "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", 5.720808961707488m, 110.09m, "Rustic Cotton Car" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("95ce32b1-ab53-4898-b95b-1e13c8d17f6d"),
                columns: new[] { "CreateDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2024, 3, 28, 22, 55, 54, 551, DateTimeKind.Local).AddTicks(957), "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", 1.506512637086312m, 678.93m, "Handmade Concrete Keyboard" });
        }
    }
}
