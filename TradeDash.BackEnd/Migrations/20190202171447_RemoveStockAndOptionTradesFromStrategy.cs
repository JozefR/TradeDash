using Microsoft.EntityFrameworkCore.Migrations;

namespace TradeDash.BackEnd.Migrations
{
    public partial class RemoveStockAndOptionTradesFromStrategy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OptionTrades_Strategies_StrategyId",
                table: "OptionTrades");

            migrationBuilder.DropForeignKey(
                name: "FK_StockTrades_Strategies_StrategyId",
                table: "StockTrades");

            migrationBuilder.DropIndex(
                name: "IX_StockTrades_StrategyId",
                table: "StockTrades");

            migrationBuilder.DropIndex(
                name: "IX_OptionTrades_StrategyId",
                table: "OptionTrades");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_StockTrades_StrategyId",
                table: "StockTrades",
                column: "StrategyId");

            migrationBuilder.CreateIndex(
                name: "IX_OptionTrades_StrategyId",
                table: "OptionTrades",
                column: "StrategyId");

            migrationBuilder.AddForeignKey(
                name: "FK_OptionTrades_Strategies_StrategyId",
                table: "OptionTrades",
                column: "StrategyId",
                principalTable: "Strategies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StockTrades_Strategies_StrategyId",
                table: "StockTrades",
                column: "StrategyId",
                principalTable: "Strategies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
