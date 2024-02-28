using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NetRestaurantAPI.Migrations
{
    /// <inheritdoc />
    public partial class newMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Autenticado",
                table: "Usuarios",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Telefone",
                table: "Usuarios",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Autenticado",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Telefone",
                table: "Usuarios");
        }
    }
}
