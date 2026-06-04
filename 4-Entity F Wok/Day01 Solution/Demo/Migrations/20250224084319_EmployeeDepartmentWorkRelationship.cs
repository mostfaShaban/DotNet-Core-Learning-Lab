using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Demo.Migrations
{
    /// <inheritdoc />
    public partial class EmployeeDepartmentWorkRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_EmployeesTable_DeptManagerId",
                schema: "Sales",
                table: "Departments");

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "EmployeesTable",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeesTable_DepartmentId",
                table: "EmployeesTable",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_EmployeesTable_DeptManagerId",
                schema: "Sales",
                table: "Departments",
                column: "DeptManagerId",
                principalTable: "EmployeesTable",
                principalColumn: "EmpId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeesTable_Departments_DepartmentId",
                table: "EmployeesTable",
                column: "DepartmentId",
                principalSchema: "Sales",
                principalTable: "Departments",
                principalColumn: "DeptId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_EmployeesTable_DeptManagerId",
                schema: "Sales",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeesTable_Departments_DepartmentId",
                table: "EmployeesTable");

            migrationBuilder.DropIndex(
                name: "IX_EmployeesTable_DepartmentId",
                table: "EmployeesTable");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "EmployeesTable");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_EmployeesTable_DeptManagerId",
                schema: "Sales",
                table: "Departments",
                column: "DeptManagerId",
                principalTable: "EmployeesTable",
                principalColumn: "EmpId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
