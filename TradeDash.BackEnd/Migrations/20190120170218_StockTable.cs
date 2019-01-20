using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TradeDash.BackEnd.Migrations
{
    public partial class StockTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stocks",
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
                    ChangeOverTime = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stocks");
        }
    }
}
