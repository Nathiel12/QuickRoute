using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuickRoute.Migrations
{
    /// <inheritdoc />
    public partial class CarritoFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carritos_AspNetUsers_Id",
                table: "Carritos");

            migrationBuilder.DropForeignKey(
                name: "FK_Carritos_Carros_CarroId",
                table: "Carritos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Carritos",
                table: "Carritos");

            migrationBuilder.RenameTable(
                name: "Carritos",
                newName: "Carrito");

            migrationBuilder.RenameIndex(
                name: "IX_Carritos_CarroId",
                table: "Carrito",
                newName: "IX_Carrito_CarroId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Carrito",
                table: "Carrito",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Carrito_AspNetUsers_Id",
                table: "Carrito",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Carrito_Carros_CarroId",
                table: "Carrito",
                column: "CarroId",
                principalTable: "Carros",
                principalColumn: "CarroId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carrito_AspNetUsers_Id",
                table: "Carrito");

            migrationBuilder.DropForeignKey(
                name: "FK_Carrito_Carros_CarroId",
                table: "Carrito");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Carrito",
                table: "Carrito");

            migrationBuilder.RenameTable(
                name: "Carrito",
                newName: "Carritos");

            migrationBuilder.RenameIndex(
                name: "IX_Carrito_CarroId",
                table: "Carritos",
                newName: "IX_Carritos_CarroId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Carritos",
                table: "Carritos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Carritos_AspNetUsers_Id",
                table: "Carritos",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Carritos_Carros_CarroId",
                table: "Carritos",
                column: "CarroId",
                principalTable: "Carros",
                principalColumn: "CarroId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
