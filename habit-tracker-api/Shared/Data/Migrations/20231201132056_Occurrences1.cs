using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace habit_tracker_api.Shared.Data.Migrations
{
    /// <inheritdoc />
    public partial class Occurrences1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Habits_AspNetUsers_UserId",
                table: "Habits");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Habits",
                newName: "AppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Habits_UserId",
                table: "Habits",
                newName: "IX_Habits_AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Habits_AspNetUsers_AppUserId",
                table: "Habits",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Habits_AspNetUsers_AppUserId",
                table: "Habits");

            migrationBuilder.RenameColumn(
                name: "AppUserId",
                table: "Habits",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Habits_AppUserId",
                table: "Habits",
                newName: "IX_Habits_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Habits_AspNetUsers_UserId",
                table: "Habits",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
