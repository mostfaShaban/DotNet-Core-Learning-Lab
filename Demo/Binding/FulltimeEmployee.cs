using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Binding
{
	internal class FulltimeEmployee : Employee
	{
		public decimal Salary { get; set; }

		public FulltimeEmployee(int id , string? name , int age , decimal salary)
		{
			Id = id ;
			Name = name ;
			Age = age ;
			Salary = salary ;
		}

		#region Methods
		public override void GetEmployeeData()
		{
			base.GetEmployeeData();
			Console.WriteLine($" Salary = {Salary}");
		}
		public new void GetEmployeeType()
		{
			Console.WriteLine("I Am Fulltime Employee");
		}



		#endregion

	}
}
