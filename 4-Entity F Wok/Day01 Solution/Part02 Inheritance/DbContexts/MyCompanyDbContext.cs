using Microsoft.EntityFrameworkCore;
using Part02_Inheritance.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part02_Inheritance.DbContexts
{
    class MyCompanyDbContext : DbContext
    {
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Server = .; Database = MyCompany; Trusted_Connection = true; TrustServerCertificate=True");
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			//modelBuilder.Entity<Employee>()
			//	.HasDiscriminator<string>("EmployeeType")
			//	.HasValue<FulltimeEmployee>("FT")
			//	.HasValue<ParttimeEmployee>("PT");

			//modelBuilder.Entity<FulltimeEmployee>()
			//	.HasBaseType<Employee>();

			//modelBuilder.Entity<ParttimeEmployee>()
			//	.HasBaseType<Employee>();

			modelBuilder.Entity<FulltimeEmployee>().ToTable("FullTimeEmployees");
			modelBuilder.Entity<ParttimeEmployee>().ToTable("ParttimeEmployees");
		}
		public DbSet<Employee> Employees { get; set; }
		public DbSet<FulltimeEmployee> FulltimeEmployees { get; set; }
		public DbSet<ParttimeEmployee> ParttimeEmployees { get; set; }
	}
}
