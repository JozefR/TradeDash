using Microsoft.EntityFrameworkCore.Migrations;

namespace TradeDash.BackEnd.Migrations
{
    public partial class MakeMoneyManagementTableNullableInStrategy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Strategies_MoneyManagements_MoneyManagementId",
                table: "Strategies");

            migrationBuilder.AlterColumn<int>(
                name: "MoneyManagementId",
                table: "Strategies",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Strategies_MoneyManagements_MoneyManagementId",
                table: "Strategies",
                column: "MoneyManagementId",
                principalTable: "MoneyManagements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Strategies_MoneyManagements_MoneyManagementId",
                table: "Strategies");

            migrationBuilder.AlterColumn<int>(
                name: "MoneyManagementId",
                table: "Strategies",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Strategies_MoneyManagements_MoneyManagementId",
                table: "Strategies",
                column: "MoneyManagementId",
                principalTable: "MoneyManagements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
