using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuickRoute.Migrations
{
    /// <inheritdoc />
    public partial class pagos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Ordenes");

            migrationBuilder.AddColumn<bool>(
                name: "Pagada",
                table: "Ordenes",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Pagada",
                table: "Ordenes");

            migrationBuilder.AddColumn<string>(
                name: "Estado",
                table: "Ordenes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
