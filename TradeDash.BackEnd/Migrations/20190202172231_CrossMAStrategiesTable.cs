using Microsoft.EntityFrameworkCore.Migrations;

namespace TradeDash.BackEnd.Migrations
{
    public partial class CrossMAStrategiesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Strategies",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "CrossMaStrategyId",
                table: "Stocks",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_CrossMaStrategyId",
                table: "Stocks",
                column: "CrossMaStrategyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Stocks_Strategies_CrossMaStrategyId",
                table: "Stocks",
                column: "CrossMaStrategyId",
                principalTable: "Strategies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stocks_Strategies_CrossMaStrategyId",
                table: "Stocks");

            migrationBuilder.DropIndex(
                name: "IX_Stocks_CrossMaStrategyId",
                table: "Stocks");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Strategies");

            migrationBuilder.DropColumn(
                name: "CrossMaStrategyId",
                table: "Stocks");
        }
    }
}
