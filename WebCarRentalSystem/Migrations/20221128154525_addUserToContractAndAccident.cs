using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebCarRentalSystem.Migrations
{
    /// <inheritdoc />
    public partial class addUserToContractAndAccident : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Contract",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Accident",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contract_ApplicationUserId",
                table: "Contract",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Accident_ApplicationUserId",
                table: "Accident",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accident_AspNetUsers_ApplicationUserId",
                table: "Accident",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Contract_AspNetUsers_ApplicationUserId",
                table: "Contract",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accident_AspNetUsers_ApplicationUserId",
                table: "Accident");

            migrationBuilder.DropForeignKey(
                name: "FK_Contract_AspNetUsers_ApplicationUserId",
                table: "Contract");

            migrationBuilder.DropIndex(
                name: "IX_Contract_ApplicationUserId",
                table: "Contract");

            migrationBuilder.DropIndex(
                name: "IX_Accident_ApplicationUserId",
                table: "Accident");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Contract");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Accident");
        }
    }
}
