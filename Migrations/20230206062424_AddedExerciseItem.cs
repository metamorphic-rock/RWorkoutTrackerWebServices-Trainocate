using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace workoutTrackerServices.Migrations
{
    /// <inheritdoc />
    public partial class AddedExerciseItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ExerciseId",
                table: "SetItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ExerciseItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExerciseName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseItems", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SetItems_ExerciseId",
                table: "SetItems",
                column: "ExerciseId");

            migrationBuilder.AddForeignKey(
                name: "FK_SetItems_ExerciseItems_ExerciseId",
                table: "SetItems",
                column: "ExerciseId",
                principalTable: "ExerciseItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SetItems_ExerciseItems_ExerciseId",
                table: "SetItems");

            migrationBuilder.DropTable(
                name: "ExerciseItems");

            migrationBuilder.DropIndex(
                name: "IX_SetItems_ExerciseId",
                table: "SetItems");

            migrationBuilder.DropColumn(
                name: "ExerciseId",
                table: "SetItems");
        }
    }
}
