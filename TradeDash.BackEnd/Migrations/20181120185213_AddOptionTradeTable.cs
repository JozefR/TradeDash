using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TradeDash.BackEnd.Migrations
{
    public partial class AddOptionTradeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OptionTrades",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    Ticker = table.Column<string>(nullable: true),
                    OptionType = table.Column<string>(nullable: true),
                    CurrentPrice = table.Column<double>(nullable: false),
                    ExpirationDate = table.Column<DateTime>(nullable: false),
                    Strike = table.Column<double>(nullable: false),
                    Premium = table.Column<double>(nullable: false),
                    Contracts = table.Column<double>(nullable: false),
                    Commissions = table.Column<double>(nullable: false),
                    Margin = table.Column<double>(nullable: false),
                    PremiumAfterCommissions = table.Column<double>(nullable: false),
                    NeededInReserve = table.Column<double>(nullable: false),
                    LossPremium = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OptionTrades", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OptionTrades");
        }
    }
}
