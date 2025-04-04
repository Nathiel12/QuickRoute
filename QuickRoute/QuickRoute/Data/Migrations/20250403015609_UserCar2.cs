using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuickRoute.Migrations
{
    /// <inheritdoc />
    public partial class UserCar2 : Migration
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
                type: "nvarchar(450)",
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
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carros_AspNetUsers_Id",
                table: "Carros");

            migrationBuilder.DropIndex(
                name: "IX_Carros_Id",
                table: "Carros");

            migrationBuilder.DropColumn(
                name: "Aprobado",
                table: "Carros");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Carros");
        }
    }
}
