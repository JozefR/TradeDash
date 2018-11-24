using Microsoft.EntityFrameworkCore.Migrations;

namespace TradeDash.BackEnd.Migrations
{
    public partial class RepairNavigationPropertiesAndAddName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OptionTrades_Strategies_StrategyId",
                table: "OptionTrades");

            migrationBuilder.DropForeignKey(
                name: "FK_ReturnOnStrategies_Strategies_StrategyId",
                table: "ReturnOnStrategies");

            migrationBuilder.DropForeignKey(
                name: "FK_StockTrades_Strategies_StrategyId",
                table: "StockTrades");

            migrationBuilder.AlterColumn<int>(
                name: "StrategyId",
                table: "StockTrades",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "StrategyId",
                table: "ReturnOnStrategies",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "StrategyId",
                table: "OptionTrades",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_OptionTrades_Strategies_StrategyId",
                table: "OptionTrades",
                column: "StrategyId",
                principalTable: "Strategies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ReturnOnStrategies_Strategies_StrategyId",
                table: "ReturnOnStrategies",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OptionTrades_Strategies_StrategyId",
                table: "OptionTrades");

            migrationBuilder.DropForeignKey(
                name: "FK_ReturnOnStrategies_Strategies_StrategyId",
                table: "ReturnOnStrategies");

            migrationBuilder.DropForeignKey(
                name: "FK_StockTrades_Strategies_StrategyId",
                table: "StockTrades");

            migrationBuilder.AlterColumn<int>(
                name: "StrategyId",
                table: "StockTrades",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StrategyId",
                table: "ReturnOnStrategies",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StrategyId",
                table: "OptionTrades",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_OptionTrades_Strategies_StrategyId",
                table: "OptionTrades",
                column: "StrategyId",
                principalTable: "Strategies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReturnOnStrategies_Strategies_StrategyId",
                table: "ReturnOnStrategies",
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
                onDelete: ReferentialAction.Cascade);
        }
    }
}
