using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace habit_tracker_api.Shared.Data.Migrations
{
    /// <inheritdoc />
    public partial class TimePeriod : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TimePeriod_Habits_HabitId",
                table: "TimePeriod");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TimePeriod",
                table: "TimePeriod");

            migrationBuilder.RenameTable(
                name: "TimePeriod",
                newName: "Occurrences");

            migrationBuilder.RenameIndex(
                name: "IX_TimePeriod_HabitId",
                table: "Occurrences",
                newName: "IX_Occurrences_HabitId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Occurrences",
                table: "Occurrences",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Occurrences_Habits_HabitId",
                table: "Occurrences",
                column: "HabitId",
                principalTable: "Habits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Occurrences_Habits_HabitId",
                table: "Occurrences");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Occurrences",
                table: "Occurrences");

            migrationBuilder.RenameTable(
                name: "Occurrences",
                newName: "TimePeriod");

            migrationBuilder.RenameIndex(
                name: "IX_Occurrences_HabitId",
                table: "TimePeriod",
                newName: "IX_TimePeriod_HabitId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TimePeriod",
                table: "TimePeriod",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TimePeriod_Habits_HabitId",
                table: "TimePeriod",
                column: "HabitId",
                principalTable: "Habits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
