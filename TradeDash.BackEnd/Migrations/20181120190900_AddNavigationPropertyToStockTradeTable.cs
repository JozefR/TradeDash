using Microsoft.EntityFrameworkCore.Migrations;

namespace TradeDash.BackEnd.Migrations
{
    public partial class AddNavigationPropertyToStockTradeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockTrades_Strategies_StrategyId",
                table: "StockTrades");

            migrationBuilder.AlterColumn<int>(
                name: "StrategyId",
                table: "StockTrades",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_StockTrades_Strategies_StrategyId",
                table: "StockTrades",
                column: "StrategyId",
                principalTable: "Strategies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockTrades_Strategies_StrategyId",
                table: "StockTrades");

            migrationBuilder.AlterColumn<int>(
                name: "StrategyId",
                table: "StockTrades",
                nullable: true,
                oldClrType: typeof(int));

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
