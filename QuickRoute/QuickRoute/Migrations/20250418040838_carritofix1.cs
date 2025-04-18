using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace QuickRoute.Migrations
{
    /// <inheritdoc />
    public partial class carritofix1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contactos",
                columns: table => new
                {
                    ContactoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Telefono = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CasoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contactos", x => x.ContactoId);
                });

            migrationBuilder.CreateTable(
                name: "TipoVehiculos",
                columns: table => new
                {
                    TipoVehiculoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehiculoNombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PuntuacionTotal = table.Column<int>(type: "int", nullable: false),
                    PuntuacionPromedio = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoVehiculos", x => x.TipoVehiculoId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Direcciones",
                columns: table => new
                {
                    DireccionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Provincia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ciudad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodigoPostal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Direcciones", x => x.DireccionId);
                    table.ForeignKey(
                        name: "FK_Direcciones_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ordenes",
                columns: table => new
                {
                    OrdenId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    FechaOrden = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Total = table.Column<double>(type: "float", nullable: false),
                    Pagada = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ordenes", x => x.OrdenId);
                    table.ForeignKey(
                        name: "FK_Ordenes_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Sugerencias",
                columns: table => new
                {
                    SugerenciaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Asunto = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    satisfaccion = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sugerencias", x => x.SugerenciaId);
                    table.ForeignKey(
                        name: "FK_Sugerencias_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Traslados",
                columns: table => new
                {
                    TrasladoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nombres = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Traslados", x => x.TrasladoId);
                    table.ForeignKey(
                        name: "FK_Traslados_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Votaciones",
                columns: table => new
                {
                    VotacionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaEncuesta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Votaciones", x => x.VotacionId);
                    table.ForeignKey(
                        name: "FK_Votaciones_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Casos",
                columns: table => new
                {
                    CasoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContactoId = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Asunto = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Casos", x => x.CasoId);
                    table.ForeignKey(
                        name: "FK_Casos_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Casos_Contactos_ContactoId",
                        column: x => x.ContactoId,
                        principalTable: "Contactos",
                        principalColumn: "ContactoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pagos",
                columns: table => new
                {
                    PagoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCliente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroTarjeta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaExpiracion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodigoSeguridad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrdenId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagos", x => x.PagoId);
                    table.ForeignKey(
                        name: "FK_Pagos_Ordenes_OrdenId",
                        column: x => x.OrdenId,
                        principalTable: "Ordenes",
                        principalColumn: "OrdenId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Carros",
                columns: table => new
                {
                    CarroId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Marca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Modelo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaFabricacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Precio = table.Column<double>(type: "float", nullable: false),
                    CantidadStock = table.Column<int>(type: "int", nullable: false),
                    ImagenUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Disponibilidad = table.Column<bool>(type: "bit", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TrasladosTrasladoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carros", x => x.CarroId);
                    table.ForeignKey(
                        name: "FK_Carros_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Carros_Traslados_TrasladosTrasladoId",
                        column: x => x.TrasladosTrasladoId,
                        principalTable: "Traslados",
                        principalColumn: "TrasladoId");
                });

            migrationBuilder.CreateTable(
                name: "VotacionesDetalles",
                columns: table => new
                {
                    VotacionDetalleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoVehiculoId = table.Column<int>(type: "int", nullable: false),
                    VotacionId = table.Column<int>(type: "int", nullable: false),
                    Puntuacion = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "Carrito",
                columns: table => new
                {
                    CarritoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CarroId = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    FechaAgregado = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carrito", x => x.CarritoId);
                    table.ForeignKey(
                        name: "FK_Carrito_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Carrito_Carros_CarroId",
                        column: x => x.CarroId,
                        principalTable: "Carros",
                        principalColumn: "CarroId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrdenDetalles",
                columns: table => new
                {
                    OrdenDetalleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrdenId = table.Column<int>(type: "int", nullable: false),
                    CarroId = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    PrecioUnitario = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdenDetalles", x => x.OrdenDetalleId);
                    table.ForeignKey(
                        name: "FK_OrdenDetalles_Carros_CarroId",
                        column: x => x.CarroId,
                        principalTable: "Carros",
                        principalColumn: "CarroId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrdenDetalles_Ordenes_OrdenId",
                        column: x => x.OrdenId,
                        principalTable: "Ordenes",
                        principalColumn: "OrdenId",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.InsertData(
                table: "Carros",
                columns: new[] { "CarroId", "ApplicationUserId", "CantidadStock", "Color", "Disponibilidad", "FechaFabricacion", "ImagenUrl", "Marca", "Modelo", "Precio", "TrasladosTrasladoId" },
                values: new object[,]
                {
                    { 1, null, 10, "Azul", true, new DateTime(2011, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "/img/carros/1.jpg", "Honda", "Civic", 24250.0, null },
                    { 2, null, 15, "Rojo", true, new DateTime(2011, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "/img/carros/2.jpg", "Honda", "Civic", 25800.0, null },
                    { 3, null, 5, "Rojo", true, new DateTime(2014, 6, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "/img/carros/3.jpg", "Toyota", "Corolla", 22325.0, null },
                    { 4, null, 6, "Blanco", true, new DateTime(2018, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "/img/carros/4.jpg", "Toyota", "Camry", 29795.0, null },
                    { 5, null, 9, "Negro", true, new DateTime(2015, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "/img/carros/5.jpg", "Audi", "a4", 44100.0, null },
                    { 6, null, 7, "Amarillo", true, new DateTime(2016, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "/img/carros/6.jpg", "BMW", "m4", 80875.0, null },
                    { 7, null, 8, "Rojo", true, new DateTime(2020, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "/img/carros/7.jpg", "Ford", "Mustang", 42865.0, null },
                    { 8, null, 5, "Negro", true, new DateTime(2019, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "/img/carros/8.jpg", "Chevrolet", "Camaro", 37695.0, null },
                    { 9, null, 12, "Blanco", true, new DateTime(2017, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "/img/carros/9.jpg", "Volkswagen", "Golf", 23995.0, null },
                    { 10, null, 6, "Plateado", true, new DateTime(2018, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "/img/carros/10.jpg", "Mercedes-Benz", "C-Class", 55150.0, null },
                    { 11, null, 9, "Gris", true, new DateTime(2021, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "/img/carros/11.jpg", "Nissan", "Sentra", 21510.0, null },
                    { 12, null, 7, "Azul Marino", true, new DateTime(2020, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "/img/carros/12.jpg", "Hyundai", "Tucson", 27650.0, null },
                    { 13, null, 4, "Verde", true, new DateTime(2019, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "/img/carros/13.jpg", "Kia", "Sportage", 26490.0, null },
                    { 14, null, 5, "Marrón", true, new DateTime(2021, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "/img/carros/14.jpg", "Subaru", "Outback", 31995.0, null },
                    { 15, null, 8, "Rojo Carmesí", true, new DateTime(2020, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "/img/carros/15.jpg", "Mazda", "CX-5", 29185.0, null },
                    { 16, null, 3, "Amarillo", true, new DateTime(2022, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "/img/carros/16.jpg", "Jeep", "Wrangler", 39995.0, null },
                    { 17, null, 6, "Blanco", true, new DateTime(2021, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "/img/carros/17.jpg", "Tesla", "Model 3", 46990.0, null },
                    { 18, null, 4, "Gris Perla", true, new DateTime(2019, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "/img/carros/18.jpg", "Lexus", "RX 350", 51275.0, null },
                    { 19, null, 2, "Negro", true, new DateTime(2020, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "/img/carros/19.jpg", "Porsche", "911", 113200.0, null },
                    { 20, null, 3, "Plateado", true, new DateTime(2018, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "/img/carros/20.jpg", "Land Rover", "Range Rover", 98500.0, null },
                    { 21, null, 5, "Azul Oscuro", true, new DateTime(2021, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "/img/carros/21.jpg", "Volvo", "XC60", 45950.0, null },
                    { 22, null, 1, "Rojo", true, new DateTime(2022, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "/img/carros/22.jpg", "Ferrari", "488 GTB", 335000.0, null },
                    { 23, null, 1, "Amarillo", true, new DateTime(2021, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "/img/carros/23.jpg", "Lamborghini", "Huracán", 261274.0, null },
                    { 24, null, 7, "Gris Plata", true, new DateTime(2020, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "/img/carros/24.jpg", "Mitsubishi", "Outlander", 28795.0, null },
                    { 25, null, 4, "Negro", true, new DateTime(2019, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "/img/carros/25.jpg", "Dodge", "Charger", 36665.0, null },
                    { 26, null, 1, "Azul", true, new DateTime(1998, 6, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "/img/carros/26.jpg", "Toyota", "Corolla", 2325.0, null },
                    { 27, null, 25, "Negro", true, new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "/img/carros/27.jpg", "Toyota", "Corolla", 22325.0, null }
                });

            migrationBuilder.InsertData(
                table: "TipoVehiculos",
                columns: new[] { "TipoVehiculoId", "PuntuacionPromedio", "PuntuacionTotal", "VehiculoNombre" },
                values: new object[,]
                {
                    { 1, 0.0, 0, "Moticicleta" },
                    { 2, 0.0, 0, "Camión" },
                    { 3, 0.0, 0, "Excavadora" },
                    { 4, 0.0, 0, "Autobús" },
                    { 5, 0.0, 0, "Camión de Remolque" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Carrito_CarroId",
                table: "Carrito",
                column: "CarroId");

            migrationBuilder.CreateIndex(
                name: "IX_Carrito_Id",
                table: "Carrito",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Carros_ApplicationUserId",
                table: "Carros",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Carros_TrasladosTrasladoId",
                table: "Carros",
                column: "TrasladosTrasladoId");

            migrationBuilder.CreateIndex(
                name: "IX_Casos_ContactoId",
                table: "Casos",
                column: "ContactoId");

            migrationBuilder.CreateIndex(
                name: "IX_Casos_Id",
                table: "Casos",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Direcciones_Id",
                table: "Direcciones",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenDetalles_CarroId",
                table: "OrdenDetalles",
                column: "CarroId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenDetalles_OrdenId",
                table: "OrdenDetalles",
                column: "OrdenId");

            migrationBuilder.CreateIndex(
                name: "IX_Ordenes_Id",
                table: "Ordenes",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Pagos_OrdenId",
                table: "Pagos",
                column: "OrdenId");

            migrationBuilder.CreateIndex(
                name: "IX_Sugerencias_Id",
                table: "Sugerencias",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Traslados_Id",
                table: "Traslados",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_TrasladosDetalles_CarroId",
                table: "TrasladosDetalles",
                column: "CarroId");

            migrationBuilder.CreateIndex(
                name: "IX_TrasladosDetalles_TrasladoId",
                table: "TrasladosDetalles",
                column: "TrasladoId");

            migrationBuilder.CreateIndex(
                name: "IX_Votaciones_Id",
                table: "Votaciones",
                column: "Id");

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
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Carrito");

            migrationBuilder.DropTable(
                name: "Casos");

            migrationBuilder.DropTable(
                name: "Direcciones");

            migrationBuilder.DropTable(
                name: "OrdenDetalles");

            migrationBuilder.DropTable(
                name: "Pagos");

            migrationBuilder.DropTable(
                name: "Sugerencias");

            migrationBuilder.DropTable(
                name: "TrasladosDetalles");

            migrationBuilder.DropTable(
                name: "VotacionesDetalles");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Contactos");

            migrationBuilder.DropTable(
                name: "Ordenes");

            migrationBuilder.DropTable(
                name: "Carros");

            migrationBuilder.DropTable(
                name: "TipoVehiculos");

            migrationBuilder.DropTable(
                name: "Votaciones");

            migrationBuilder.DropTable(
                name: "Traslados");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
