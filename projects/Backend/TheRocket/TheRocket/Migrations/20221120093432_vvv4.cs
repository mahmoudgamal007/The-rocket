using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheRocket.Migrations
{
    public partial class vvv4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "49baf939-e848-458d-9b3c-d5260ab06807");

            migrationBuilder.RenameColumn(
                name: "Color",
                table: "Colors",
                newName: "Name");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2913d152-4f86-49c0-8356-0410cc3ad7e4", "3d8ccbbf-b950-4eb0-ac87-a0e584f2850e", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2913d152-4f86-49c0-8356-0410cc3ad7e4");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Colors",
                newName: "Color");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "49baf939-e848-458d-9b3c-d5260ab06807", "2d7b687f-92a0-4f28-aed4-64991524dcd5", "Admin", "ADMIN" });
        }
    }
}
