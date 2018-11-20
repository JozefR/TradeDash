using Microsoft.EntityFrameworkCore.Migrations;

namespace TradeDash.BackEnd.Migrations
{
    public partial class RemoveEstaminateReturnFromStrategy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Strategies_EstaminateReturns_EstaminateReturnId",
                table: "Strategies");

            migrationBuilder.DropIndex(
                name: "IX_Strategies_EstaminateReturnId",
                table: "Strategies");

            migrationBuilder.DropColumn(
                name: "EstaminateReturnId",
                table: "Strategies");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EstaminateReturnId",
                table: "Strategies",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Strategies_EstaminateReturnId",
                table: "Strategies",
                column: "EstaminateReturnId");

            migrationBuilder.AddForeignKey(
                name: "FK_Strategies_EstaminateReturns_EstaminateReturnId",
                table: "Strategies",
                column: "EstaminateReturnId",
                principalTable: "EstaminateReturns",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
