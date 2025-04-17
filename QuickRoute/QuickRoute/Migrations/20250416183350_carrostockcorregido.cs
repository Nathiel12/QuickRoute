using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuickRoute.Migrations
{
    /// <inheritdoc />
    public partial class carrostockcorregido : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Carros",
                keyColumn: "CarroId",
                keyValue: 26,
                columns: new[] { "CantidadStock", "Precio" },
                values: new object[] { 1, 2325.0 });

            migrationBuilder.UpdateData(
                table: "Carros",
                keyColumn: "CarroId",
                keyValue: 27,
                column: "CantidadStock",
                value: 25);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Carros",
                keyColumn: "CarroId",
                keyValue: 26,
                columns: new[] { "CantidadStock", "Precio" },
                values: new object[] { 5, 22325.0 });

            migrationBuilder.UpdateData(
                table: "Carros",
                keyColumn: "CarroId",
                keyValue: 27,
                column: "CantidadStock",
                value: 5);
        }
    }
}
