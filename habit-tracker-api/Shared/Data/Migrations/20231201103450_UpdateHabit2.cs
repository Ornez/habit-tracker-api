using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace habit_tracker_api.Shared.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateHabit2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TimePeriod_Habits_HabitId",
                table: "TimePeriod");

            migrationBuilder.AlterColumn<int>(
                name: "HabitId",
                table: "TimePeriod",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TimePeriod_Habits_HabitId",
                table: "TimePeriod",
                column: "HabitId",
                principalTable: "Habits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TimePeriod_Habits_HabitId",
                table: "TimePeriod");

            migrationBuilder.AlterColumn<int>(
                name: "HabitId",
                table: "TimePeriod",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_TimePeriod_Habits_HabitId",
                table: "TimePeriod",
                column: "HabitId",
                principalTable: "Habits",
                principalColumn: "Id");
        }
    }
}
