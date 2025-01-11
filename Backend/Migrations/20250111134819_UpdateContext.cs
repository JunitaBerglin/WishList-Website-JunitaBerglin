using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class UpdateContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WishListItems_Users_PurchasedByUserId",
                table: "WishListItems");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "WishListItems",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WishListItems_UserId",
                table: "WishListItems",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_WishListItems_Users_PurchasedByUserId",
                table: "WishListItems",
                column: "PurchasedByUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WishListItems_Users_UserId",
                table: "WishListItems",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WishListItems_Users_PurchasedByUserId",
                table: "WishListItems");

            migrationBuilder.DropForeignKey(
                name: "FK_WishListItems_Users_UserId",
                table: "WishListItems");

            migrationBuilder.DropIndex(
                name: "IX_WishListItems_UserId",
                table: "WishListItems");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "WishListItems");

            migrationBuilder.AddForeignKey(
                name: "FK_WishListItems_Users_PurchasedByUserId",
                table: "WishListItems",
                column: "PurchasedByUserId",
                principalTable: "Users",
                principalColumn: "UserId");
        }
    }
}
