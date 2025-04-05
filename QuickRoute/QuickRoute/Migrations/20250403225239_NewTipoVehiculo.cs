using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace QuickRoute.Migrations
{
    /// <inheritdoc />
    public partial class NewTipoVehiculo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TipoVehiculos",
                columns: table => new
                {
                    TipoVehiculoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehiculoNombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Puntuacion = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoVehiculos", x => x.TipoVehiculoId);
                });

            migrationBuilder.InsertData(
                table: "TipoVehiculos",
                columns: new[] { "TipoVehiculoId", "Puntuacion", "VehiculoNombre" },
                values: new object[,]
                {
                    { 1, 0.0, "Moticicleta" },
                    { 2, 0.0, "Camión" },
                    { 3, 0.0, "Excavadora" },
                    { 4, 0.0, "Autobús" },
                    { 5, 0.0, "Camión de Remolque" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TipoVehiculos");
        }
    }
}
