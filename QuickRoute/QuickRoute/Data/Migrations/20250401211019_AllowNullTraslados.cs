using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuickRoute.Migrations
{
    /// <inheritdoc />
    public partial class AllowNullTraslados : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carros_Traslados_TrasladoId",
                table: "Carros");

            migrationBuilder.AlterColumn<int>(
                name: "TrasladoId",
                table: "Carros",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Carros_Traslados_TrasladoId",
                table: "Carros",
                column: "TrasladoId",
                principalTable: "Traslados",
                principalColumn: "TrasladoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carros_Traslados_TrasladoId",
                table: "Carros");

            migrationBuilder.AlterColumn<int>(
                name: "TrasladoId",
                table: "Carros",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Carros_Traslados_TrasladoId",
                table: "Carros",
                column: "TrasladoId",
                principalTable: "Traslados",
                principalColumn: "TrasladoId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
