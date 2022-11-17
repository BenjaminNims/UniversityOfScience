using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityOfScienceTwo.Migrations
{
    public partial class CoursesCreateTwo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Course",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Course");
        }
    }
}
