using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebCarRentalSystem.Migrations
{
    /// <inheritdoc />
    public partial class addClientToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Client_ClientId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Contract_Client_ClientID",
                table: "Contract");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropIndex(
                name: "IX_Contract_ClientID",
                table: "Contract");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ClientId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ClientID",
                table: "Contract");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "DYears",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HomeAddress",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Passport",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Rating",
                table: "AspNetUsers",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Telephone",
                table: "AspNetUsers",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DYears",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "HomeAddress",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Passport",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Telephone",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "ClientID",
                table: "Contract",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DYears = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HomeAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Passport = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rating = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Telephone = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contract_ClientID",
                table: "Contract",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ClientId",
                table: "AspNetUsers",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Client_ClientId",
                table: "AspNetUsers",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Contract_Client_ClientID",
                table: "Contract",
                column: "ClientID",
                principalTable: "Client",
                principalColumn: "Id");
        }
    }
}
