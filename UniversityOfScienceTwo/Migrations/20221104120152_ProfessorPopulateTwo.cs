using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityOfScienceTwo.Migrations
{
    public partial class ProfessorPopulateTwo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProfessorId",
                table: "Course",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Course_ProfessorId",
                table: "Course",
                column: "ProfessorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Professor_ProfessorId",
                table: "Course",
                column: "ProfessorId",
                principalTable: "Professor",
                principalColumn: "ProfessorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_Professor_ProfessorId",
                table: "Course");

            migrationBuilder.DropIndex(
                name: "IX_Course_ProfessorId",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "ProfessorId",
                table: "Course");
        }
    }
}
