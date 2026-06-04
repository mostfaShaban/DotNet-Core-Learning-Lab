using DatabaseFirst.Contexts;
using Microsoft.EntityFrameworkCore;

namespace DatabaseFirst
{
	internal class Program
	{
		static void Main(string[] args)
		{
			using NorthwindContext dbContext = new NorthwindContext();

			#region Select statements
			//var Result = dbContext.Products.FromSqlRaw("Select * from Products where CategoryID = 3");
			//int CatId = 3;
			//Result = dbContext.Products.FromSqlRaw("Select * from Products where CategoryID = {0}", CatId);
			//Result = dbContext.Products.FromSqlInterpolated($"Select * from Products where CategoryID = {CatId}");


			//foreach (var item in Result)
			//	Console.WriteLine(item.ProductName); 
			#endregion

			#region DML Statements 

			//var Result = dbContext.Database.ExecuteSqlRaw("Update Products Set ProductName = 'Testing' where ProductID = 1");
			//Console.WriteLine(Result);

			//int PrdID = 89;
			//Result = dbContext.Database.ExecuteSqlInterpolated($"Delete From Products Where ProductID = {PrdID}");
			//Console.WriteLine(Result);

			#endregion

			#region Stored Procedures 

			//NorthwindContextProcedures contextProcedures = new NorthwindContextProcedures(dbContext);


			//var Result = contextProcedures.DeleteProductByIDAsync(76).Result;
			//Console.WriteLine(Result);

			// var CustOrder =  contextProcedures.CustOrderHistAsync("ALFKI").Result;
			//CustOrder = dbContext.Procedures.CustOrderHistAsync("ALFKI").Result;

			//foreach (var item in CustOrder)
			//	Console.WriteLine(item);




			#endregion
		}
	}
}
