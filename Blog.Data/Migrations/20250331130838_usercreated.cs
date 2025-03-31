using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Blog.Data.Migrations
{
    /// <inheritdoc />
    public partial class usercreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("6267088d-a7ce-4b97-96b3-9d339c871d8e"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("68d94a6e-1850-4235-978c-7947342012bf"));

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
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
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

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "ModifiedBy", "ModifiedDate", "Title", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("225e6d21-fe44-43eb-983e-9008facf1d62"), new Guid("bfe1a6e9-018d-4352-859e-c89b86bbbd45"), "Asp.net Core Praesent placerat, magna in vehicula vestibulum, felis urna cursus lorem, sed vestibulum quam eros vel libero. Vivamus commodo, odio sed fringilla pretium, sem nulla feugiat odio, in cursus elit dolor et ex.\r\n", "Admin Test", new DateTime(2025, 3, 31, 16, 8, 36, 910, DateTimeKind.Local).AddTicks(4971), null, null, new Guid("b30c5b91-e13f-4062-b280-9342df03455f"), false, null, null, "Asp.net Core Deneme Makalesi 1", 15 },
                    { new Guid("31d1b3c9-9b9b-4e1b-bb4b-250b33e5610d"), new Guid("1afe63d4-5d08-4cf9-8c0c-cfb9c1938da2"), "Java Deneme Praesent placerat, magna in vehicula vestibulum, felis urna cursus lorem, sed vestibulum quam eros vel libero. Vivamus commodo, odio sed fringilla pretium, sem nulla feugiat odio, in cursus elit dolor et ex.\r\n", "Admin Test", new DateTime(2025, 3, 31, 16, 8, 36, 910, DateTimeKind.Local).AddTicks(4976), null, null, new Guid("bb26ba2f-0403-4b31-8ddf-5e04b4cfadb7"), false, null, null, "Java Deneme Makalesi 1", 15 }
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("276f7e2f-a10c-42b3-b82a-ecd008c4ae0f"), "33b4b867-7c7c-4fb4-9b95-26834c612dc8", "User", "USER" },
                    { new Guid("bb073d1f-7802-4e12-8627-378ef113ecf9"), "4d4da625-48df-4597-9827-39fa36631558", "Admin", "ADMIN" },
                    { new Guid("c39ca640-e96c-453f-b2e6-437acc3e40e8"), "5c33cd61-856f-4bdf-8b5b-db668fd492f2", "SuperAdmin", "SUPERADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("734b1748-e3e6-4bd9-8024-60e44d3db7d9"), 0, "8ea9d7a7-8bc3-4bbc-8985-77888cf81884", "admin@gmail.com", false, "Admin", "User", false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", null, "+05439999988", false, "d9458b08-6f12-403d-9a13-8791b87c06e5", false, "admin@gmail.com" },
                    { new Guid("956073a7-dc08-4f32-a7b9-ccdce660d523"), 0, "d3d0b9cb-504c-40a1-a96a-76ef7722f93e", "superadmin@gmail.com", true, "Samet", "Cil", false, null, "SUPERADMIN@GMAIL.COM", "SUPERADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEF4cUXL91FrqNwMMpa5ovqH6uNQUfKblHlSyFGCtZNJ6km2rBMQVYHYH1qjjgT1cjw==", "+05439999999", true, "e8bea5c5-7c5c-4f82-b991-f62b8f93aed0", false, "superadmin@gmail.com" }
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("1afe63d4-5d08-4cf9-8c0c-cfb9c1938da2"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 31, 16, 8, 36, 910, DateTimeKind.Local).AddTicks(6270));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("bfe1a6e9-018d-4352-859e-c89b86bbbd45"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 31, 16, 8, 36, 910, DateTimeKind.Local).AddTicks(6267));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("b30c5b91-e13f-4062-b280-9342df03455f"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 31, 16, 8, 36, 910, DateTimeKind.Local).AddTicks(7203));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("bb26ba2f-0403-4b31-8ddf-5e04b4cfadb7"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 31, 16, 8, 36, 910, DateTimeKind.Local).AddTicks(7205));

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("bb073d1f-7802-4e12-8627-378ef113ecf9"), new Guid("734b1748-e3e6-4bd9-8024-60e44d3db7d9") },
                    { new Guid("c39ca640-e96c-453f-b2e6-437acc3e40e8"), new Guid("956073a7-dc08-4f32-a7b9-ccdce660d523") }
                });

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

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("225e6d21-fe44-43eb-983e-9008facf1d62"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("31d1b3c9-9b9b-4e1b-bb4b-250b33e5610d"));

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "ModifiedBy", "ModifiedDate", "Title", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("6267088d-a7ce-4b97-96b3-9d339c871d8e"), new Guid("bfe1a6e9-018d-4352-859e-c89b86bbbd45"), "Asp.net Core Praesent placerat, magna in vehicula vestibulum, felis urna cursus lorem, sed vestibulum quam eros vel libero. Vivamus commodo, odio sed fringilla pretium, sem nulla feugiat odio, in cursus elit dolor et ex.\r\n", "Admin Test", new DateTime(2025, 3, 27, 13, 26, 58, 565, DateTimeKind.Local).AddTicks(247), null, null, new Guid("b30c5b91-e13f-4062-b280-9342df03455f"), false, null, null, "Asp.net Core Deneme Makalesi 1", 15 },
                    { new Guid("68d94a6e-1850-4235-978c-7947342012bf"), new Guid("1afe63d4-5d08-4cf9-8c0c-cfb9c1938da2"), "Java Deneme Praesent placerat, magna in vehicula vestibulum, felis urna cursus lorem, sed vestibulum quam eros vel libero. Vivamus commodo, odio sed fringilla pretium, sem nulla feugiat odio, in cursus elit dolor et ex.\r\n", "Admin Test", new DateTime(2025, 3, 27, 13, 26, 58, 565, DateTimeKind.Local).AddTicks(256), null, null, new Guid("bb26ba2f-0403-4b31-8ddf-5e04b4cfadb7"), false, null, null, "Java Deneme Makalesi 1", 15 }
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("1afe63d4-5d08-4cf9-8c0c-cfb9c1938da2"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 27, 13, 26, 58, 565, DateTimeKind.Local).AddTicks(1423));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("bfe1a6e9-018d-4352-859e-c89b86bbbd45"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 27, 13, 26, 58, 565, DateTimeKind.Local).AddTicks(1417));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("b30c5b91-e13f-4062-b280-9342df03455f"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 27, 13, 26, 58, 565, DateTimeKind.Local).AddTicks(3749));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("bb26ba2f-0403-4b31-8ddf-5e04b4cfadb7"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 27, 13, 26, 58, 565, DateTimeKind.Local).AddTicks(3752));
        }
    }
}
