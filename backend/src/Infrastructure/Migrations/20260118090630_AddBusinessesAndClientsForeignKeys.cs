using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddBusinessesAndClientsForeignKeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_clients_business_id",
                table: "clients",
                column: "business_id");

            migrationBuilder.CreateIndex(
                name: "IX_businesses_user_id",
                table: "businesses",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_businesses_users_user_id",
                table: "businesses",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_clients_businesses_business_id",
                table: "clients",
                column: "business_id",
                principalTable: "businesses",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_businesses_users_user_id",
                table: "businesses");

            migrationBuilder.DropForeignKey(
                name: "FK_clients_businesses_business_id",
                table: "clients");

            migrationBuilder.DropIndex(
                name: "IX_clients_business_id",
                table: "clients");

            migrationBuilder.DropIndex(
                name: "IX_businesses_user_id",
                table: "businesses");
        }
    }
}
