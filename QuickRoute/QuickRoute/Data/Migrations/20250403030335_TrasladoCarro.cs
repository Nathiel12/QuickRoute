using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuickRoute.Migrations
{
    /// <inheritdoc />
    public partial class TrasladoCarro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carros_Traslados_TrasladoId",
                table: "Carros");

            migrationBuilder.DropColumn(
                name: "Aprobado",
                table: "Traslados");

            migrationBuilder.AddForeignKey(
                name: "FK_Carros_Traslados_TrasladoId",
                table: "Carros",
                column: "TrasladoId",
                principalTable: "Traslados",
                principalColumn: "TrasladoId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carros_Traslados_TrasladoId",
                table: "Carros");

            migrationBuilder.AddColumn<bool>(
                name: "Aprobado",
                table: "Traslados",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Carros_Traslados_TrasladoId",
                table: "Carros",
                column: "TrasladoId",
                principalTable: "Traslados",
                principalColumn: "TrasladoId");
        }
    }
}
