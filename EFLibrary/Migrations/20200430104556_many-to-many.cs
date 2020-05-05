using Microsoft.EntityFrameworkCore.Migrations;

namespace EFLibrary.Migrations
{
    public partial class manytomany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Transactions_userID",
                table: "Transactions",
                column: "userID");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Users_userID",
                table: "Transactions",
                column: "userID",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Users_userID",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_userID",
                table: "Transactions");
        }
    }
}
