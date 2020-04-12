using Microsoft.EntityFrameworkCore.Migrations;

namespace DbProject.Migrations
{
    public partial class FixTable2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_GradeReceived",
                table: "GradeReceived");

            migrationBuilder.DropColumn(
                name: "InstructorId",
                table: "GradeReceived");

            migrationBuilder.AddColumn<string>(
                name: "CourseId",
                table: "GradeReceived",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GradeReceived",
                table: "GradeReceived",
                columns: new[] { "StudentId", "CourseId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_GradeReceived",
                table: "GradeReceived");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "GradeReceived");

            migrationBuilder.AddColumn<string>(
                name: "InstructorId",
                table: "GradeReceived",
                type: "varchar(255) CHARACTER SET utf8mb4",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GradeReceived",
                table: "GradeReceived",
                columns: new[] { "StudentId", "InstructorId" });
        }
    }
}
