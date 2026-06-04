using Demo.DbContexts;
using Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Demo.Data
{
	internal static class CompanyDbContextSeed
	{
		public static bool DataSeeding(CompanyDbContext dbContext)
		{
			try
			{
				if (!dbContext.Employees.Any())
				{
					var EmployeesData = File.ReadAllText("Files\\employees.json"); // If Files Exist in Bin\Debug
					var Employees = JsonSerializer.Deserialize<List<Employee>>(EmployeesData);

					if (Employees?.Count > 0)
					{
						dbContext.Employees.AddRange(Employees);
						dbContext.SaveChanges();
					}
				}
				return true;
			}
			catch (Exception ex)
			{
				return false;
			}
		}

	}
}
