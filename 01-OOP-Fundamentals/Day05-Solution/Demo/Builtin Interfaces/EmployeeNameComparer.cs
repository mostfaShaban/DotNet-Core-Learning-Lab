using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Builtin_Interfaces
{
	internal class EmployeeNameComparer : IComparer<Employee>
	{
		public int Compare(Employee x, Employee y)
		{
			return string.Compare(x?.Name, y?.Name);
		}
	}
}
