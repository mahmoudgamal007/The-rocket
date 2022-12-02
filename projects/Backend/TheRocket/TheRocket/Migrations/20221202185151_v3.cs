using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheRocket.Migrations
{
    public partial class v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4372cac6-a52d-4da5-99ad-e83479293f6d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6decc1cf-7123-4608-b90b-431e0789cd38");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8ba499f9-730c-4a89-9c82-deb7463df0c5");

            migrationBuilder.AlterColumn<int>(
                name: "ReturnRequest",
                table: "Orders",
                type: "int",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "26efc1a7-cae9-41e8-af60-4030d582d5f4", "0968639a-ef19-4b20-80e7-aade7d6253ff", "Seller", "SELLER" },
                    { "9cdfaffc-5957-4776-a6a1-52f47f8c95a6", "24787264-2f33-42b8-bd56-9a0cfb4e98d4", "Admin", "ADMIN" },
                    { "b26dba05-6702-4eea-b6f9-ae94f9ec5319", "ab90632a-955d-4f14-b929-d1a9f41efab6", "Buyer", "BUYER" }
                });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<bool>(
                name: "ReturnRequest",
                table: "Orders",
                type: "bit",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4372cac6-a52d-4da5-99ad-e83479293f6d", "b08114b7-edb2-45b1-9140-2c2e149a8ae4", "Admin", "ADMIN" },
                    { "6decc1cf-7123-4608-b90b-431e0789cd38", "b94a208a-30ba-4b4e-a6ea-4e103e607ec8", "Buyer", "BUYER" },
                    { "8ba499f9-730c-4a89-9c82-deb7463df0c5", "6941ff7a-b1ad-4b8d-83b9-5d558aafc02b", "Seller", "SELLER" }
                });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2022, 11, 28, 17, 26, 15, 16, DateTimeKind.Local).AddTicks(2740));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2022, 11, 28, 17, 26, 15, 16, DateTimeKind.Local).AddTicks(2810));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2022, 11, 28, 17, 26, 15, 16, DateTimeKind.Local).AddTicks(2810));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2022, 11, 28, 17, 26, 15, 16, DateTimeKind.Local).AddTicks(2810));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2022, 11, 28, 17, 26, 15, 16, DateTimeKind.Local).AddTicks(2810));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2022, 11, 28, 17, 26, 15, 16, DateTimeKind.Local).AddTicks(2830));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2022, 11, 28, 17, 26, 15, 16, DateTimeKind.Local).AddTicks(2830));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2022, 11, 28, 17, 26, 15, 16, DateTimeKind.Local).AddTicks(2830));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2022, 11, 28, 17, 26, 15, 16, DateTimeKind.Local).AddTicks(2830));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2022, 11, 28, 17, 26, 15, 16, DateTimeKind.Local).AddTicks(2850));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2022, 11, 28, 17, 26, 15, 16, DateTimeKind.Local).AddTicks(2850));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2022, 11, 28, 17, 26, 15, 16, DateTimeKind.Local).AddTicks(2850));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2022, 11, 28, 17, 26, 15, 16, DateTimeKind.Local).AddTicks(2850));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2022, 11, 28, 17, 26, 15, 16, DateTimeKind.Local).AddTicks(2860));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2022, 11, 28, 17, 26, 15, 16, DateTimeKind.Local).AddTicks(2860));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2022, 11, 28, 17, 26, 15, 16, DateTimeKind.Local).AddTicks(2860));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2022, 11, 28, 17, 26, 15, 16, DateTimeKind.Local).AddTicks(2860));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2022, 11, 28, 17, 26, 15, 16, DateTimeKind.Local).AddTicks(2860));
        }
    }
}
