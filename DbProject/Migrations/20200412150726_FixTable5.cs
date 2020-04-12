using Microsoft.EntityFrameworkCore.Migrations;

namespace DbProject.Migrations
{
    public partial class FixTable5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreditHours",
                table: "Course");

            migrationBuilder.AddColumn<ushort>(
                name: "CreditHours",
                table: "GradeReceived",
                nullable: false,
                defaultValue: (ushort)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreditHours",
                table: "GradeReceived");

            migrationBuilder.AddColumn<ushort>(
                name: "CreditHours",
                table: "Course",
                type: "smallint unsigned",
                nullable: false,
                defaultValue: (ushort)0);
        }
    }
}
