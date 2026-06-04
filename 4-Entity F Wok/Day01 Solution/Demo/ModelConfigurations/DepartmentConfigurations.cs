using Demo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.ModelConfigurations
{
	internal class DepartmentConfigurations : IEntityTypeConfiguration<Department>
	{
		public void Configure(EntityTypeBuilder<Department> D)
		{
			D.ToTable("Departments", "Sales");

			D.HasKey(D => D.DeptId); // Identity With Default [1,1]

			D.Property(D => D.DeptId)
			 .UseIdentityColumn(10, 10);

			//D.Property(D => D.DeptId)
			// .ValueGeneratedNever(); // disable identity

			//D.Property(D => D.DeptId)
			// .HasDefaultValueSql("NewGuid()"); //  Database-Generated GUID 

			D.Property(D => D.DeptName)
			 .HasColumnType("varchar")
			 .HasMaxLength(50)
			 .HasColumnName("DepartmentName")
			 .IsRequired(false)
			 .HasDefaultValue("HR");

			D.Property(D => D.DateOfCreation)
			.HasAnnotation("DataType", "Date")
			//.HasDefaultValue(DateOnly.FromDateTime(DateTime.Now)) // defaultValue: new DateOnly(2025, 2, 19)
			.HasDefaultValueSql("GetDate()"); // stays the same after insert -  can be manually set
											  //.HasComputedColumnSql("GetDate()"); // automatically recalculated value - can not be manually set

			D.Ignore(D => D.Serial);

			//D.OwnsOne(D => D.DeptAddress);
			//D.HasMany(d => d.Employees)
			//			.WithOne(e => e.EmployeeDepartment)
			//			.HasForeignKey(e => e.DepartmentId)
			//			.IsRequired();  // at least one Employee per Department [Not On Database Level]
		}
	}
}
