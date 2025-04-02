using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuickRoute.Migrations
{
    /// <inheritdoc />
    public partial class TrasladoTest1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Monto",
                table: "Traslados");

            migrationBuilder.CreateTable(
                name: "TrasladosDetalles",
                columns: table => new
                {
                    DetalleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarroId = table.Column<int>(type: "int", nullable: false),
                    Monto = table.Column<double>(type: "float", nullable: false),
                    TrasladoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrasladosDetalles", x => x.DetalleId);
                    table.ForeignKey(
                        name: "FK_TrasladosDetalles_Carros_CarroId",
                        column: x => x.CarroId,
                        principalTable: "Carros",
                        principalColumn: "CarroId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrasladosDetalles_Traslados_TrasladoId",
                        column: x => x.TrasladoId,
                        principalTable: "Traslados",
                        principalColumn: "TrasladoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TrasladosDetalles_CarroId",
                table: "TrasladosDetalles",
                column: "CarroId");

            migrationBuilder.CreateIndex(
                name: "IX_TrasladosDetalles_TrasladoId",
                table: "TrasladosDetalles",
                column: "TrasladoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrasladosDetalles");

            migrationBuilder.AddColumn<double>(
                name: "Monto",
                table: "Traslados",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
