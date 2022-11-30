using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebCarRentalSystem.Migrations
{
    /// <inheritdoc />
    public partial class preLastMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contract_Car_CarId",
                table: "Contract");

            migrationBuilder.DropForeignKey(
                name: "FK_Contract_Client_ClientID",
                table: "Contract");

            migrationBuilder.AlterColumn<int>(
                name: "ClientID",
                table: "Contract",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CarId",
                table: "Contract",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Contract_Car_CarId",
                table: "Contract",
                column: "CarId",
                principalTable: "Car",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Contract_Client_ClientID",
                table: "Contract",
                column: "ClientID",
                principalTable: "Client",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contract_Car_CarId",
                table: "Contract");

            migrationBuilder.DropForeignKey(
                name: "FK_Contract_Client_ClientID",
                table: "Contract");

            migrationBuilder.AlterColumn<int>(
                name: "ClientID",
                table: "Contract",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CarId",
                table: "Contract",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Contract_Car_CarId",
                table: "Contract",
                column: "CarId",
                principalTable: "Car",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contract_Client_ClientID",
                table: "Contract",
                column: "ClientID",
                principalTable: "Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
