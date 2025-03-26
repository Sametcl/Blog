using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Blog.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedDatabaseAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Articles",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "IsDeleted", "ModifiedBy", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { new Guid("1afe63d4-5d08-4cf9-8c0c-cfb9c1938da2"), "Admin Test", new DateTime(2025, 3, 26, 16, 28, 6, 825, DateTimeKind.Local).AddTicks(5972), null, null, false, null, null, "Java" },
                    { new Guid("bfe1a6e9-018d-4352-859e-c89b86bbbd45"), "Admin Test", new DateTime(2025, 3, 26, 16, 28, 6, 825, DateTimeKind.Local).AddTicks(5970), null, null, false, null, null, "Asp.net Core" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "FileName", "FileType", "IsDeleted", "ModifiedBy", "ModifiedDate" },
                values: new object[,]
                {
                    { new Guid("b30c5b91-e13f-4062-b280-9342df03455f"), "Admin Test", new DateTime(2025, 3, 26, 16, 28, 6, 825, DateTimeKind.Local).AddTicks(7093), null, null, "images/testimage", "jpg", false, null, null },
                    { new Guid("bb26ba2f-0403-4b31-8ddf-5e04b4cfadb7"), "Admin Test", new DateTime(2025, 3, 26, 16, 28, 6, 825, DateTimeKind.Local).AddTicks(7143), null, null, "images/javatest", "png", false, null, null }
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "ModifiedBy", "ModifiedDate", "Title", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("1dd7f56a-4196-42b3-bdfe-ac24661aa542"), new Guid("bfe1a6e9-018d-4352-859e-c89b86bbbd45"), "Asp.net Core Praesent placerat, magna in vehicula vestibulum, felis urna cursus lorem, sed vestibulum quam eros vel libero. Vivamus commodo, odio sed fringilla pretium, sem nulla feugiat odio, in cursus elit dolor et ex.\r\n", "Admin Test", new DateTime(2025, 3, 26, 16, 28, 6, 825, DateTimeKind.Local).AddTicks(4619), null, null, new Guid("b30c5b91-e13f-4062-b280-9342df03455f"), false, null, null, "Asp.net Core Deneme Makalesi 1", 15 },
                    { new Guid("3bd5543a-8edd-4874-9294-33f08926218b"), new Guid("1afe63d4-5d08-4cf9-8c0c-cfb9c1938da2"), "Java Deneme Praesent placerat, magna in vehicula vestibulum, felis urna cursus lorem, sed vestibulum quam eros vel libero. Vivamus commodo, odio sed fringilla pretium, sem nulla feugiat odio, in cursus elit dolor et ex.\r\n", "Admin Test", new DateTime(2025, 3, 26, 16, 28, 6, 825, DateTimeKind.Local).AddTicks(4625), null, null, new Guid("bb26ba2f-0403-4b31-8ddf-5e04b4cfadb7"), false, null, null, "Java Deneme Makalesi 1", 15 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("1dd7f56a-4196-42b3-bdfe-ac24661aa542"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("3bd5543a-8edd-4874-9294-33f08926218b"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("1afe63d4-5d08-4cf9-8c0c-cfb9c1938da2"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("bfe1a6e9-018d-4352-859e-c89b86bbbd45"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("b30c5b91-e13f-4062-b280-9342df03455f"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("bb26ba2f-0403-4b31-8ddf-5e04b4cfadb7"));

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Articles",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
