using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Builtin_Interfaces
{
	internal class Employee : ICloneable, IComparable<Employee>
	{
		public int CompareTo(Employee? other)
		{
			// +ve : this.Salary > other.Salary 
			// -ve : this.Salary < other.Salary 
			//  0 : this.Salary == other.Salary 

			//if (this.Salary > other?.Salary)
			//	return 1;
			//else if (this.Salary < other?.Salary)
			//	return -1;
			//return 0;

			return this.Salary.CompareTo(other?.Salary);
		}

		public int Id { get; set; }
		public string? Name { get; set; }
		public decimal Salary { get; set; }
		public Employee()
		{
			
		}
		// Copy Constructor 
		public Employee(Employee employee)
		{
			Id = employee.Id;
			Name = employee.Name;
			Salary = employee.Salary;
		}

		public object Clone()
		{
			return new Employee(this);
			//return new Employee()
			//{
			//	Id = this.Id,
			//	Name = this.Name,
			//	Salary = this.Salary
			//};
		}

		public override string ToString()
		{
			return $"Id = {Id} , Name = {Name} , Salary = {Salary:c}";
		}

	
	}
}
