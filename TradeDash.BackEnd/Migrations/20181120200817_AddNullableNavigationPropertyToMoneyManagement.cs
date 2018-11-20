using Microsoft.EntityFrameworkCore.Migrations;

namespace TradeDash.BackEnd.Migrations
{
    public partial class AddNullableNavigationPropertyToMoneyManagement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Strategies_MoneyManagements_MoneyManagementId",
                table: "Strategies");

            migrationBuilder.DropIndex(
                name: "IX_Strategies_MoneyManagementId",
                table: "Strategies");

            migrationBuilder.DropColumn(
                name: "MoneyManagementId",
                table: "Strategies");

            migrationBuilder.AddColumn<int>(
                name: "StrategyId",
                table: "MoneyManagements",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MoneyManagements_StrategyId",
                table: "MoneyManagements",
                column: "StrategyId",
                unique: true,
                filter: "[StrategyId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_MoneyManagements_Strategies_StrategyId",
                table: "MoneyManagements",
                column: "StrategyId",
                principalTable: "Strategies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MoneyManagements_Strategies_StrategyId",
                table: "MoneyManagements");

            migrationBuilder.DropIndex(
                name: "IX_MoneyManagements_StrategyId",
                table: "MoneyManagements");

            migrationBuilder.DropColumn(
                name: "StrategyId",
                table: "MoneyManagements");

            migrationBuilder.AddColumn<int>(
                name: "MoneyManagementId",
                table: "Strategies",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Strategies_MoneyManagementId",
                table: "Strategies",
                column: "MoneyManagementId");

            migrationBuilder.AddForeignKey(
                name: "FK_Strategies_MoneyManagements_MoneyManagementId",
                table: "Strategies",
                column: "MoneyManagementId",
                principalTable: "MoneyManagements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
