using ASS03_OOP.Inheritance;
using System.Globalization;
using System.Reflection;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ASS03_OOP
{
    internal class Program
    {

        static void Main(string[] args)
        {
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en-US");


            #region Q2.3
            //Employee emp1 = new Employee();
            //Console.WriteLine(emp1.ToString());
            //emp1.Id = 1;
            //emp1.Name = "John Doe";
            //emp1.SecurityLevel = SecurityLevel.Developer;
            //emp1.Salary = 50000;
            //emp1.Hiredate = new HireDate(15, 6, 2020);
            //Console.WriteLine(emp1.ToString());


            ////  Create Array of size 3
            //Employee[] EmpArr = new Employee[3];

            //EmpArr[0] = new Employee(1, "Alice", (SecurityLevel)1, 95000, new HireDate(15, 5, 2022), Gender.Female);
            //EmpArr[1] = new Employee(2, "Bob", (SecurityLevel)4, 35000, new HireDate(10, 1, 2025), Gender.M);
            //EmpArr[2] = new Employee(3, "Charlie", (SecurityLevel)15, 80000, new HireDate(20, 11, 2020), Gender.Female); 
            #endregion


            #region  4. Sort and Count Boxing/Unboxing
            // In C#, custom object sorting (Employee) uses references. 
            // Since we are using a strongly typed Array (Employee[]) and IComparable<Employee>, 
            // the boxing count is actually 0.

           // int boxingCount = 0;

           ////Array.Sort(EmpArr);

           // Console.WriteLine("--- Sorted Employees by Hire Date ---");
           // foreach (var emp in EmpArr)
           // {
           //     Console.WriteLine(emp.ToString());
           //     Console.WriteLine("===============");
           // }

           // Console.WriteLine($"\nBoxing/Unboxing occurred {boxingCount} times.");
           // Console.WriteLine("> Note: Because we used a generic Array and Interface, no boxing was necessary."); 

            #endregion

            #region 5 Design a program for a library management system with classes for Book, Member, and Library.


            //Book book1 = new EBook("The Great Gatsby", "F. Scott Fitzgerald", "978-0743273565", 1.5);

            //// This list can hold any object that "is-a" Book
            //List<Book> libraryCatalog = new List<Book>();

            //// Adding different types of books to the same collection
            //libraryCatalog.Add(new EBook("C# in Depth", "Jon Skeet", "978-1617294532", 4.2));
            //libraryCatalog.Add(new PrintedBook("The Clean Code", "Robert C. Martin", "978-0132350884", 464));
            //libraryCatalog.Add(new EBook("Architecting Cloud Computing", "Kevin L. Jackson", "978-1789133211", 12.5));

            //Console.WriteLine("========================================");
            //Console.WriteLine("    LIBRARY MANAGEMENT SYSTEM CATALOG   ");
            //Console.WriteLine("========================================\n");

            //// demonstrating Polymorphism:
            //// We call DisplayInfo() on a Book reference, but the 
            //// derived version (EBook or PrintedBook) executes.
            //foreach (var book in libraryCatalog)
            //{
            //    Console.WriteLine(book.ToString());
            //    Console.WriteLine("----------------------------------------");
            //}

            //Console.WriteLine($"Total items in catalog: {libraryCatalog.Count}"); 

            #endregion




        }
    }
}
