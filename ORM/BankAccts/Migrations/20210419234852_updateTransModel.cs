using Microsoft.EntityFrameworkCore.Migrations;

namespace BankAccts.Migrations
{
    public partial class updateTransModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Users_UserId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_UserId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Transactions");

            migrationBuilder.AddColumn<int>(
                name: "AccountHolderUserId",
                table: "Transactions",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UId",
                table: "Transactions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_AccountHolderUserId",
                table: "Transactions",
                column: "AccountHolderUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Users_AccountHolderUserId",
                table: "Transactions",
                column: "AccountHolderUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Users_AccountHolderUserId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_AccountHolderUserId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "AccountHolderUserId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "UId",
                table: "Transactions");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Transactions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_UserId",
                table: "Transactions",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Users_UserId",
                table: "Transactions",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
