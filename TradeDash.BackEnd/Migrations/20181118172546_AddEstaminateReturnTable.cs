using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TradeDash.BackEnd.Migrations
{
    public partial class AddEstaminateReturnTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EstaminateReturnId",
                table: "Strategies",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "EstaminateReturns",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccountValue = table.Column<double>(nullable: false),
                    Premium = table.Column<double>(nullable: false),
                    Percentage = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstaminateReturns", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Strategies_EstaminateReturnId",
                table: "Strategies",
                column: "EstaminateReturnId");

            migrationBuilder.AddForeignKey(
                name: "FK_Strategies_EstaminateReturns_EstaminateReturnId",
                table: "Strategies",
                column: "EstaminateReturnId",
                principalTable: "EstaminateReturns",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Strategies_EstaminateReturns_EstaminateReturnId",
                table: "Strategies");

            migrationBuilder.DropTable(
                name: "EstaminateReturns");

            migrationBuilder.DropIndex(
                name: "IX_Strategies_EstaminateReturnId",
                table: "Strategies");

            migrationBuilder.DropColumn(
                name: "EstaminateReturnId",
                table: "Strategies");
        }
    }
}
