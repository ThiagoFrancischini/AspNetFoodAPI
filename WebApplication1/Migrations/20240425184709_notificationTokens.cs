using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NetRestaurantAPI.Migrations
{
    /// <inheritdoc />
    public partial class notificationTokens : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "FotoEntrega",
                table: "Pedidos",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.CreateTable(
                name: "NotificationTokens",
                columns: table => new
                {
                    ExpoToken = table.Column<string>(type: "TEXT", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "TEXT", nullable: false),
                    DeviceOS = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationTokens", x => x.ExpoToken);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NotificationTokens");

            migrationBuilder.AlterColumn<string>(
                name: "FotoEntrega",
                table: "Pedidos",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);
        }
    }
}
