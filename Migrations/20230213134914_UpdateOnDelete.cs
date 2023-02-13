using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace workoutTrackerServices.Migrations
{
    /// <inheritdoc />
    public partial class UpdateOnDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WorkoutItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkoutTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExerciseItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExerciseName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MuscleGroup = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkoutId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExerciseItems_WorkoutItems_WorkoutId",
                        column: x => x.WorkoutId,
                        principalTable: "WorkoutItems",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SetItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExerciseName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Weight = table.Column<float>(type: "real", nullable: false),
                    Reps = table.Column<int>(type: "int", nullable: false),
                    ExerciseId = table.Column<int>(type: "int", nullable: false),
                    WorkoutId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SetItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SetItems_ExerciseItems_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "ExerciseItems",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SetItems_WorkoutItems_WorkoutId",
                        column: x => x.WorkoutId,
                        principalTable: "WorkoutItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseItems_WorkoutId",
                table: "ExerciseItems",
                column: "WorkoutId");

            migrationBuilder.CreateIndex(
                name: "IX_SetItems_ExerciseId",
                table: "SetItems",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_SetItems_WorkoutId",
                table: "SetItems",
                column: "WorkoutId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SetItems");

            migrationBuilder.DropTable(
                name: "ExerciseItems");

            migrationBuilder.DropTable(
                name: "WorkoutItems");
        }
    }
}
