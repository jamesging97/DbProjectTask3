using Microsoft.EntityFrameworkCore.Migrations;

namespace DbProject.Migrations
{
    public partial class FixTable7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "Semester",
                table: "GradeReceived",
                nullable: false,
                oldClrType: typeof(ushort),
                oldType: "smallint unsigned");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<ushort>(
                name: "Semester",
                table: "GradeReceived",
                type: "smallint unsigned",
                nullable: false,
                oldClrType: typeof(float));
        }
    }
}
