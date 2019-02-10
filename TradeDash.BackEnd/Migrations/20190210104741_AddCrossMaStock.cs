using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TradeDash.BackEnd.Migrations
{
    public partial class AddCrossMaStock : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stocks_Strategies_CrossMaStrategyId",
                table: "Stocks");

            migrationBuilder.DropIndex(
                name: "IX_Stocks_CrossMaStrategyId",
                table: "Stocks");

            migrationBuilder.DropColumn(
                name: "CrossMaStrategyId",
                table: "Stocks");

            migrationBuilder.CreateTable(
                name: "CrossMaStocks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    Number = table.Column<int>(nullable: false),
                    Ticker = table.Column<string>(nullable: true),
                    History = table.Column<string>(nullable: true),
                    Open = table.Column<double>(nullable: false),
                    High = table.Column<double>(nullable: false),
                    Low = table.Column<double>(nullable: false),
                    Close = table.Column<double>(nullable: false),
                    Volume = table.Column<long>(nullable: false),
                    UnadjustedVolume = table.Column<long>(nullable: false),
                    Change = table.Column<double>(nullable: false),
                    ChangePercent = table.Column<double>(nullable: false),
                    Label = table.Column<string>(nullable: true),
                    ChangeOverTime = table.Column<double>(nullable: false),
                    LongSma = table.Column<double>(nullable: false),
                    CrossMaStrategyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrossMaStocks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CrossMaStocks_Strategies_CrossMaStrategyId",
                        column: x => x.CrossMaStrategyId,
                        principalTable: "Strategies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CrossMaStocks_CrossMaStrategyId",
                table: "CrossMaStocks",
                column: "CrossMaStrategyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CrossMaStocks");

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
    }
}
