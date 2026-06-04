using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part02_Inheritance.Models
{
    class FulltimeEmployee : Employee
    {
		public decimal Salary { get; set; }
		public DateTime StartDate { get; set; }
	}
}
