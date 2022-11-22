using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheRocket.Migrations
{
    public partial class v8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5bb8d20d-cffd-423f-8639-6eb6cbc76b5b");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Sellers",
                newName: "SellerId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Buyers",
                newName: "BuyerId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Admins",
                newName: "AdminId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7cff3980-7e6f-4da6-abae-a84fd1d352e6", "334e2843-9741-4c0b-80aa-64f0c2e4a4c8", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7cff3980-7e6f-4da6-abae-a84fd1d352e6");

            migrationBuilder.RenameColumn(
                name: "SellerId",
                table: "Sellers",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "BuyerId",
                table: "Buyers",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "AdminId",
                table: "Admins",
                newName: "ID");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5bb8d20d-cffd-423f-8639-6eb6cbc76b5b", "2438789d-9ef0-4c06-bec6-07ba09268be3", "Admin", "ADMIN" });
        }
    }
}
