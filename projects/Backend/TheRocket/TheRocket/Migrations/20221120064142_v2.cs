using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheRocket.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Subscrips",
                table: "Subscrips");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReserveCarts",
                table: "ReserveCarts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Feedbacks",
                table: "Feedbacks");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c3b3f712-ea78-44d5-9ea0-cd900d5b1b33");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Subscrips",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ReserveCarts",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Feedbacks",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Subscrips",
                table: "Subscrips",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReserveCarts",
                table: "ReserveCarts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Feedbacks",
                table: "Feedbacks",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ae326f0e-6764-4e31-8081-77ab533078ac", "2d8993e4-361f-48c7-bee6-c00597a8a944", "Admin", "ADMIN" });

            migrationBuilder.CreateIndex(
                name: "IX_Subscrips_SellerId",
                table: "Subscrips",
                column: "SellerId");

            migrationBuilder.CreateIndex(
                name: "IX_ReserveCarts_BuyerId",
                table: "ReserveCarts",
                column: "BuyerId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_BuyerId",
                table: "Feedbacks",
                column: "BuyerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Subscrips",
                table: "Subscrips");

            migrationBuilder.DropIndex(
                name: "IX_Subscrips_SellerId",
                table: "Subscrips");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReserveCarts",
                table: "ReserveCarts");

            migrationBuilder.DropIndex(
                name: "IX_ReserveCarts_BuyerId",
                table: "ReserveCarts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Feedbacks",
                table: "Feedbacks");

            migrationBuilder.DropIndex(
                name: "IX_Feedbacks_BuyerId",
                table: "Feedbacks");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ae326f0e-6764-4e31-8081-77ab533078ac");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Subscrips");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ReserveCarts");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Feedbacks");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Subscrips",
                table: "Subscrips",
                columns: new[] { "SellerId", "PlanId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReserveCarts",
                table: "ReserveCarts",
                columns: new[] { "BuyerId", "ProductId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Feedbacks",
                table: "Feedbacks",
                columns: new[] { "BuyerId", "ProductId" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c3b3f712-ea78-44d5-9ea0-cd900d5b1b33", "80f8d857-06cd-4ca5-bed2-c1118b9b62a9", "Admin", "ADMIN" });
        }
    }
}
