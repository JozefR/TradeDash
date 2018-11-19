using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TradeDash.BackEnd.Migrations
{
    public partial class AddStockTradeEntityToStrategy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StockTrade",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    Ticker = table.Column<string>(nullable: true),
                    StrikePrice = table.Column<double>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    CurrentPrice = table.Column<double>(nullable: false),
                    PL = table.Column<double>(nullable: false),
                    StrategyId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockTrade", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StockTrade_Strategies_StrategyId",
                        column: x => x.StrategyId,
                        principalTable: "Strategies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StockTrade_StrategyId",
                table: "StockTrade",
                column: "StrategyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StockTrade");
        }
    }
}
