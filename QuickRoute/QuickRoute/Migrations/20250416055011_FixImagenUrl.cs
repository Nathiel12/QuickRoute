using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace QuickRoute.Migrations
{
    /// <inheritdoc />
    public partial class FixImagenUrl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carros_AspNetUsers_Id",
                table: "Carros");

            migrationBuilder.DropForeignKey(
                name: "FK_Carros_Traslados_TrasladoId",
                table: "Carros");

            migrationBuilder.DropForeignKey(
                name: "FK_Traslados_AspNetUsers_Id",
                table: "Traslados");

            migrationBuilder.DropIndex(
                name: "IX_Carros_Id",
                table: "Carros");

            migrationBuilder.DropColumn(
                name: "Aprobado",
                table: "Carros");

            migrationBuilder.DropColumn(
                name: "FechaRegistro",
                table: "Carros");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Carros");

            migrationBuilder.DropColumn(
                name: "NumeroTitulo",
                table: "Carros");

            migrationBuilder.RenameColumn(
                name: "TrasladoId",
                table: "Carros",
                newName: "TrasladosTrasladoId");

            migrationBuilder.RenameColumn(
                name: "EnTraslado",
                table: "Carros",
                newName: "Disponibilidad");

            migrationBuilder.RenameIndex(
                name: "IX_Carros_TrasladoId",
                table: "Carros",
                newName: "IX_Carros_TrasladosTrasladoId");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Traslados",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "Sugerencias",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "Casos",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Modelo",
                table: "Carros",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "Marca",
                table: "Carros",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "Color",
                table: "Carros",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Carros",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CantidadStock",
                table: "Carros",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ImagenUrl",
                table: "Carros",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Carritos",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CarritoId = table.Column<int>(type: "int", nullable: false),
                    CarroId = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    FechaAgregado = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carritos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carritos_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Carritos_Carros_CarroId",
                        column: x => x.CarroId,
                        principalTable: "Carros",
                        principalColumn: "CarroId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ordenes",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OrdenId = table.Column<int>(type: "int", nullable: false),
                    FechaOrden = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Total = table.Column<double>(type: "float", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ordenes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ordenes_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
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
                    PrecioUnitario = table.Column<double>(type: "float", nullable: false),
                    OrdenId1 = table.Column<string>(type: "nvarchar(450)", nullable: true)
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
                        name: "FK_OrdenDetalles_Ordenes_OrdenId1",
                        column: x => x.OrdenId1,
                        principalTable: "Ordenes",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Carros",
                columns: new[] { "CarroId", "ApplicationUserId", "CantidadStock", "Color", "Disponibilidad", "FechaFabricacion", "ImagenUrl", "Marca", "Modelo", "Precio", "TrasladosTrasladoId" },
                values: new object[,]
                {
                    { 1, null, 10, "Azul", true, new DateTime(2011, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "/img/carros/default.jpg", "Honda", "Civic", 24250.0, null },
                    { 2, null, 15, "Rojo", true, new DateTime(2011, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "/img/carros/default.jpg", "Honda", "Civic", 25800.0, null },
                    { 3, null, 5, "Rojo", true, new DateTime(2014, 6, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "/img/carros/default.jpg", "Toyota", "Corolla", 22325.0, null },
                    { 4, null, 6, "Blanco", true, new DateTime(2018, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "/img/carros/default.jpg", "Toyota", "Camry", 29795.0, null },
                    { 5, null, 9, "Negro", true, new DateTime(2015, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "/img/carros/default.jpg", "Audi", "a4", 44100.0, null },
                    { 6, null, 7, "Amarillo", true, new DateTime(2016, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "/img/carros/default.jpg", "BMW", "m4", 80875.0, null },
                    { 7, null, 8, "Rojo", true, new DateTime(2020, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "/img/carros/default.jpg", "Ford", "Mustang", 42865.0, null },
                    { 8, null, 5, "Negro", true, new DateTime(2019, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "/img/carros/default.jpg", "Chevrolet", "Camaro", 37695.0, null },
                    { 9, null, 12, "Blanco", true, new DateTime(2017, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "/img/carros/default.jpg", "Volkswagen", "Golf", 23995.0, null },
                    { 10, null, 6, "Plateado", true, new DateTime(2018, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "/img/carros/default.jpg", "Mercedes-Benz", "C-Class", 55150.0, null },
                    { 11, null, 9, "Gris", true, new DateTime(2021, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "/img/carros/default.jpg", "Nissan", "Sentra", 21510.0, null },
                    { 12, null, 7, "Azul Marino", true, new DateTime(2020, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "/img/carros/default.jpg", "Hyundai", "Tucson", 27650.0, null },
                    { 13, null, 4, "Verde", true, new DateTime(2019, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "/img/carros/default.jpg", "Kia", "Sportage", 26490.0, null },
                    { 14, null, 5, "Marrón", true, new DateTime(2021, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "/img/carros/default.jpg", "Subaru", "Outback", 31995.0, null },
                    { 15, null, 8, "Rojo Carmesí", true, new DateTime(2020, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "/img/carros/default.jpg", "Mazda", "CX-5", 29185.0, null },
                    { 16, null, 3, "Amarillo", true, new DateTime(2022, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "/img/carros/default.jpg", "Jeep", "Wrangler", 39995.0, null },
                    { 17, null, 6, "Blanco", true, new DateTime(2021, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "/img/carros/default.jpg", "Tesla", "Model 3", 46990.0, null },
                    { 18, null, 4, "Gris Perla", true, new DateTime(2019, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "/img/carros/default.jpg", "Lexus", "RX 350", 51275.0, null },
                    { 19, null, 2, "Negro", true, new DateTime(2020, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "/img/carros/default.jpg", "Porsche", "911", 113200.0, null },
                    { 20, null, 3, "Plateado", true, new DateTime(2018, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "/img/carros/default.jpg", "Land Rover", "Range Rover", 98500.0, null },
                    { 21, null, 5, "Azul Oscuro", true, new DateTime(2021, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "/img/carros/default.jpg", "Volvo", "XC60", 45950.0, null },
                    { 22, null, 1, "Rojo", true, new DateTime(2022, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "/img/carros/default.jpg", "Ferrari", "488 GTB", 335000.0, null },
                    { 23, null, 1, "Amarillo", true, new DateTime(2021, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "/img/carros/default.jpg", "Lamborghini", "Huracán", 261274.0, null },
                    { 24, null, 7, "Gris Plata", true, new DateTime(2020, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "/img/carros/default.jpg", "Mitsubishi", "Outlander", 28795.0, null },
                    { 25, null, 4, "Negro", true, new DateTime(2019, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "/img/carros/default.jpg", "Dodge", "Charger", 36665.0, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sugerencias_Id",
                table: "Sugerencias",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Casos_Id",
                table: "Casos",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Carros_ApplicationUserId",
                table: "Carros",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Carritos_CarroId",
                table: "Carritos",
                column: "CarroId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenDetalles_CarroId",
                table: "OrdenDetalles",
                column: "CarroId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenDetalles_OrdenId1",
                table: "OrdenDetalles",
                column: "OrdenId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Carros_AspNetUsers_ApplicationUserId",
                table: "Carros",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Carros_Traslados_TrasladosTrasladoId",
                table: "Carros",
                column: "TrasladosTrasladoId",
                principalTable: "Traslados",
                principalColumn: "TrasladoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Casos_AspNetUsers_Id",
                table: "Casos",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sugerencias_AspNetUsers_Id",
                table: "Sugerencias",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Traslados_AspNetUsers_Id",
                table: "Traslados",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carros_AspNetUsers_ApplicationUserId",
                table: "Carros");

            migrationBuilder.DropForeignKey(
                name: "FK_Carros_Traslados_TrasladosTrasladoId",
                table: "Carros");

            migrationBuilder.DropForeignKey(
                name: "FK_Casos_AspNetUsers_Id",
                table: "Casos");

            migrationBuilder.DropForeignKey(
                name: "FK_Sugerencias_AspNetUsers_Id",
                table: "Sugerencias");

            migrationBuilder.DropForeignKey(
                name: "FK_Traslados_AspNetUsers_Id",
                table: "Traslados");

            migrationBuilder.DropTable(
                name: "Carritos");

            migrationBuilder.DropTable(
                name: "OrdenDetalles");

            migrationBuilder.DropTable(
                name: "Ordenes");

            migrationBuilder.DropIndex(
                name: "IX_Sugerencias_Id",
                table: "Sugerencias");

            migrationBuilder.DropIndex(
                name: "IX_Casos_Id",
                table: "Casos");

            migrationBuilder.DropIndex(
                name: "IX_Carros_ApplicationUserId",
                table: "Carros");

            migrationBuilder.DeleteData(
                table: "Carros",
                keyColumn: "CarroId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Carros",
                keyColumn: "CarroId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Carros",
                keyColumn: "CarroId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Carros",
                keyColumn: "CarroId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Carros",
                keyColumn: "CarroId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Carros",
                keyColumn: "CarroId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Carros",
                keyColumn: "CarroId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Carros",
                keyColumn: "CarroId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Carros",
                keyColumn: "CarroId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Carros",
                keyColumn: "CarroId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Carros",
                keyColumn: "CarroId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Carros",
                keyColumn: "CarroId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Carros",
                keyColumn: "CarroId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Carros",
                keyColumn: "CarroId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Carros",
                keyColumn: "CarroId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Carros",
                keyColumn: "CarroId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Carros",
                keyColumn: "CarroId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Carros",
                keyColumn: "CarroId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Carros",
                keyColumn: "CarroId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Carros",
                keyColumn: "CarroId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Carros",
                keyColumn: "CarroId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Carros",
                keyColumn: "CarroId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Carros",
                keyColumn: "CarroId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Carros",
                keyColumn: "CarroId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Carros",
                keyColumn: "CarroId",
                keyValue: 25);

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Sugerencias");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Casos");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Carros");

            migrationBuilder.DropColumn(
                name: "CantidadStock",
                table: "Carros");

            migrationBuilder.DropColumn(
                name: "ImagenUrl",
                table: "Carros");

            migrationBuilder.RenameColumn(
                name: "TrasladosTrasladoId",
                table: "Carros",
                newName: "TrasladoId");

            migrationBuilder.RenameColumn(
                name: "Disponibilidad",
                table: "Carros",
                newName: "EnTraslado");

            migrationBuilder.RenameIndex(
                name: "IX_Carros_TrasladosTrasladoId",
                table: "Carros",
                newName: "IX_Carros_TrasladoId");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Traslados",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Modelo",
                table: "Carros",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Marca",
                table: "Carros",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Color",
                table: "Carros",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<bool>(
                name: "Aprobado",
                table: "Carros",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaRegistro",
                table: "Carros",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "Carros",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NumeroTitulo",
                table: "Carros",
                type: "nvarchar(17)",
                maxLength: 17,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Carros_Id",
                table: "Carros",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Carros_AspNetUsers_Id",
                table: "Carros",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Carros_Traslados_TrasladoId",
                table: "Carros",
                column: "TrasladoId",
                principalTable: "Traslados",
                principalColumn: "TrasladoId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Traslados_AspNetUsers_Id",
                table: "Traslados",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
