
using Common;
using Demo.Inheritance;

namespace Demo
{
    internal class Program
    {
        static void Main()
        {

			#region Class

			#region Example 01 
			//Car C1;
			/// Declare For Special Variable | Reference From Type "Car"
			/// C1 is a reference Referring To Default value of Reference Type => Null
			/// This Reference Can Refer To an Instance From Type Car Or Any Type Inherit From Car 
			/// CLR Will Allocate 4 bytes At Stack For Reference "C1"


			//C1 = new Car();
			/// Create Instance from Class :
			/// 1. Allocate Required Bytes At Heap for Object (16 Bytes) [id=> 4 Bytes , Model => 4 Bytes , Speed=> 8 bytes]
			/// 2. Initialize Allocated Bytes With Default Value [id => 0 , Model => Null , Speed => 0]
			/// 3. Call User Defined Constructor [If Exists] , if not Call Default Parameterless Constructor [Do Nothing]
			/// 4. Assign Address Of Allocated Object To Reference "C1"

			//Console.WriteLine(C1);
			/// Id = 0
			/// Model =
			/// Speed = 0

			//C1 = new Car(10 , "BMW" , 250);
			//Console.WriteLine(C1);
			//// Id = 10
			//// Model = BMW
			//// Speed = 250

			//Console.WriteLine(C1.GetHashCode());  
			#endregion

			#region Constructor Overloading - Constructor Chaining
			//Car C1 = new Car(10);
			//Console.WriteLine(C1);
			//         // 1st Ctor
			//         // 3rd Ctor
			//         // Id = 10
			//         // Model = Audi
			//         // Speed = 190
			//Console.WriteLine("=========================");
			//Car C2 = new Car(20 , "BYD");
			//Console.WriteLine(C2);
			//// 1st Ctor
			//// 2nd Ctor
			//// Id = 20
			//// Model = BYD
			//// Speed = 190
			//Console.WriteLine("==========================");
			//Car C3 = new Car(30 , "BMW" , 250);
			//Console.WriteLine(C3);
			////1st Ctor
			////Id = 30
			////Model = BMW
			////Speed = 250
			#endregion

			#endregion

			#region Inheritance 

			//Parent parent = new Parent(1 , 2);
			//parent.X = 10;
			//parent.Y = 20;
			//Console.WriteLine(parent); //X = 10 , Y = 20
			//Console.WriteLine($"Product = {parent.Product()}"); // 200

			//Child child = new Child(1,2,3);
			//child.X = 100;
			//child.Y = 200;
			//child.Z = 300;
			//Console.WriteLine(child.ToString()); // X = 100 , Y = 200 , Z = 300
			//Console.WriteLine($"Product = {child.Product()}"); // Product = 6000000

			#endregion

			#region Access Mofidiers 

			//TypeA typeA = new TypeA();
			////typeA.A = 1; // Invalid Private 
			////typeA.B = 2; // Invalid Internal 
			//typeA.C = 3; // Valid Public 
			//   //typeA.X = 10; // Invalid private protected
			//   //typeA.Y = 20; // Invalid protected
			//   //typeA.Z = 30; // Invalid Internal protected 

			//TypeB typeB = new TypeB();
			////typeB.B = 2; // Invalid internal
			//typeB.C = 3; // Valid Public  
			////typeB.X = 10; // Invalid Private 
			////typeB.Y = 20; // Invalid Private 
			////typeB.Z = 30; // Invalid internal

			//TypeD typeD = new TypeD();
			//typeD.C = 3; // Valid Public 
			////typeD.Y = 20; // Invalid Private 
			////typeD.Z = 30; // Invalid Private 

			#endregion

		}
	}
}
