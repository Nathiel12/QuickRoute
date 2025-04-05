using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuickRoute.Migrations
{
    /// <inheritdoc />
    public partial class ActualizarPropiedades : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipoVehiclo",
                table: "VotacionesDetalles");

            migrationBuilder.DropColumn(
                name: "PuntuacionTotal",
                table: "Votaciones");

            migrationBuilder.RenameColumn(
                name: "Puntuacion",
                table: "TipoVehiculos",
                newName: "PuntuacionPromedio");

            migrationBuilder.AddColumn<int>(
                name: "PuntuacionTotal",
                table: "TipoVehiculos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "TipoVehiculos",
                keyColumn: "TipoVehiculoId",
                keyValue: 1,
                column: "PuntuacionTotal",
                value: 0);

            migrationBuilder.UpdateData(
                table: "TipoVehiculos",
                keyColumn: "TipoVehiculoId",
                keyValue: 2,
                column: "PuntuacionTotal",
                value: 0);

            migrationBuilder.UpdateData(
                table: "TipoVehiculos",
                keyColumn: "TipoVehiculoId",
                keyValue: 3,
                column: "PuntuacionTotal",
                value: 0);

            migrationBuilder.UpdateData(
                table: "TipoVehiculos",
                keyColumn: "TipoVehiculoId",
                keyValue: 4,
                column: "PuntuacionTotal",
                value: 0);

            migrationBuilder.UpdateData(
                table: "TipoVehiculos",
                keyColumn: "TipoVehiculoId",
                keyValue: 5,
                column: "PuntuacionTotal",
                value: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PuntuacionTotal",
                table: "TipoVehiculos");

            migrationBuilder.RenameColumn(
                name: "PuntuacionPromedio",
                table: "TipoVehiculos",
                newName: "Puntuacion");

            migrationBuilder.AddColumn<int>(
                name: "TipoVehiclo",
                table: "VotacionesDetalles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PuntuacionTotal",
                table: "Votaciones",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
