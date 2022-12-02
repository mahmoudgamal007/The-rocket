using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheRocket.Migrations
{
    public partial class v4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "26efc1a7-cae9-41e8-af60-4030d582d5f4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9cdfaffc-5957-4776-a6a1-52f47f8c95a6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b26dba05-6702-4eea-b6f9-ae94f9ec5319");

            migrationBuilder.AlterColumn<int>(
                name: "ReturnRequest",
                table: "Orders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4c48eaa4-fdbf-4a32-b16b-76e488dbfc4d", "8fc16f75-ec10-4714-b8cf-449fb2bc5d6d", "Seller", "SELLER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8db0f07f-e57e-4ec0-aea0-3ae823239469", "f97aa0cb-552b-49ab-bfbd-7c45a0198ca7", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d20afb06-5132-4409-b512-0987cf78b05b", "adc1cbd0-dd4e-48fe-a026-c0271bdb16ed", "Buyer", "BUYER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4c48eaa4-fdbf-4a32-b16b-76e488dbfc4d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8db0f07f-e57e-4ec0-aea0-3ae823239469");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d20afb06-5132-4409-b512-0987cf78b05b");

            migrationBuilder.AlterColumn<int>(
                name: "ReturnRequest",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "26efc1a7-cae9-41e8-af60-4030d582d5f4", "0968639a-ef19-4b20-80e7-aade7d6253ff", "Seller", "SELLER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9cdfaffc-5957-4776-a6a1-52f47f8c95a6", "24787264-2f33-42b8-bd56-9a0cfb4e98d4", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b26dba05-6702-4eea-b6f9-ae94f9ec5319", "ab90632a-955d-4f14-b929-d1a9f41efab6", "Buyer", "BUYER" });
        }
    }
}
