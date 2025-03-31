using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace QuickRoute.Migrations
{
    /// <inheritdoc />
    public partial class Tablas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contactos",
                columns: table => new
                {
                    ContactoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CasoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contactos", x => x.ContactoId);
                });

            migrationBuilder.CreateTable(
                name: "Declaraciones",
                columns: table => new
                {
                    DeclaracionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaEntrega = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValorMercancia = table.Column<double>(type: "float", nullable: false),
                    ValorTransportacion = table.Column<double>(type: "float", nullable: false),
                    SolicitudId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioId = table.Column<string>(type: "nvarchar(450)", nullable: true)
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
                name: "Traslados",
                columns: table => new
                {
                    TrasladoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Aprobado = table.Column<bool>(type: "bit", nullable: false),
                    Monto = table.Column<double>(type: "float", nullable: false),
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Traslados", x => x.TrasladoId);
                    table.ForeignKey(
                        name: "FK_Traslados_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Carros",
                columns: table => new
                {
                    CarroId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Marca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modelo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaFabricacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Precio = table.Column<double>(type: "float", nullable: false),
                    NumeroChasis = table.Column<string>(type: "nvarchar(17)", maxLength: 17, nullable: false),
                    Factura = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    SolicitudId = table.Column<int>(type: "int", nullable: false),
                    TrasladoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carros", x => x.CarroId);
                    table.ForeignKey(
                        name: "FK_Carros_Traslados_TrasladoId",
                        column: x => x.TrasladoId,
                        principalTable: "Traslados",
                        principalColumn: "TrasladoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Casos",
                columns: table => new
                {
                    CasoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContactoId = table.Column<int>(type: "int", nullable: false),
                    TrasladoId = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Asunto = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Casos", x => x.CasoId);
                    table.ForeignKey(
                        name: "FK_Casos_Contactos_ContactoId",
                        column: x => x.ContactoId,
                        principalTable: "Contactos",
                        principalColumn: "ContactoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Casos_Traslados_TrasladoId",
                        column: x => x.TrasladoId,
                        principalTable: "Traslados",
                        principalColumn: "TrasladoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Despachos",
                columns: table => new
                {
                    SolicitudId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Localizacion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    FechaSolicitud = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NombreEmpresa = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CarroId = table.Column<int>(type: "int", nullable: false),
                    DeclaracionId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsuarioId = table.Column<string>(type: "nvarchar(450)", nullable: true)
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
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Monto = table.Column<double>(type: "float", nullable: false),
                    Valor = table.Column<double>(type: "float", nullable: false),
                    SolicitudId = table.Column<int>(type: "int", nullable: true)
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
                name: "IX_Carros_TrasladoId",
                table: "Carros",
                column: "TrasladoId");

            migrationBuilder.CreateIndex(
                name: "IX_Casos_ContactoId",
                table: "Casos",
                column: "ContactoId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Traslados_Id",
                table: "Traslados",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Casos");

            migrationBuilder.DropTable(
                name: "Impuestos");

            migrationBuilder.DropTable(
                name: "Contactos");

            migrationBuilder.DropTable(
                name: "Despachos");

            migrationBuilder.DropTable(
                name: "Carros");

            migrationBuilder.DropTable(
                name: "Declaraciones");

            migrationBuilder.DropTable(
                name: "Traslados");
        }
    }
}
