using Demo.Encapsulation;

namespace Demo
{
	internal class Program
	{
		static void Main( string[] args)
		{

            #region Struct 

            #region Example 01
            //Point P1;
            //// Declare variable | Object From Type 'Point' 
            //// CLR Will Allocate 8 Unitintialized Bytes At Stack 

            //P1 = new Point();
            //// New Is Just For Constructor Selection That Will Used To Initialize P1 Attribute 

            ////Console.WriteLine($"P1.X = {P1.x}"); // 0
            ////Console.WriteLine($"P1.Y = {P1.y}"); // 0

            //P1 = new Point(10, 20);
            //P1 = new(10, 20); // Syntax Sugar 
            //Console.WriteLine($"P1.X = {P1.x}"); // 10
            //Console.WriteLine($"P1.Y = {P1.y}"); // 20

            //Point P2 = new Point(100);
            //Console.WriteLine($"P2.X = {P2.x}"); // 100
            //Console.WriteLine($"P2.Y = {P2.y}"); // 100


            //Console.WriteLine(P1); // (10 , 20)
            //Console.WriteLine(P1.ToString()); // (10 , 20)
            #endregion

            #region Example 02

            //Point P1 = new Point(1, 2);
            //Console.WriteLine($"P1.X = {P1.x}"); // 1 
            //Console.WriteLine($"P1.Y = {P1.y}"); // 2

            //Point P2 = new Point(10, 20);
            //Console.WriteLine($"P2.X = {P2.x}"); // 10 
            //Console.WriteLine($"P2.Y = {P2.y}"); // 20

            //P2 = P1;

            //Console.WriteLine("After Assign P2 = P1");
            //Console.WriteLine($"P1.X = {P1.x}"); // 1 
            //Console.WriteLine($"P1.Y = {P1.y}"); // 2
            //Console.WriteLine($"P2.X = {P2.x}"); // 1 
            //Console.WriteLine($"P2.Y = {P2.y}"); // 2

            //P1.x = 100;
            //P1.y = 200;

            //Console.WriteLine("After Changing P1 ");
            //Console.WriteLine($"P1.X = {P1.x}"); // 100 
            //Console.WriteLine($"P1.Y = {P1.y}"); // 200
            //Console.WriteLine($"P2.X = {P2.x}"); // 1 
            //Console.WriteLine($"P2.Y = {P2.y}"); // 2

            #endregion

            #endregion

            #region Encapsulation

            #region Example 01 

            //Employee emp01 = new Employee(name: "Omar", id: 10, salary: 1000, age: 25);
            //Console.WriteLine(emp01);
            // Id : 10
            // Name : Omar
            // Salary : $1,000.00

            //emp01.Id = 20; // Set Id Directly Through Attribute
            //Console.WriteLine(emp01.Id); // Get Id Directly Through Attribute

            //emp01.SetName("Ahmed"); // Set Name Using Setter Function 
            //Console.WriteLine(emp01.GetName());  // Get Name using Getter Function


            //emp01.Salary = 9000; // Set Salary Using Property As Setter 
            //Console.WriteLine(emp01.Salary); // Get Salary Using Property As Getter 

            #endregion

            #region Example 02

            //PhoneNotebook notebook = new PhoneNotebook(3);
            //notebook.AddPerson(0, "Ali", 123);
            //notebook.AddPerson(1, "Samy", 456);
            //notebook.AddPerson(2, "Mona", 789);

            //notebook.SetNumber("Samy", 999); // Set Using Setter Method 
            //Console.WriteLine(notebook.GetNumber("Samy")); // Get Using Getter Method 

            //notebook["Samy"] = 999; // Set Using Indexer As Setter 
            //Console.WriteLine(notebook["Samy"]); // Get Using Indexer As Getter 


            ////string name = "Route";
            ////Console.WriteLine(name[0]); // R
            //////name[0] = 'L'; // Invalid 

            //for (int i = 0; i < notebook.Size; i++)
            //{
            //	Console.WriteLine(notebook[i]);
            //}

            #endregion

            #endregion
        }
    }
}
