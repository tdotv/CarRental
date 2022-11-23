using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebCarRentalSystem.Migrations
{
    /// <inheritdoc />
    public partial class @float : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "FuelConsumption",
                table: "ModelCar",
                type: "real",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "EngineValue",
                table: "ModelCar",
                type: "real",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "FuelConsumption",
                table: "ModelCar",
                type: "float",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<double>(
                name: "EngineValue",
                table: "ModelCar",
                type: "float",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real");
        }
    }
}
