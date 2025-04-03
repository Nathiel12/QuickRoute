using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuickRoute.Migrations
{
    /// <inheritdoc />
    public partial class UserCarroRestrict : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carros_AspNetUsers_Id",
                table: "Carros");

            migrationBuilder.AddForeignKey(
                name: "FK_Carros_AspNetUsers_Id",
                table: "Carros",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carros_AspNetUsers_Id",
                table: "Carros");

            migrationBuilder.AddForeignKey(
                name: "FK_Carros_AspNetUsers_Id",
                table: "Carros",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
