using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheRocket.Migrations
{
    public partial class v7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "624f4da3-1d1f-4001-8377-7a6418603345");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Sellers",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Buyers",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Admins",
                newName: "ID");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5bb8d20d-cffd-423f-8639-6eb6cbc76b5b", "2438789d-9ef0-4c06-bec6-07ba09268be3", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5bb8d20d-cffd-423f-8639-6eb6cbc76b5b");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Sellers",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Buyers",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Admins",
                newName: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "624f4da3-1d1f-4001-8377-7a6418603345", "1dd27aa5-fb04-4d0e-84e6-de33e5b0a59c", "Admin", "ADMIN" });
        }
    }
}
