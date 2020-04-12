using Microsoft.EntityFrameworkCore.Migrations;

namespace DbProject.Migrations
{
    public partial class FixTable3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreditHours",
                table: "GradeReceived");

            migrationBuilder.AddColumn<ushort>(
                name: "Grade",
                table: "GradeReceived",
                nullable: false,
                defaultValue: (ushort)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Grade",
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
