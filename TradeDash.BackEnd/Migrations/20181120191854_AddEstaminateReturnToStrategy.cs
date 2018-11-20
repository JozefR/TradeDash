using Microsoft.EntityFrameworkCore.Migrations;

namespace TradeDash.BackEnd.Migrations
{
    public partial class AddEstaminateReturnToStrategy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StrategyId",
                table: "EstaminateReturns",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EstaminateReturns_StrategyId",
                table: "EstaminateReturns",
                column: "StrategyId");

            migrationBuilder.AddForeignKey(
                name: "FK_EstaminateReturns_Strategies_StrategyId",
                table: "EstaminateReturns",
                column: "StrategyId",
                principalTable: "Strategies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EstaminateReturns_Strategies_StrategyId",
                table: "EstaminateReturns");

            migrationBuilder.DropIndex(
                name: "IX_EstaminateReturns_StrategyId",
                table: "EstaminateReturns");

            migrationBuilder.DropColumn(
                name: "StrategyId",
                table: "EstaminateReturns");
        }
    }
}
