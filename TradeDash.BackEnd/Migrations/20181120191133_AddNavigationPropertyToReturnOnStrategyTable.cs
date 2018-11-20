using Microsoft.EntityFrameworkCore.Migrations;

namespace TradeDash.BackEnd.Migrations
{
    public partial class AddNavigationPropertyToReturnOnStrategyTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReturnOnStrategies_Strategies_StrategyId",
                table: "ReturnOnStrategies");

            migrationBuilder.AlterColumn<int>(
                name: "StrategyId",
                table: "ReturnOnStrategies",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ReturnOnStrategies_Strategies_StrategyId",
                table: "ReturnOnStrategies",
                column: "StrategyId",
                principalTable: "Strategies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReturnOnStrategies_Strategies_StrategyId",
                table: "ReturnOnStrategies");

            migrationBuilder.AlterColumn<int>(
                name: "StrategyId",
                table: "ReturnOnStrategies",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_ReturnOnStrategies_Strategies_StrategyId",
                table: "ReturnOnStrategies",
                column: "StrategyId",
                principalTable: "Strategies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
