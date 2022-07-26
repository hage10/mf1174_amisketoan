using Microsoft.EntityFrameworkCore.Migrations;

namespace CandidateTestService.Repository.Migrations
{
    public partial class update1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Employee_EmployeeCode",
                table: "Employee",
                column: "EmployeeCode",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Employee_EmployeeCode",
                table: "Employee");
        }
    }
}
