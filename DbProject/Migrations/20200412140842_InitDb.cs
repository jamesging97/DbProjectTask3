using Microsoft.EntityFrameworkCore.Migrations;

namespace DbProject.Migrations
{
    public partial class InitDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    CourseId = table.Column<string>(nullable: false),
                    InstructorID = table.Column<string>(nullable: false),
                    CreditHours = table.Column<ushort>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.CourseId);
                });

            migrationBuilder.CreateTable(
                name: "GradeReceived",
                columns: table => new
                {
                    StudentId = table.Column<string>(nullable: false),
                    InstructorId = table.Column<string>(nullable: false),
                    CreditHours = table.Column<ushort>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GradeReceived", x => new { x.StudentId, x.InstructorId });
                });

            migrationBuilder.CreateTable(
                name: "Instructor",
                columns: table => new
                {
                    InstructorId = table.Column<string>(nullable: false),
                    InstructorName = table.Column<string>(nullable: true),
                    Department = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructor", x => x.InstructorId);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    StudentId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    GPA = table.Column<double>(nullable: false),
                    CreditsEarned = table.Column<ushort>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.StudentId);
                });

            migrationBuilder.CreateTable(
                name: "Teaches",
                columns: table => new
                {
                    CourseId = table.Column<string>(nullable: false),
                    InstructorId = table.Column<string>(nullable: false),
                    Semester = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teaches", x => new { x.CourseId, x.InstructorId });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "GradeReceived");

            migrationBuilder.DropTable(
                name: "Instructor");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Teaches");
        }
    }
}
