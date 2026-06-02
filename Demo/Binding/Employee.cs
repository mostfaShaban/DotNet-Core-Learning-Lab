using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Binding
{
	internal class Employee
	{
		#region Properties
		public int Id { get; set; }
		public string? Name { get; set; }
		public int Age { get; set; }
		#endregion

		#region Methods 
		public virtual void GetEmployeeType()
		{
			Console.WriteLine("I Am Employee");
		}
		public virtual void GetEmployeeData()
		{
			Console.Write($"Employee Data : Id = {Id} , Name = {Name} , Age = {Age}");
		}
		#endregion
	}
}
