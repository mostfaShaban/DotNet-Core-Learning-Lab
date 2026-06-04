using Demo.Data;
using Demo.DbContexts;
using Demo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System.Linq;
using static Azure.Core.HttpHeader;

namespace Demo
{
    internal class Program
	{
		static void Main(string[] args)
		{

			using CompanyDbContext dbContext = new CompanyDbContext();

			#region Query Object Model 

			#region To Add New Row In Table In Database
			//Employee employee01 = new Employee()
			//{
			//	EmpName = "Omar",
			//	Age = 25,
			//	Email = "OmarTarek@gmail.com",
			//	Password = "P@ssw0rd",
			//	PhoneNumber = "0112365478",
			//	Salary = 50000,
			//	Test = 123
			//};
			//// required Keyword => (C# 11/.NET 7 Feature) Ensures a non-null value at compile-time [Not Mapped To Database]
			//// [Required] Attribute => Validates a required value at runtime [Mapped To Database]

			//Console.WriteLine(dbContext.Entry(employee01).State); // Detached

			//dbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.TrackAll; // Default Behavior
			//dbContext.Add(employee01);
			//dbContext.Set<Employee>().Add(employee01);
			//dbContext.Employees.Add(employee01);
			//dbContext.Entry<Employee>(employee01).State = EntityState.Added;

			//Console.WriteLine(dbContext.Entry(employee01).State); // Added
			//Console.WriteLine($"Employee 01 Id Before Save Changes = {employee01.EmpId}");
			//dbContext.SaveChanges();
			//Console.WriteLine(dbContext.Entry(employee01).State); // Unchanged
			//Console.WriteLine($"Employee 01 Id After Save Changes= {employee01.EmpId}");
			#endregion

			#region To Retrieve Data From Database

			////var employee = dbContext.Employees.Where(E => E.EmpId == 10).FirstOrDefault();

			////dbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
			//var employee = dbContext.Employees.AsNoTracking().FirstOrDefault(E => E.EmpId == 10);

			//if (employee is not null)
			//{
			//	Console.WriteLine(dbContext.Entry(employee).State); // Detached
			//	Console.WriteLine($"{employee.EmpId} - {employee.EmpName} - {employee.Email}");
			//}

			#endregion

			#region To Update Data In Database 

			//var employee = dbContext.Employees.AsNoTracking().FirstOrDefault(E => E.EmpId == 10);

			//if (employee is not null)
			//{
			//	Console.WriteLine(dbContext.Entry(employee).State); // Detached
			//	Console.WriteLine($"{employee.EmpId} - {employee.EmpName} - {employee.Email}"); // 10 - Amr - OmarTarek@gmail.com
			//	employee.EmpName = "Samy";
			//	Console.WriteLine("After Changing");
			//	Console.WriteLine(dbContext.Entry(employee).State); // Detached
			//	Console.WriteLine($"{employee.EmpId} - {employee.EmpName} - {employee.Email}"); // 10 - Samy - OmarTarek@gmail.com
			//	dbContext.SaveChanges();
			//	Console.WriteLine("After SaveChanges()");
			//	Console.WriteLine(dbContext.Entry(employee).State); // Detached
			//}



			#endregion

			#region To Remove Data From Database 
			//var employee = dbContext.Employees.FirstOrDefault(E => E.EmpId == 10);

			//if (employee is not null)
			//{
			//	Console.WriteLine(dbContext.Entry(employee).State); // Unchanged
			//	dbContext.Employees.Remove(employee);
			//	dbContext.Remove(employee);
			//	dbContext.Set<Employee>().Remove(employee);
			//	dbContext.Entry(employee).State = EntityState.Deleted;
			//	Console.WriteLine("After Remove");
			//	Console.WriteLine(dbContext.Entry(employee).State); // Deleted
			//	dbContext.SaveChanges();
			//	Console.WriteLine("After SaveChanges()");
			//	Console.WriteLine(dbContext.Entry(employee).State); // Detached
			//}
			#endregion

			#endregion

			#region Data Seeding 

			#region Manual Seeding 
			//Department department01 = new Department()
			//{
			//	DeptName = "HR",
			//	DateOfCreation = new DateOnly(2024, 7, 25)
			//};
			//dbContext.Set<Department>().Add(department01);

			//List<Department> departments = new List<Department>()
			//{
			//	new Department(){DeptName = "IT" , DateOfCreation = new DateOnly(2024,6,20)} ,
			//	new Department(){DeptName = "Developmenet" , DateOfCreation = new DateOnly(2024,12,20)}
			//};



			//dbContext.Set<Department>().AddRange(departments);
			//dbContext.SaveChanges();
			#endregion

			#region Automatic Seeding 
			//bool Flag = CompanyDbContextSeed.DataSeeding(dbContext);
			//Console.WriteLine(Flag);
			#endregion

			#endregion

			#region Navigation Property - Related Data  

			#region Example 01 
			//var employee01 = dbContext.Employees.FirstOrDefault(E => E.EmpId == 10);

			//if(employee01 is not null)
			//{
			//	Console.WriteLine($"{employee01.EmpName} - {employee01.DepartmentId} - {employee01.EmployeeDepartment?.DeptName} ");
			//	// Sama - 10 -

			//	var EmpDepartment = (from D in dbContext.Set<Department>()
			//						where D.DeptId == employee01.DepartmentId
			//						select D).FirstOrDefault();

			//	Console.WriteLine(EmpDepartment?.DeptName ?? "No Department"); // HR

			//}
			#endregion

			#region Eager Loading 
			//var employee01WithDepartment = dbContext.Employees.Include(e => e.EmployeeDepartment)
			//												  .FirstOrDefault(E => E.EmpId == 10);

			//employee01WithDepartment = (from E in dbContext.Employees.Include(E=>E.EmployeeDepartment)
			//						   where E.EmpId == 10
			//						   select E).FirstOrDefault();
			//if (employee01WithDepartment is not null)
			//{
			//	Console.WriteLine($"{employee01WithDepartment.EmpName} - {employee01WithDepartment.DepartmentId} - {employee01WithDepartment.EmployeeDepartment?.DeptName} ");
			//	// Sama - 10 - HR
			//}

			//var employee = dbContext.Employees.Include(E => E.ManagedDepartment).Where(E=>E.ManagedDepartment.DeptName == "HR").FirstOrDefault();
			//Console.WriteLine(employee.EmpName);



			//var employee02WithDepartment = dbContext.Employees.Include(e => e.EmployeeDepartment).ThenInclude(D=>D.Manager)
			//									.FirstOrDefault(E => E.EmpId == 30);
			//if (employee02WithDepartment is not null)
			//{
			//   Console.WriteLine($"Name : {employee02WithDepartment.EmpName}" +
			//	   $" - DeptId :  {employee02WithDepartment.DepartmentId} -" +
			//	   $" DeptName : {employee02WithDepartment.EmployeeDepartment?.DeptName}" +
			//	   $" DeptManagerName : {employee02WithDepartment.EmployeeDepartment.Manager.EmpName} ");
			//	// Name : Soha - DeptId :  10 - DeptName : HR DeptManagerName : Sama
			//}


			//var Employees =  dbContext.Employees.Include(e => e.EmployeeDepartment)
			//	                                .Where(e => e.EmployeeDepartment.DeptName == "HR")
			//									.Select(E=>new
			//									{
			//										EmployeeName = E.EmpName ,
			//										EmployeeDepartment = E.EmployeeDepartment.DeptName
			//									});

			//foreach (var employee in Employees)
			//{
			//	Console.WriteLine(employee);
			//}
			// { EmployeeName = Sama, EmployeeDepartment = HR }
			// { EmployeeName = Soha, EmployeeDepartment = HR }
			// { EmployeeName = Sameh, EmployeeDepartment = HR }
			// { EmployeeName = Pola, EmployeeDepartment = HR }



			#endregion

			#region Explicit Loading 

			//var employee01 = dbContext.Employees.FirstOrDefault(E => E.EmpId == 10);

			//if (employee01 is not null)
			//{
			//	dbContext.Entry(employee01).Reference(E => E.EmployeeDepartment).Load();
			//	Console.WriteLine($"{employee01.EmpName} - {employee01.DepartmentId} - {employee01.EmployeeDepartment?.DeptName} ");
			//	// Sama - 10 - HR
			//}


			//var Department = dbContext.Set<Department>().FirstOrDefault(D => D.DeptId == 10);

			//Console.WriteLine(Department.DeptName); // HR


			//dbContext.Entry(Department).Collection(D => D.Employees).Query().Where(E => E.Age > 25).Load();

			//foreach(var employee in Department.Employees)
			//	Console.WriteLine(employee.EmpName);
			//// Sama
			//// Sameh
			//// Pola


			#endregion

			#region Lazy Loading 

			//var employee01 = dbContext.Employees.FirstOrDefault(E => E.EmpId == 10);

			//if (employee01 is not null)
			//{
			//	Console.WriteLine($"{employee01.EmpName} - {employee01.DepartmentId}");
			//	// Sama - 10 -
			//	Console.WriteLine(employee01.EmployeeDepartment?.DeptName);
			//}
			#endregion
			#endregion

			#region Join Operators

			#region Inner Join 

			#region Department That Has Employees 
			//var Result = from D in dbContext.Set<Department>()
			//			 join E in dbContext.Employees
			//			 on D.DeptId equals E.DepartmentId
			//			 select new
			//			 {
			//				 EmployeeId = E.EmpId,
			//				 EmployeeName = E.EmpName,
			//				 D.DeptId,
			//				 D.DeptName
			//			 };

			//var	Result = dbContext.Set<Department>().Join(dbContext.Employees, D => D.DeptId, E => E.DepartmentId
			//, (D, E) => new
			//	{
			//		EmployeeId = E.EmpId,
			//		EmployeeName = E.EmpName,
			//		D.DeptId,
			//		D.DeptName
			//	});

			//	foreach (var item in Result)
			//		Console.WriteLine(item);
			//	// { EmployeeId = 10, EmployeeName = Sama, DeptId = 10, DeptName = HR }
			//	// { EmployeeId = 20, EmployeeName = Nadia, DeptId = 20, DeptName = IT }
			//	// { EmployeeId = 30, EmployeeName = Soha, DeptId = 10, DeptName = HR }
			//	// { EmployeeId = 40, EmployeeName = Mazen, DeptId = 20, DeptName = IT }
			//	// { EmployeeId = 50, EmployeeName = Sameh, DeptId = 10, DeptName = HR }
			//	// { EmployeeId = 60, EmployeeName = Pola, DeptId = 10, DeptName = HR }

			#endregion

			#region Department Manager 

			//var Result = from E in dbContext.Employees
			//			 join D in dbContext.Set<Department>()
			//			 on E.EmpId equals D.DeptManagerId
			//			 select new
			//			 {
			//				 EmployeeId = E.EmpId,
			//				 EmployeeName = E.EmpName,
			//				 D.DeptId,
			//				 D.DeptName
			//			 };

			//Result = dbContext.Employees.Join(dbContext.Set<Department>(), E => E.EmpId, D => D.DeptManagerId, (E, D) => new
			//{
			//	EmployeeId = E.EmpId,
			//	EmployeeName = E.EmpName,
			//	D.DeptId,
			//	D.DeptName
			//});


			//foreach (var item in Result)
			//	Console.WriteLine(item);
			//// { EmployeeId = 30, EmployeeName = Soha, DeptId = 10, DeptName = HR }
			//// { EmployeeId = 10, EmployeeName = Sama, DeptId = 20, DeptName = IT }
			//// { EmployeeId = 20, EmployeeName = Nadia, DeptId = 40, DeptName = Design }
			#endregion

			#endregion

			#region Group Join

			#region Example 01
			//var result = dbContext.Set<Department>().GroupJoin(dbContext.Employees, D => D.DeptId, E => E.DepartmentId,
			//	(D, E) => new
			//	{
			//		dept = D,
			//		Employees = E
			//	});
			//result = from dept in dbContext.Set<Department>()
			//		 join emp in dbContext.Employees on dept.DeptId equals emp.DepartmentId into empGroup
			//		 select new
			//		 {
			//			 dept,
			//			 Employees = empGroup
			//		 };
			//foreach (var item in result)
			//{
			//	Console.WriteLine($"DeptId = {item.dept.DeptId} , DeptName = {item.dept.DeptName}");
			//	foreach (var emp in item.Employees)
			//	{
			//		Console.WriteLine($"========= {emp.EmpName}");
			//	}
			//}
			////DeptId = 10 , DeptName = HR
			////========= Sama
			////========= Soha
			////========= Sameh
			////========= Pola
			////DeptId = 20 , DeptName = IT
			////========= Nadia
			////========= Mazen
			////DeptId = 30 , DeptName = Developmenet
			////DeptId = 40 , DeptName = Design
			////DeptId = 50 , DeptName = Software 
			#endregion

			#region Example 02
			//var result = from dept in dbContext.Set<Department>()
			//			 join emp in dbContext.Employees on dept.DeptId equals emp.DepartmentId into empGroup
			//			 select new
			//			 {
			//				 dept,
			//				 Employees = empGroup
			//			 } into Group
			//			 where Group.Employees.Count() > 3
			//			 select Group;

			//result = dbContext.Set<Department>().GroupJoin(dbContext.Employees, D => D.DeptId, E => E.DepartmentId,
			//	(D, E) => new
			//	{
			//		dept = D,
			//		Employees = E
			//	}).Where(G => G.Employees.Count() > 3);

			//foreach (var item in result)
			//{
			//	Console.WriteLine($"DeptId = {item.dept.DeptId} , DeptName = {item.dept.DeptName}");
			//	foreach (var emp in item.Employees)
			//	{
			//		Console.WriteLine($"  {emp.EmpName}");
			//	}
			//}
			////DeptId = 10 , DeptName = HR
			////  Sama
			////  Soha
			////  Sameh
			////  Pola


			#endregion

			#endregion

			#region Left Outer Join 

			#region Is Not Working (LeftJoin)
			//var result = dbContext.Set<Department>().LeftJoin(dbContext.Employees, D => D.DeptId, E => E.DepartmentId,
			//	(D, E) => new
			//	{
			//		dept = D,
			//		Employee = E
			//	});

			//foreach (var item in result)
			//{
			//	Console.WriteLine($"DeptId = {item.dept.DeptId} , DeptName = {item.dept.DeptName} , EmpId = {item.Employee.EmpId} , EmpName = {item.Employee.EmpName}");
			//}
			#endregion

			#region Departments Left Join Employees 

			//var Result = dbContext.Set<Department>().GroupJoin(dbContext.Employees, D => D.DeptId, E => E.DepartmentId,
			//	(D, Employees) => new
			//	{
			//		Department = D,
			//		Employees
			//	}).SelectMany(R => R.Employees.DefaultIfEmpty(), (R, Employee) => new
			//	{
			//		DepartmentId = R.Department.DeptId,
			//		DepartmentName = R.Department.DeptName,
			//		EmployeeName = Employee != null ? Employee.EmpName : "No Employee"
			//	});

			//Result = from D in dbContext.Set<Department>()
			//		 join E in dbContext.Employees
			//		 on D.DeptId equals E.DepartmentId into Employees
			//		 select new { Department = D, Employees = Employees.DefaultIfEmpty() } into Groups
			//		 from E in Groups.Employees
			//		 select new
			//		 {
			//			 DepartmentId = Groups.Department.DeptId,
			//			 DepartmentName = Groups.Department.DeptName,
			//			 EmployeeName = E != null ? E.EmpName : "No Employee"
			//		 };


			//foreach (var item in Result)
			//	Console.WriteLine(item);
			//// { DepartmentId = 10, DepartmentName = HR, EmployeeName = Sama }
			//// { DepartmentId = 10, DepartmentName = HR, EmployeeName = Soha }
			//// { DepartmentId = 10, DepartmentName = HR, EmployeeName = Sameh }
			//// { DepartmentId = 10, DepartmentName = HR, EmployeeName = Pola }
			//// { DepartmentId = 20, DepartmentName = IT, EmployeeName = Nadia }
			//// { DepartmentId = 20, DepartmentName = IT, EmployeeName = Mazen }
			//// { DepartmentId = 30, DepartmentName = Developmenet, EmployeeName = No Employee }
			//// { DepartmentId = 40, DepartmentName = Design, EmployeeName = No Employee }
			//// { DepartmentId = 50, DepartmentName = Software, EmployeeName = No Employee }





			//var Result = from D in dbContext.Set<Department>()
			//			 join E in dbContext.Employees
			//			 on D.DeptId equals E.DepartmentId into Employees
			//			 select new
			//			 {
			//				 Dept = D,
			//				 Employees = Employees.DefaultIfEmpty()
			//			 } into G
			//			 from Employees in G.Employees
			//			 select Employees;


			//foreach (var item in Result)
			//	Console.WriteLine(item?.EmpName);
			//// Sama 
			//// Nadia 
			//// Soha 
			//// Mazen 
			//// Sameh 
			//// Pola



			//foreach (var item in Result)
			//{
			//	Console.WriteLine($"DeptId = {item.Dept.DeptId} , DeptName = {item.Dept.DeptName} ");
			//	foreach( var employee in item.Employees )
			//		Console.WriteLine($"\tEmpId = {employee.EmpId} , EmpName = {employee.EmpName}");
			//}
			// DeptId = 10 , DeptName = HR
			//         EmpId = 10 , EmpName = Sama
			//         EmpId = 30 , EmpName = Soha
			//         EmpId = 50 , EmpName = Sameh
			//         EmpId = 60 , EmpName = Pola
			// DeptId = 20 , DeptName = IT
			//         EmpId = 20 , EmpName = Nadia
			//         EmpId = 40 , EmpName = Mazen
			// DeptId = 30 , DeptName = Developmenet
			// DeptId = 40 , DeptName = Design
			// DeptId = 50 , DeptName = Software


			#endregion

			#region Employee Left Join Department 

			//var Result = dbContext.Employees.GroupJoin(dbContext.Set<Department>()
			//									  , E => E.DepartmentId
			//									  , D => D.DeptId,
			//		  (E, Departments) => new
			//		  {
			//			  Employee = E,
			//			  Departments = Departments,
			//		  }).SelectMany(R => R.Departments.DefaultIfEmpty(), (R, Department) => new
			//		  {
			//			  EmployeeId = R.Employee.EmpId,
			//			  EmployeeName = R.Employee.EmpName,
			//			  DepartmentId = Department != null ? Department.DeptId : 0,
			//			  DepartmentName = Department != null ? Department.DeptName : "No Department"
			//		  });


			//Result = from E in dbContext.Employees
			//		 join D in dbContext.Set<Department>()
			//		 on E.DepartmentId equals D.DeptId into Groups
			//		 select new
			//		 {
			//			 Employee = E,
			//			 Departments = Groups.DefaultIfEmpty()
			//		 } into Groups
			//		 from D in Groups.Departments
			//		 select new
			//		 {
			//			 EmployeeId = Groups.Employee.EmpId,
			//			 EmployeeName = Groups.Employee.EmpName,
			//			 DepartmentId = D != null ? D.DeptId : 0,
			//			 DepartmentName = D != null ? D.DeptName : "No Department"
			//		 };

			//foreach (var item in Result)
			//	Console.WriteLine(item);


			#endregion

			#endregion

			#region Cross Join 

			//var Result = from E in dbContext.Employees
			//			 from D in dbContext.Set<Department>()
			//			 select new
			//			 {
			//				 Employee = E.EmpName,
			//				 Department = D.DeptName
			//			 };

			//Result = dbContext.Employees.SelectMany(E => dbContext.Set<Department>().Select(D => new
			//{
			//	Employee = E.EmpName,
			//	Department = D.DeptName
			//}));


			//foreach (var item in Result)
			//	Console.WriteLine(item);
			#endregion

			#endregion

			#region View 
			//var Result = dbContext.EmployeeDepartmentsViews.ToList();


			//foreach (var item in Result)
			//	Console.WriteLine(item.EmployeeName); 
			#endregion


		}
	}
}
