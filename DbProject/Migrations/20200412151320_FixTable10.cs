using Microsoft.EntityFrameworkCore.Migrations;

namespace DbProject.Migrations
{
    public partial class FixTable10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_GradeReceived",
                table: "GradeReceived");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GradeReceived",
                table: "GradeReceived",
                columns: new[] { "StudentId", "CourseId", "Semester", "Grade" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_GradeReceived",
                table: "GradeReceived");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GradeReceived",
                table: "GradeReceived",
                columns: new[] { "StudentId", "CourseId", "Semester" });
        }
    }
}
