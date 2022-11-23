using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebCarRentalSystem.Migrations
{
    /// <inheritdoc />
    public partial class updModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HomeAddres",
                table: "Client",
                newName: "HomeAddress");

            migrationBuilder.AddColumn<string>(
                name: "ManufactureYear",
                table: "ModelCar",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ManufactureYear",
                table: "ModelCar");

            migrationBuilder.RenameColumn(
                name: "HomeAddress",
                table: "Client",
                newName: "HomeAddres");
        }
    }
}
