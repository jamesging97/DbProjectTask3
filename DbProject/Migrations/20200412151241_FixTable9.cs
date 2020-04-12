using Microsoft.EntityFrameworkCore.Migrations;

namespace DbProject.Migrations
{
    public partial class FixTable9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_GradeReceived",
                table: "GradeReceived");

            migrationBuilder.AlterColumn<string>(
                name: "Semester",
                table: "GradeReceived",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_GradeReceived",
                table: "GradeReceived",
                columns: new[] { "StudentId", "CourseId", "Semester" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_GradeReceived",
                table: "GradeReceived");

            migrationBuilder.AlterColumn<string>(
                name: "Semester",
                table: "GradeReceived",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddPrimaryKey(
                name: "PK_GradeReceived",
                table: "GradeReceived",
                columns: new[] { "StudentId", "CourseId" });
        }
    }
}
