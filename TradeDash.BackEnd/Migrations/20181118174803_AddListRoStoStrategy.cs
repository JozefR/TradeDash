using Microsoft.EntityFrameworkCore.Migrations;

namespace TradeDash.BackEnd.Migrations
{
    public partial class AddListRoStoStrategy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StrategyId",
                table: "ReturnOnStrategies",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReturnOnStrategies_StrategyId",
                table: "ReturnOnStrategies",
                column: "StrategyId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReturnOnStrategies_Strategies_StrategyId",
                table: "ReturnOnStrategies",
                column: "StrategyId",
                principalTable: "Strategies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReturnOnStrategies_Strategies_StrategyId",
                table: "ReturnOnStrategies");

            migrationBuilder.DropIndex(
                name: "IX_ReturnOnStrategies_StrategyId",
                table: "ReturnOnStrategies");

            migrationBuilder.DropColumn(
                name: "StrategyId",
                table: "ReturnOnStrategies");
        }
    }
}
