using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuickRoute.Migrations
{
    /// <inheritdoc />
    public partial class UserCar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Aprobado",
                table: "Carros",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "Carros",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UsuarioId",
                table: "Carros",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Carros_UsuarioId",
                table: "Carros",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Carros_AspNetUsers_UsuarioId",
                table: "Carros",
                column: "UsuarioId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carros_AspNetUsers_UsuarioId",
                table: "Carros");

            migrationBuilder.DropIndex(
                name: "IX_Carros_UsuarioId",
                table: "Carros");

            migrationBuilder.DropColumn(
                name: "Aprobado",
                table: "Carros");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Carros");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Carros");
        }
    }
}
