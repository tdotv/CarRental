using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebCarRentalSystem.Migrations
{
    /// <inheritdoc />
    public partial class updateModelCar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Contract");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "ModelCar",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "ModelCar");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Contract",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
