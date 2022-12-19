using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebCarRentalSystem.Migrations
{
    /// <inheritdoc />
    public partial class carToModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Car_ModelCarId",
                table: "Car");

            migrationBuilder.CreateIndex(
                name: "IX_Car_ModelCarId",
                table: "Car",
                column: "ModelCarId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Car_ModelCarId",
                table: "Car");

            migrationBuilder.CreateIndex(
                name: "IX_Car_ModelCarId",
                table: "Car",
                column: "ModelCarId");
        }
    }
}
