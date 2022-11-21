using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheRocket.Migrations
{
    public partial class v6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2913d152-4f86-49c0-8356-0410cc3ad7e4");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "ProductSizes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "624f4da3-1d1f-4001-8377-7a6418603345", "1dd27aa5-fb04-4d0e-84e6-de33e5b0a59c", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "624f4da3-1d1f-4001-8377-7a6418603345");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "ProductSizes");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2913d152-4f86-49c0-8356-0410cc3ad7e4", "3d8ccbbf-b950-4eb0-ac87-a0e584f2850e", "Admin", "ADMIN" });
        }
    }
}
