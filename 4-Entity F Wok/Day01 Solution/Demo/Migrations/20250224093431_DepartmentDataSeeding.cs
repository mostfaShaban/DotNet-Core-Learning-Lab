using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Demo.Migrations
{
    /// <inheritdoc />
    public partial class DepartmentDataSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "Sales",
                table: "Departments",
                columns: new[] { "DeptId", "DateOfCreation", "DeptManagerId", "DepartmentName" },
                values: new object[,]
                {
                    { 40, new DateOnly(2023, 11, 20), null, "Design" },
                    { 50, new DateOnly(2023, 11, 20), null, "Software" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Sales",
                table: "Departments",
                keyColumn: "DeptId",
                keyValue: 40);

            migrationBuilder.DeleteData(
                schema: "Sales",
                table: "Departments",
                keyColumn: "DeptId",
                keyValue: 50);
        }
    }
}
