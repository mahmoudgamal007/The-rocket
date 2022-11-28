using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheRocket.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3abde85b-0c51-46ef-bae7-a21560978997");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "81b9c4b5-36ed-452c-86fb-ab22789852cd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ac7589bd-941a-49e7-87c5-5b7136302fa8");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReturnDate",
                table: "Orders",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeliveryDate",
                table: "Orders",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReturnDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeliveryDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3abde85b-0c51-46ef-bae7-a21560978997", "28650749-6d62-429e-a2c9-c0c49074e375", "Admin", "ADMIN" },
                    { "81b9c4b5-36ed-452c-86fb-ab22789852cd", "8dc93681-b8cf-4940-afd7-d8f046d9aa06", "Buyer", "BUYER" },
                    { "ac7589bd-941a-49e7-87c5-5b7136302fa8", "e72117d6-2919-42a9-bf4f-141655e08202", "Seller", "SELLER" }
                });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2022, 11, 24, 17, 49, 27, 944, DateTimeKind.Local).AddTicks(3760));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2022, 11, 24, 17, 49, 27, 944, DateTimeKind.Local).AddTicks(3780));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2022, 11, 24, 17, 49, 27, 944, DateTimeKind.Local).AddTicks(3790));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2022, 11, 24, 17, 49, 27, 944, DateTimeKind.Local).AddTicks(3790));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2022, 11, 24, 17, 49, 27, 944, DateTimeKind.Local).AddTicks(3790));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2022, 11, 24, 17, 49, 27, 944, DateTimeKind.Local).AddTicks(3810));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2022, 11, 24, 17, 49, 27, 944, DateTimeKind.Local).AddTicks(3810));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2022, 11, 24, 17, 49, 27, 944, DateTimeKind.Local).AddTicks(3810));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2022, 11, 24, 17, 49, 27, 944, DateTimeKind.Local).AddTicks(3810));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2022, 11, 24, 17, 49, 27, 944, DateTimeKind.Local).AddTicks(3820));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2022, 11, 24, 17, 49, 27, 944, DateTimeKind.Local).AddTicks(3830));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2022, 11, 24, 17, 49, 27, 944, DateTimeKind.Local).AddTicks(3830));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2022, 11, 24, 17, 49, 27, 944, DateTimeKind.Local).AddTicks(3830));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2022, 11, 24, 17, 49, 27, 944, DateTimeKind.Local).AddTicks(3830));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2022, 11, 24, 17, 49, 27, 944, DateTimeKind.Local).AddTicks(3830));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2022, 11, 24, 17, 49, 27, 944, DateTimeKind.Local).AddTicks(3830));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2022, 11, 24, 17, 49, 27, 944, DateTimeKind.Local).AddTicks(3840));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2022, 11, 24, 17, 49, 27, 944, DateTimeKind.Local).AddTicks(3840));
        }
    }
}
