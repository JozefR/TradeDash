using Microsoft.EntityFrameworkCore.Migrations;

namespace TradeDash.BackEnd.Migrations
{
    public partial class AddNamePropertyToStrategy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EstaminateReturns_Strategies_StrategyId",
                table: "EstaminateReturns");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Strategies",
                maxLength: 36,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "StrategyId",
                table: "EstaminateReturns",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_EstaminateReturns_Strategies_StrategyId",
                table: "EstaminateReturns",
                column: "StrategyId",
                principalTable: "Strategies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EstaminateReturns_Strategies_StrategyId",
                table: "EstaminateReturns");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Strategies");

            migrationBuilder.AlterColumn<int>(
                name: "StrategyId",
                table: "EstaminateReturns",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_EstaminateReturns_Strategies_StrategyId",
                table: "EstaminateReturns",
                column: "StrategyId",
                principalTable: "Strategies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
