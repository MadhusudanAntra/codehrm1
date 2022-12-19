using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnBoarding.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployeeCategories",
                columns: table => new
                {
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeCategories", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeRoles",
                columns: table => new
                {
                    RoleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeRoles", x => x.RoleID);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeStatuses",
                columns: table => new
                {
                    StatusID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeStatuses", x => x.StatusID);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SSN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmployeeCategoryCodeCategoryID = table.Column<int>(type: "int", nullable: false),
                    EmployeeStatusCodeStatusID = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeRoleIdRoleID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employees_EmployeeCategories_EmployeeCategoryCodeCategoryID",
                        column: x => x.EmployeeCategoryCodeCategoryID,
                        principalTable: "EmployeeCategories",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_EmployeeRoles_EmployeeRoleIdRoleID",
                        column: x => x.EmployeeRoleIdRoleID,
                        principalTable: "EmployeeRoles",
                        principalColumn: "RoleID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_EmployeeStatuses_EmployeeStatusCodeStatusID",
                        column: x => x.EmployeeStatusCodeStatusID,
                        principalTable: "EmployeeStatuses",
                        principalColumn: "StatusID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_EmployeeCategoryCodeCategoryID",
                table: "Employees",
                column: "EmployeeCategoryCodeCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_EmployeeRoleIdRoleID",
                table: "Employees",
                column: "EmployeeRoleIdRoleID");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_EmployeeStatusCodeStatusID",
                table: "Employees",
                column: "EmployeeStatusCodeStatusID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "EmployeeCategories");

            migrationBuilder.DropTable(
                name: "EmployeeRoles");

            migrationBuilder.DropTable(
                name: "EmployeeStatuses");
        }
    }
}
