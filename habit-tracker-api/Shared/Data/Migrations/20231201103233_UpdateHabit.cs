using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace habit_tracker_api.Shared.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateHabit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Per",
                table: "Habits");

            migrationBuilder.AddColumn<string>(
                name: "Frequency",
                table: "Habits",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "TimePeriod",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Start = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    End = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    HabitId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimePeriod", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TimePeriod_Habits_HabitId",
                        column: x => x.HabitId,
                        principalTable: "Habits",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TimePeriod_HabitId",
                table: "TimePeriod",
                column: "HabitId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TimePeriod");

            migrationBuilder.DropColumn(
                name: "Frequency",
                table: "Habits");

            migrationBuilder.AddColumn<int>(
                name: "Per",
                table: "Habits",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
