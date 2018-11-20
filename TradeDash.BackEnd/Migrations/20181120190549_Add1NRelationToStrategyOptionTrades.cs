using Microsoft.EntityFrameworkCore.Migrations;

namespace TradeDash.BackEnd.Migrations
{
    public partial class Add1NRelationToStrategyOptionTrades : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockTrade_Strategies_StrategyId",
                table: "StockTrade");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StockTrade",
                table: "StockTrade");

            migrationBuilder.RenameTable(
                name: "StockTrade",
                newName: "StockTrades");

            migrationBuilder.RenameIndex(
                name: "IX_StockTrade_StrategyId",
                table: "StockTrades",
                newName: "IX_StockTrades_StrategyId");

            migrationBuilder.AddColumn<int>(
                name: "StrategyId",
                table: "OptionTrades",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_StockTrades",
                table: "StockTrades",
                column: "Id");

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
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StockTrades_Strategies_StrategyId",
                table: "StockTrades",
                column: "StrategyId",
                principalTable: "Strategies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OptionTrades_Strategies_StrategyId",
                table: "OptionTrades");

            migrationBuilder.DropForeignKey(
                name: "FK_StockTrades_Strategies_StrategyId",
                table: "StockTrades");

            migrationBuilder.DropIndex(
                name: "IX_OptionTrades_StrategyId",
                table: "OptionTrades");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StockTrades",
                table: "StockTrades");

            migrationBuilder.DropColumn(
                name: "StrategyId",
                table: "OptionTrades");

            migrationBuilder.RenameTable(
                name: "StockTrades",
                newName: "StockTrade");

            migrationBuilder.RenameIndex(
                name: "IX_StockTrades_StrategyId",
                table: "StockTrade",
                newName: "IX_StockTrade_StrategyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StockTrade",
                table: "StockTrade",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StockTrade_Strategies_StrategyId",
                table: "StockTrade",
                column: "StrategyId",
                principalTable: "Strategies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
