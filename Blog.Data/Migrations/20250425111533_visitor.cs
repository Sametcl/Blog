using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Blog.Data.Migrations
{
    /// <inheritdoc />
    public partial class visitor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("1d130646-4757-4dfc-9f61-ac19c87ed715"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("c59833be-49ab-48d5-85ce-66cba6e0c1e9"));

            migrationBuilder.CreateTable(
                name: "Visitors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IpAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserAgent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visitors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ArticleVisitors",
                columns: table => new
                {
                    ArticleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VisitorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleVisitors", x => new { x.ArticleId, x.VisitorId });
                    table.ForeignKey(
                        name: "FK_ArticleVisitors_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArticleVisitors_Visitors_VisitorId",
                        column: x => x.VisitorId,
                        principalTable: "Visitors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "ModifiedBy", "ModifiedDate", "Title", "UserId", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("10ebcf84-0d1a-4c68-a086-267f28f43566"), new Guid("bfe1a6e9-018d-4352-859e-c89b86bbbd45"), "Asp.net Core Praesent placerat, magna in vehicula vestibulum, felis urna cursus lorem, sed vestibulum quam eros vel libero. Vivamus commodo, odio sed fringilla pretium, sem nulla feugiat odio, in cursus elit dolor et ex.\r\n", "Admin Test", new DateTime(2025, 4, 25, 14, 15, 31, 500, DateTimeKind.Local).AddTicks(7985), null, null, new Guid("b30c5b91-e13f-4062-b280-9342df03455f"), false, null, null, "Asp.net Core Deneme Makalesi 1", new Guid("956073a7-dc08-4f32-a7b9-ccdce660d523"), 15 },
                    { new Guid("efc8a208-cc6e-4adf-a281-6979513dc502"), new Guid("1afe63d4-5d08-4cf9-8c0c-cfb9c1938da2"), "Java Deneme Praesent placerat, magna in vehicula vestibulum, felis urna cursus lorem, sed vestibulum quam eros vel libero. Vivamus commodo, odio sed fringilla pretium, sem nulla feugiat odio, in cursus elit dolor et ex.\r\n", "Admin Test", new DateTime(2025, 4, 25, 14, 15, 31, 500, DateTimeKind.Local).AddTicks(7993), null, null, new Guid("bb26ba2f-0403-4b31-8ddf-5e04b4cfadb7"), false, null, null, "Java Deneme Makalesi 1", new Guid("734b1748-e3e6-4bd9-8024-60e44d3db7d9"), 15 }
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("276f7e2f-a10c-42b3-b82a-ecd008c4ae0f"),
                column: "ConcurrencyStamp",
                value: "f778319b-7620-454e-8520-d78edf066c18");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("bb073d1f-7802-4e12-8627-378ef113ecf9"),
                column: "ConcurrencyStamp",
                value: "066940e4-ca3d-4b4d-83d2-b1492fc29fb2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c39ca640-e96c-453f-b2e6-437acc3e40e8"),
                column: "ConcurrencyStamp",
                value: "9da0fcf1-4381-4823-a5c1-4bd289fc9d3d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("734b1748-e3e6-4bd9-8024-60e44d3db7d9"),
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "e24ad7ed-c0a6-4660-8b63-dffad7c13ef4", "d2992f2d-bca9-429b-a447-f0c03a7e179a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("956073a7-dc08-4f32-a7b9-ccdce660d523"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5e1194c8-38c2-40c7-b4a7-a2980c4f8f74", "AQAAAAIAAYagAAAAENdwBbYfMVTm+kZ8pUXP7VFzuOw2AISzFbqhECONuc2lcxyhN0FMKCaqic9/IvlwUw==", "e8d24714-e2cb-42c2-a0ff-518f38fb326d" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("1afe63d4-5d08-4cf9-8c0c-cfb9c1938da2"),
                column: "CreatedDate",
                value: new DateTime(2025, 4, 25, 14, 15, 31, 501, DateTimeKind.Local).AddTicks(3753));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("bfe1a6e9-018d-4352-859e-c89b86bbbd45"),
                column: "CreatedDate",
                value: new DateTime(2025, 4, 25, 14, 15, 31, 501, DateTimeKind.Local).AddTicks(3750));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("b30c5b91-e13f-4062-b280-9342df03455f"),
                column: "CreatedDate",
                value: new DateTime(2025, 4, 25, 14, 15, 31, 501, DateTimeKind.Local).AddTicks(4683));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("bb26ba2f-0403-4b31-8ddf-5e04b4cfadb7"),
                column: "CreatedDate",
                value: new DateTime(2025, 4, 25, 14, 15, 31, 501, DateTimeKind.Local).AddTicks(4699));

            migrationBuilder.CreateIndex(
                name: "IX_ArticleVisitors_VisitorId",
                table: "ArticleVisitors",
                column: "VisitorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticleVisitors");

            migrationBuilder.DropTable(
                name: "Visitors");

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("10ebcf84-0d1a-4c68-a086-267f28f43566"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("efc8a208-cc6e-4adf-a281-6979513dc502"));

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "ModifiedBy", "ModifiedDate", "Title", "UserId", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("1d130646-4757-4dfc-9f61-ac19c87ed715"), new Guid("1afe63d4-5d08-4cf9-8c0c-cfb9c1938da2"), "Java Deneme Praesent placerat, magna in vehicula vestibulum, felis urna cursus lorem, sed vestibulum quam eros vel libero. Vivamus commodo, odio sed fringilla pretium, sem nulla feugiat odio, in cursus elit dolor et ex.\r\n", "Admin Test", new DateTime(2025, 4, 1, 16, 16, 47, 555, DateTimeKind.Local).AddTicks(32), null, null, new Guid("bb26ba2f-0403-4b31-8ddf-5e04b4cfadb7"), false, null, null, "Java Deneme Makalesi 1", new Guid("734b1748-e3e6-4bd9-8024-60e44d3db7d9"), 15 },
                    { new Guid("c59833be-49ab-48d5-85ce-66cba6e0c1e9"), new Guid("bfe1a6e9-018d-4352-859e-c89b86bbbd45"), "Asp.net Core Praesent placerat, magna in vehicula vestibulum, felis urna cursus lorem, sed vestibulum quam eros vel libero. Vivamus commodo, odio sed fringilla pretium, sem nulla feugiat odio, in cursus elit dolor et ex.\r\n", "Admin Test", new DateTime(2025, 4, 1, 16, 16, 47, 555, DateTimeKind.Local).AddTicks(27), null, null, new Guid("b30c5b91-e13f-4062-b280-9342df03455f"), false, null, null, "Asp.net Core Deneme Makalesi 1", new Guid("956073a7-dc08-4f32-a7b9-ccdce660d523"), 15 }
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("276f7e2f-a10c-42b3-b82a-ecd008c4ae0f"),
                column: "ConcurrencyStamp",
                value: "3b66520c-87ba-4aa8-9449-6c967e474459");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("bb073d1f-7802-4e12-8627-378ef113ecf9"),
                column: "ConcurrencyStamp",
                value: "d9ef6032-c129-4421-ad41-c07d340b93bc");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c39ca640-e96c-453f-b2e6-437acc3e40e8"),
                column: "ConcurrencyStamp",
                value: "094194d2-47b7-454c-8670-760ba168e887");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("734b1748-e3e6-4bd9-8024-60e44d3db7d9"),
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "aaade8a1-952c-45d0-95e7-cccadb10a4e2", "90fadafb-18db-4427-991b-8a59a6fd768d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("956073a7-dc08-4f32-a7b9-ccdce660d523"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1ec7f627-a0d4-412c-9bde-c76f6778aa7c", "AQAAAAIAAYagAAAAEE9tunLvuTYPyylENPPy3dVGdHHTvnPn0IvdqAM3lYSaxM3FqDnhYm4SzeLWvwVOwg==", "adf6b3f5-2ba1-45fe-84ae-308fab80a393" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("1afe63d4-5d08-4cf9-8c0c-cfb9c1938da2"),
                column: "CreatedDate",
                value: new DateTime(2025, 4, 1, 16, 16, 47, 555, DateTimeKind.Local).AddTicks(1156));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("bfe1a6e9-018d-4352-859e-c89b86bbbd45"),
                column: "CreatedDate",
                value: new DateTime(2025, 4, 1, 16, 16, 47, 555, DateTimeKind.Local).AddTicks(1154));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("b30c5b91-e13f-4062-b280-9342df03455f"),
                column: "CreatedDate",
                value: new DateTime(2025, 4, 1, 16, 16, 47, 555, DateTimeKind.Local).AddTicks(2064));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("bb26ba2f-0403-4b31-8ddf-5e04b4cfadb7"),
                column: "CreatedDate",
                value: new DateTime(2025, 4, 1, 16, 16, 47, 555, DateTimeKind.Local).AddTicks(2066));
        }
    }
}
