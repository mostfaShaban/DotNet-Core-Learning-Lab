using Demo.Binding;
using Demo.Operator_Overloading;
using Demo.Polymorphism_Overriding;

namespace Demo
{
    internal class Program
    {
		#region Method Overloading
		//static int SumNumbers(int X , int Y)
		//{
		//    return X + Y;
		//}
		//static int SumNumbers(int X, int Y , int Z)
		//{
		//	return X + Y + Z;
		//}

		////      static double SumNumbers(int X , int Y) 
		////      // cannot overload a method just by changing the return type 
		////{
		////          return (double)X + (double)Y;
		////      }

		//static double SumNumbers(double X, double Y)
		//{
		//	return X + Y;
		//}


		//static double SumNumbers(int X, double Y)
		//{
		//	return X + Y;
		//}

		//static double SumNumbers(double X, int Y)
		//{
		//	return X + Y;
		//} 
		#endregion

		#region Binding

		//public static void ProcessEmployee(FulltimeEmployee employee) // FulltimeEmployee employee = new FulltimeEmployee(10, "Omar", 25, 20000)
		//{
		//	if (employee is not null)
		//	{
		//		employee.GetEmployeeType();
		//		employee.GetEmployeeData();
		//	}
		//}

		public static void ProcessEmployee(Employee employee) // Ref From Parent Refer To Object From Child [Binding] 
		{
			if (employee is not null)
			{
				employee.GetEmployeeType(); // Overrided Using New Static Binding Bind Function Call Based On Reference Type
				employee.GetEmployeeData();// Overrided Using override Dynamic Binding Bind Function Call Based On Object Type
			}
		} 
		#endregion

		static void Main(string[] args)
        {
			#region Method Overloading

			//         int A = 10 , B = 20 ;
			//         int Result = SumNumbers(A , B);
			//         Result = SumNumbers(10, 20, 30);
			//         double Result02 = SumNumbers(1.2, 1.2);
			//Console.WriteLine(Result); // 30


			//Console.WriteLine();
			#endregion

			#region Operator Overloading
			//Complex C1 = new Complex() { Real = 4, Img = 2 };
			//Complex C2 = new Complex() { Real = 3, Img = 1 };
			//Complex? C3 = default; // NULL

			#region Binary Operators


			//C3 = C1 + C2;
			//Console.WriteLine(C1);
			//Console.WriteLine(C2);
			//Console.WriteLine("==================");
			//Console.WriteLine(C3); // 7 + 3i 

			#endregion

			#region Unary Operators

			//C3 = C1++;
			//Console.WriteLine("After PostFix C3 = C1++");
			//Console.WriteLine($"C1 = {C1}"); // C1 = 5 + 2i
			//Console.WriteLine($"C3 = {C3}"); // C3 = 4 + 2i

			//C3 = ++C1;

			//Console.WriteLine("After PreFix C3 = ++C1");
			//Console.WriteLine($"C1 = {C1}"); // C1 = 5 + 2i
			//Console.WriteLine($"C3 = {C3}"); // C3 = 5 + 2i

			#endregion

			#region Relational Operators 

			//if (C1 > C2)
			//	Console.WriteLine("C1 > C2 ");
			//else if (C1 < C2)
			//	Console.WriteLine("C1 < C2");
			//else
			//	Console.WriteLine("C1 Equals C2");

			//string message = C1 > C2 ? "C1 > C2" : "C1 < C2 ";
			//Console.WriteLine(message); // C1 > C2


			#endregion

			#region Casting Operator Overloading 

			//int X = (int)C1; // Invalid 

			//string str = C1; // Implicit 
			//str = (string)C1; // Explicit
			//Console.WriteLine(str); // 4 + 2i

			#endregion
			#endregion

			#region User Defined Datatype Casting Operator overloading [Mapping]

			//User user01 = new User()
			//{
			//	Id = 1,
			//	FullName = "Mona Tarek",
			//	Email = "MonaTarek@gmail.com",
			//	Password = "P@ssw0rd",
			//	SecurityStamp = Guid.NewGuid()
			//};

			//UserViewModel userViewModel = (UserViewModel)user01;


			#endregion

			#region Polymorphism - Overriding 

			//TypeA typeAObj = new TypeA(1);
			//typeAObj.A = 10;
			//typeAObj.MyFun01(); // This Is MyFun01 And I am Base
			//typeAObj.MyFun02(); // This Is MyFun 02 TypeA : A = 10


			//TypeB typeBObj = new TypeB(1, 2);
			//typeBObj.A = 10;
			//typeBObj.B = 20;
			//typeBObj.MyFun01(); // This Is MyFun01 And I am Child
			//typeBObj.MyFun02(); // This Is MyFun02 TypeB : A = 10  , B = 20

			#endregion

			#region Binding 

			//TypeA refBase = new TypeB(1, 2);
			//refBase.A = 10;
			////refBase.B = 20; // Invalid 
			//refBase.MyFun01(); // This Is MyFun01 And I am Base
			//				   // MyFun01() Method is Overrided Using "new" Resolves at compile time based on reference type
			//				   // Static Binding | Early Binding 


			//refBase.MyFun02(); // This Is MyFun02 TypeB : A = 10  , B = 2
			//				   // MyFun02() Method Overrided Using "override" Resolves at runtime based on object type
			//				   // Dynamic Binding | late Binding 

			#endregion

			#region When Binding Happens 

			//FulltimeEmployee fulltimeEmployeeObj = new FulltimeEmployee(10, "Omar", 25, 20000);
			//ProcessEmployee(fulltimeEmployeeObj);
			//// I Am Employee
			//// Employee Data : Id = 10 , Name = Omar , Age = 25 Salary = 20000

			////ParttimeEmployee parttimeEmployeeObj = new ParttimeEmployee(20, "Mona", 30, 50, 120);
			////ProcessEmployee(parttimeEmployeeObj);
			////// I Am Employee
			////// Employee Data : Id = 20 , Name = Mona , Age = 30 , Hour Rate = 120 , Count Of Hours = 50
			#endregion

		}
	}  
}
