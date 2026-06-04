using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Demo.Migrations
{
    /// <inheritdoc />
    public partial class CreateEmployeeDepartmentView : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"Create View EmployeeDepartmentsView 
                                       With SchemaBinding, Encryption 
                                       As 
                                          Select E.EmpId , E.EmployeeName , D.DeptId , D.DepartmentName
                                          From Dbo.EmployeesTable E join Sales.Departments D
                                          on D.DeptId = E.DepartmentId");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Drop View EmployeeDepartmentsView");

        }
    }
}
