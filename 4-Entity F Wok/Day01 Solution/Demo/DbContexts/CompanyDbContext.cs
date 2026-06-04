using Demo.ModelConfigurations;
using Demo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DbContexts
{
	internal class CompanyDbContext : DbContext
	{
		public CompanyDbContext() : base()
		{

		}
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Server = .; Database = CompanyDb; Trusted_Connection = true; TrustServerCertificate=True")
						  ;//.UseLazyLoadingProxies();
		}	

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			#region Fluent APIs
			////modelBuilder.Entity<Employee>()
			////			//.Property("Name"); // Will Throw Excpetion Will Add Migration if Name is not Property in Model
			////			//.Property<string>("Name"); // Will Define "Name" as a Shadow Property [exist only in the database]
			////			//.Property("EmpName")
			////			//.Property(nameof(Employee.EmpName));
			////			.Property(E => E.EmpName)
			////			.HasColumnType("varchar") // varchar(1)
			////			.HasMaxLength(50)  // varchar(50) -- Not Allow Null
			////			.IsRequired(false); // varchar(50) -- Allow Null

			//modelBuilder.Entity<Department>(D =>
			//{
			//	D.ToTable("Departments" , "Sales");

			//	D.HasKey(D => D.DeptId); // Identity With Default [1,1]

			//	D.Property(D => D.DeptId)
			//	 .UseIdentityColumn(10, 10);

			//	//D.Property(D => D.DeptId)
			//	// .ValueGeneratedNever(); // disable identity

			//	//D.Property(D => D.DeptId)
			//	// .HasDefaultValueSql("NewGuid()"); //  Database-Generated GUID 

			//	D.Property(D => D.DeptName)
			//	 .HasColumnType("varchar")
			//	 .HasMaxLength(50)
			//	 .HasColumnName("DepartmentName")
			//	 .IsRequired(false)
			//	 .HasDefaultValue("HR");

			//	D.Property(D => D.DateOfCreation)
			//	.HasAnnotation("DataType", "Date")
			//	//.HasDefaultValue(DateOnly.FromDateTime(DateTime.Now)) // defaultValue: new DateOnly(2025, 2, 19)
			//	.HasDefaultValueSql("GetDate()"); // stays the same after insert -  can be manually set
			//	//.HasComputedColumnSql("GetDate()"); // automatically recalculated value - can not be manually set

			//	D.Ignore(D => D.Serial);
			//}); 
			#endregion

			#region Session 02
			//modelBuilder.ApplyConfiguration<Employee>(new EmployeeConfigurations());
			//modelBuilder.ApplyConfiguration(new DepartmentConfigurations());
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
			//  automatically apply all Fluent API configurations from separate configuration classes in the given assembly


			//modelBuilder.Entity<Department>()
			//			.HasOne(D => D.Manager)
			//			.WithOne(E => E.ManagedDepartment)
			//			.HasForeignKey<Department>(D => D.DeptManagerId)
			//			.OnDelete(DeleteBehavior.Restrict);

			//.HasForeignKey("DeptManagerId");

			//modelBuilder.Entity<Employee>()
			//			.HasOne<Department>(E => E.ManagedDepartment)
			//			.WithOne(E => E.Manager)
			//			.HasForeignKey<Department>(D => D.DeptManagerId);


			//modelBuilder.Entity<Employee>()
			//               .HasOne(e => e.EmployeeDepartment)  // Each Employee must belong to one Department
			//               .WithMany(d => d.Employees)  // Each Department has multiple Employees
			//               .HasForeignKey(e => e.DepartmentId)
			//               .IsRequired();  // Makes the relationship required

			//modelBuilder.Entity<Department>()
			//	        .HasMany(d => d.Employees)
			//	        .WithOne(e => e.EmployeeDepartment)
			//	        .HasForeignKey(e => e.DepartmentId)

			#endregion        //	        .IsRequired();  // at least one Employee per Department [Not On Database Level]                                                                                                 

			modelBuilder.Entity<Department>().HasData(
				new Department() { DeptId = 40, DeptName = "Design", DateOfCreation = new DateOnly(2023, 11, 20) },
				new Department() { DeptId = 50, DeptName = "Software", DateOfCreation = new DateOnly(2023, 11, 20) }
			);


			//modelBuilder.Entity<Student>()
			//		   .HasMany(S => S.Courses)
			//		   .WithMany(C => C.Students)
			//		   .UsingEntity(RT => RT.ToTable("Hamda"));


			modelBuilder.Entity<StudentCourses>()
						.HasKey(SC => new { SC.StdId, SC.CrsId });


			modelBuilder.Entity<Student>()
						.HasMany(S => S.StudentCourses)
						.WithOne(SC => SC.Student)
						.HasForeignKey(SC=>SC.StdId)
						.OnDelete(DeleteBehavior.NoAction)
						.IsRequired();

			modelBuilder.Entity<Course>()
					.HasMany(S => S.CourseStudents)
					.WithOne(SC => SC.Course)
					.HasForeignKey(SC => SC.CrsId)
					.OnDelete(DeleteBehavior.NoAction)
					.IsRequired();

			modelBuilder.Entity<EmployeeDepartmentsView>().ToView("EmployeeDepartmentsView").HasNoKey();
		}
		public DbSet<EmployeeDepartmentsView> EmployeeDepartmentsViews { get; set; }
		public DbSet<Employee> Employees { get; set; }

		//public DbSet<Address> Addresses { get; set; }

		public DbSet<Student> Students { get; set; }
		public DbSet<Course> Courses { get; set; }
	}
}
