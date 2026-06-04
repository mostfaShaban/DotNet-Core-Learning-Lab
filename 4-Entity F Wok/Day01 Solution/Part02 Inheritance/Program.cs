using Part02_Inheritance.DbContexts;
using Part02_Inheritance.Models;

namespace Part02_Inheritance
{
	internal class Program
	{
		static void Main(string[] args)
		{
			#region Inheritance Mapping
			//using MyCompanyDbContext dbContext = new MyCompanyDbContext();

			//FulltimeEmployee fulltimeEmployee = new FulltimeEmployee()
			//{
			//	Name = "Amr",
			//	Address = "Giza",
			//	Age = 30,
			//	Salary = 20_000,
			//	StartDate = DateTime.Now
			//};
			//ParttimeEmployee parttimeEmployee = new ParttimeEmployee()
			//{
			//	Name = "Sama",
			//	Address = "Cairo",
			//	Age = 25,
			//	CountOfHours = 100,
			//	HourRate = 250
			//};

			//dbContext.Set<FulltimeEmployee>().Add(fulltimeEmployee);
			//dbContext.Add(parttimeEmployee);

			//dbContext.SaveChanges();

			//var employees = from E in dbContext.Employees
			//				select E;

			//if (employees is not null)
			//{
			//	foreach (var Emp in employees)
			//		Console.WriteLine($"{Emp.Name} :: {Emp.Age}");
			//}

			#endregion

			#region Local Vs Remote 
			//using MyCompanyDbContext dbContext = new MyCompanyDbContext();

			//var Emp01 = dbContext.Employees.FirstOrDefault();
			//if (Emp01 is not null)
			//{
			//	Console.WriteLine(Emp01.Age); // 30
			//	Emp01.Age = null;
			//}
			//var Result = dbContext.Employees.Local.Any(E => E.Age == null);
			//// useful for detecting uncommitted changes
			//Console.WriteLine($"Local = {Result}"); // True 
			//Result = dbContext.Employees.Any(E => E.Age == null);
			//Console.WriteLine($"Remote = {Result}"); // False 

			#endregion
		}
	}
}
