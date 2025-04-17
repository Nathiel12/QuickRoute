using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace QuickRoute.Migrations
{
    /// <inheritdoc />
    public partial class _2carrosmas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Carros",
                columns: new[] { "CarroId", "ApplicationUserId", "CantidadStock", "Color", "Disponibilidad", "FechaFabricacion", "ImagenUrl", "Marca", "Modelo", "Precio", "TrasladosTrasladoId" },
                values: new object[,]
                {
                    { 26, null, 5, "Azul", true, new DateTime(1998, 6, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "/img/carros/26.jpg", "Toyota", "Corolla", 22325.0, null },
                    { 27, null, 5, "Negro", true, new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "/img/carros/27.jpg", "Toyota", "Corolla", 22325.0, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Carros",
                keyColumn: "CarroId",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Carros",
                keyColumn: "CarroId",
                keyValue: 27);
        }
    }
}
