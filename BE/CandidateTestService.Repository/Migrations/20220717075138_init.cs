using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CandidateTestService.Repository.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    Id = table.Column<byte[]>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    ModifiedAt = table.Column<DateTime>(nullable: true),
                    DepartmentName = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<byte[]>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    ModifiedAt = table.Column<DateTime>(nullable: true),
                    EmployeeCode = table.Column<string>(maxLength: 20, nullable: true),
                    FullName = table.Column<string>(maxLength: 100, nullable: true),
                    Gender = table.Column<int>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "Date", nullable: true),
                    Email = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(maxLength: 50, nullable: true),
                    DepartmentId = table.Column<byte[]>(nullable: false),
                    TelephoneNumber = table.Column<string>(maxLength: 50, nullable: true),
                    IdentityNumber = table.Column<string>(maxLength: 25, nullable: true),
                    IdentityPlace = table.Column<string>(maxLength: 255, nullable: true),
                    IdentityDate = table.Column<DateTime>(type: "Date", nullable: true),
                    Address = table.Column<string>(maxLength: 255, nullable: true),
                    BankName = table.Column<string>(maxLength: 255, nullable: true),
                    BankAccountNumber = table.Column<string>(maxLength: 25, nullable: true),
                    BankBranchName = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employee_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employee_DepartmentId",
                table: "Employee",
                column: "DepartmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Department");
        }
    }
}
