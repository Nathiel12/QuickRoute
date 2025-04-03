using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace QuickRoute.Migrations
{
    /// <inheritdoc />
    public partial class RemovidoDespachosSolicitudesDeclaraciones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Casos_Traslados_TrasladoId",
                table: "Casos");

            migrationBuilder.DropTable(
                name: "Impuestos");

            migrationBuilder.DropTable(
                name: "Despachos");

            migrationBuilder.DropTable(
                name: "Declaraciones");

            migrationBuilder.DropIndex(
                name: "IX_Casos_TrasladoId",
                table: "Casos");

            migrationBuilder.DropColumn(
                name: "SolicitudId",
                table: "Carros");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SolicitudId",
                table: "Carros",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Declaraciones",
                columns: table => new
                {
                    DeclaracionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaEntrega = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SolicitudId = table.Column<int>(type: "int", nullable: false),
                    ValorMercancia = table.Column<double>(type: "float", nullable: false),
                    ValorTransportacion = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Declaraciones", x => x.DeclaracionId);
                    table.ForeignKey(
                        name: "FK_Declaraciones_AspNetUsers_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Despachos",
                columns: table => new
                {
                    SolicitudId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarroId = table.Column<int>(type: "int", nullable: false),
                    DeclaracionId = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    FechaSolicitud = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Localizacion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    NombreEmpresa = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Despachos", x => x.SolicitudId);
                    table.ForeignKey(
                        name: "FK_Despachos_AspNetUsers_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Despachos_Carros_CarroId",
                        column: x => x.CarroId,
                        principalTable: "Carros",
                        principalColumn: "CarroId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Despachos_Declaraciones_DeclaracionId",
                        column: x => x.DeclaracionId,
                        principalTable: "Declaraciones",
                        principalColumn: "DeclaracionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Impuestos",
                columns: table => new
                {
                    ImpuestoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SolicitudId = table.Column<int>(type: "int", nullable: true),
                    Monto = table.Column<double>(type: "float", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Valor = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Impuestos", x => x.ImpuestoId);
                    table.ForeignKey(
                        name: "FK_Impuestos_Despachos_SolicitudId",
                        column: x => x.SolicitudId,
                        principalTable: "Despachos",
                        principalColumn: "SolicitudId");
                });

            migrationBuilder.InsertData(
                table: "Impuestos",
                columns: new[] { "ImpuestoId", "Monto", "Nombre", "SolicitudId", "Valor" },
                values: new object[,]
                {
                    { 1, 0.0, "Tasa por Servicio Aduanero", null, 0.0 },
                    { 2, 0.0, "Arancelarios", null, 0.0 },
                    { 3, 0.0, "ITBIS", null, 0.0 },
                    { 4, 0.0, "Declaracion del Valor", null, 0.0 },
                    { 5, 0.0, "Recargos por Declaracion Tardia", null, 0.0 },
                    { 6, 0.0, "Declaracion Unica Aduanera", null, 0.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Casos_TrasladoId",
                table: "Casos",
                column: "TrasladoId");

            migrationBuilder.CreateIndex(
                name: "IX_Declaraciones_UsuarioId",
                table: "Declaraciones",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Despachos_CarroId",
                table: "Despachos",
                column: "CarroId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Despachos_DeclaracionId",
                table: "Despachos",
                column: "DeclaracionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Despachos_UsuarioId",
                table: "Despachos",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Impuestos_SolicitudId",
                table: "Impuestos",
                column: "SolicitudId");

            migrationBuilder.AddForeignKey(
                name: "FK_Casos_Traslados_TrasladoId",
                table: "Casos",
                column: "TrasladoId",
                principalTable: "Traslados",
                principalColumn: "TrasladoId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
