using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuickRoute.Migrations
{
    /// <inheritdoc />
    public partial class Votacion_User : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "Votaciones",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Votaciones_Id",
                table: "Votaciones",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Votaciones_AspNetUsers_Id",
                table: "Votaciones",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Votaciones_AspNetUsers_Id",
                table: "Votaciones");

            migrationBuilder.DropIndex(
                name: "IX_Votaciones_Id",
                table: "Votaciones");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Votaciones");
        }
    }
}
