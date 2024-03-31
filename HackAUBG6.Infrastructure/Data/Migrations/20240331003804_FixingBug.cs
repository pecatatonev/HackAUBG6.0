using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HackAUBG6.Data.Migrations
{
    public partial class FixingBug : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BillId",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_BillId",
                table: "Orders",
                column: "BillId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Bills_BillId",
                table: "Orders",
                column: "BillId",
                principalTable: "Bills",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Bills_BillId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_BillId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "BillId",
                table: "Orders");
        }
    }
}
