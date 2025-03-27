using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Blog.Data.Migrations
{
    /// <inheritdoc />
    public partial class dalextensions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("1dd7f56a-4196-42b3-bdfe-ac24661aa542"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("3bd5543a-8edd-4874-9294-33f08926218b"));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("6267088d-a7ce-4b97-96b3-9d339c871d8e"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("68d94a6e-1850-4235-978c-7947342012bf"));

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "ModifiedBy", "ModifiedDate", "Title", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("1dd7f56a-4196-42b3-bdfe-ac24661aa542"), new Guid("bfe1a6e9-018d-4352-859e-c89b86bbbd45"), "Asp.net Core Praesent placerat, magna in vehicula vestibulum, felis urna cursus lorem, sed vestibulum quam eros vel libero. Vivamus commodo, odio sed fringilla pretium, sem nulla feugiat odio, in cursus elit dolor et ex.\r\n", "Admin Test", new DateTime(2025, 3, 26, 16, 28, 6, 825, DateTimeKind.Local).AddTicks(4619), null, null, new Guid("b30c5b91-e13f-4062-b280-9342df03455f"), false, null, null, "Asp.net Core Deneme Makalesi 1", 15 },
                    { new Guid("3bd5543a-8edd-4874-9294-33f08926218b"), new Guid("1afe63d4-5d08-4cf9-8c0c-cfb9c1938da2"), "Java Deneme Praesent placerat, magna in vehicula vestibulum, felis urna cursus lorem, sed vestibulum quam eros vel libero. Vivamus commodo, odio sed fringilla pretium, sem nulla feugiat odio, in cursus elit dolor et ex.\r\n", "Admin Test", new DateTime(2025, 3, 26, 16, 28, 6, 825, DateTimeKind.Local).AddTicks(4625), null, null, new Guid("bb26ba2f-0403-4b31-8ddf-5e04b4cfadb7"), false, null, null, "Java Deneme Makalesi 1", 15 }
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("1afe63d4-5d08-4cf9-8c0c-cfb9c1938da2"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 26, 16, 28, 6, 825, DateTimeKind.Local).AddTicks(5972));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("bfe1a6e9-018d-4352-859e-c89b86bbbd45"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 26, 16, 28, 6, 825, DateTimeKind.Local).AddTicks(5970));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("b30c5b91-e13f-4062-b280-9342df03455f"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 26, 16, 28, 6, 825, DateTimeKind.Local).AddTicks(7093));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("bb26ba2f-0403-4b31-8ddf-5e04b4cfadb7"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 26, 16, 28, 6, 825, DateTimeKind.Local).AddTicks(7143));
        }
    }
}
