using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NetRestaurantAPI.Migrations
{
    /// <inheritdoc />
    public partial class notificationTokens2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_NotificationTokens",
                table: "NotificationTokens");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NotificationTokens",
                table: "NotificationTokens",
                column: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_NotificationTokens",
                table: "NotificationTokens");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NotificationTokens",
                table: "NotificationTokens",
                column: "ExpoToken");
        }
    }
}
