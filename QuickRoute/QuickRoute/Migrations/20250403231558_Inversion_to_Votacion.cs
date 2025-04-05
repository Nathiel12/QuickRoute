using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuickRoute.Migrations
{
    /// <inheritdoc />
    public partial class Inversion_to_Votacion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Votaciones",
                columns: table => new
                {
                    VotacionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaEncuesta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PuntuacionTotal = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Votaciones", x => x.VotacionId);
                });

            migrationBuilder.CreateTable(
                name: "VotacionesDetalles",
                columns: table => new
                {
                    VotacionDetalleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoVehiclo = table.Column<int>(type: "int", nullable: false),
                    Puntuacion = table.Column<int>(type: "int", nullable: false),
                    TipoVehiculoId = table.Column<int>(type: "int", nullable: false),
                    VotacionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VotacionesDetalles", x => x.VotacionDetalleId);
                    table.ForeignKey(
                        name: "FK_VotacionesDetalles_TipoVehiculos_TipoVehiculoId",
                        column: x => x.TipoVehiculoId,
                        principalTable: "TipoVehiculos",
                        principalColumn: "TipoVehiculoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VotacionesDetalles_Votaciones_VotacionId",
                        column: x => x.VotacionId,
                        principalTable: "Votaciones",
                        principalColumn: "VotacionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VotacionesDetalles_TipoVehiculoId",
                table: "VotacionesDetalles",
                column: "TipoVehiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_VotacionesDetalles_VotacionId",
                table: "VotacionesDetalles",
                column: "VotacionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VotacionesDetalles");

            migrationBuilder.DropTable(
                name: "Votaciones");
        }
    }
}
