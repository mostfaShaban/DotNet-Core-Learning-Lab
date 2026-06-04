using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]

namespace Demo.Models
{
	internal class Employee
	{
		public int EmpId { get; set; }
		public string? EmpName { get; set; }
		public decimal Salary { get; set; }
		public int Age { get; set; }
		public string Email { get; set; }
		public int Test { get; set; }
		public  string PhoneNumber { get; set; }
		public string? Password { get; set; }

		// Navigation Property 
		// EF Core => Employee May Manage a One Department [Partial Participation]
		[InverseProperty("Manager")]
		public virtual Department? ManagedDepartment { get; set; }
		public  Address EmpAddress { get; set; }

		[ForeignKey("EmployeeDepartment")]
		public int? DepartmentId { get; set; }

		// Navigation Property [One]
		[InverseProperty("Employees")]
		public virtual Department EmployeeDepartment { get; set; } = null!;

	}
}
