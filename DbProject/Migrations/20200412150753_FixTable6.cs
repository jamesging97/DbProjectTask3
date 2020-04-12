using Microsoft.EntityFrameworkCore.Migrations;

namespace DbProject.Migrations
{
    public partial class FixTable6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreditHours",
                table: "GradeReceived");

            migrationBuilder.AddColumn<ushort>(
                name: "Semester",
                table: "GradeReceived",
                nullable: false,
                defaultValue: (ushort)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Semester",
                table: "GradeReceived");

            migrationBuilder.AddColumn<ushort>(
                name: "CreditHours",
                table: "GradeReceived",
                type: "smallint unsigned",
                nullable: false,
                defaultValue: (ushort)0);
        }
    }
}
