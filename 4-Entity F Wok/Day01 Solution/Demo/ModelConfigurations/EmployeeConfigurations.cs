using Demo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Demo.ModelConfigurations
{
	internal class EmployeeConfigurations : IEntityTypeConfiguration<Employee>
	{
		public void Configure(EntityTypeBuilder<Employee> builder)
		{
			builder.ToTable("EmployeesTable");

			builder.HasKey(E => E.EmpId);
			builder.Property(E => E.EmpId).UseIdentityColumn(10, 10);

			builder.Property<string>("Address");

			builder.Property(E => E.EmpName)
				   .HasColumnType("varchar") 
				   .HasMaxLength(50) 
				   .HasColumnName("EmployeeName")
				   .HasAnnotation("MinimumLength" , 3)
				   .IsRequired(false);

			builder.Property(E => E.Salary)
				   .HasColumnName("EmployeeSalary")
				   .HasColumnType("decimal(10,2)");

			builder.Ignore(E => E.Test);

			builder.OwnsOne(E => E.EmpAddress, Address => Address.WithOwner());

			builder.HasOne(e => e.EmployeeDepartment)  // Each Employee must belong to one Department
						.WithMany(d => d.Employees)  // Each Department has multiple Employees
						.HasForeignKey(e => e.DepartmentId)
						.OnDelete(DeleteBehavior.NoAction)
						.IsRequired(false);
						//.IsRequired();  // Makes the relationship required
		}
	}
}
