using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
namespace Demo.Models
{
	internal class Department
	{
		public int DeptId { get; set; }
		public string DeptName { get; set; }
		public DateOnly DateOfCreation { get; set; }
		public int Serial { get; set; }

		[ForeignKey(nameof(Manager))]
		public int? DeptManagerId { get; set; }

		// Navigation Property
		// EF Core => Department Must has one Employee To Manage it [Total Participation]
		[InverseProperty("ManagedDepartment")]
		public virtual Employee Manager { get; set; } = null!;

		//public Address DeptAddress { get; set; }
		[InverseProperty("EmployeeDepartment")]
		public virtual ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();

	}
}
