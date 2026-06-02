using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Binding
{
	internal class ParttimeEmployee : Employee
	{
		public int CountOfHours { get; set; }
		public decimal HourRate { get; set; }

		public ParttimeEmployee(int id , string? name , int age , int countOfHours, decimal hourRate)
		{
			Id = id ;
			Name = name ;
			Age = age ;
			CountOfHours = countOfHours;
			HourRate = hourRate;
		}

		#region Methods 
		public override void GetEmployeeData()
		{
			Console.WriteLine($"Employee Data : Id = {Id} , Name = {Name} , Age = {Age} , Hour Rate = {HourRate} , Count Of Hours = {CountOfHours}");
		}
		public new void GetEmployeeType()
		{
			Console.WriteLine("I Am Parttime Employee");
		}
		#endregion


	}
}
