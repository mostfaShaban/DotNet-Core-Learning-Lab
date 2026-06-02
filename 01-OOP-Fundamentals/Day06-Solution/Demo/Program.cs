using Demo.Abstraction;
using Demo.Partial;
using Demo.Sealed;
using Demo.Static;
using System.Text.RegularExpressions;

namespace Demo
{
    internal class Program
    {
		#region Abstraction
		static void ProcessShape(Shape shape)
		{
			if (shape is not null)
			{
				Console.WriteLine($"Area Of Shape = {shape.CalcArea()} ");
				Console.WriteLine($"Perimeter Of Shape = {shape.Perimeter} ");
			}
		}

		static void Print2DShape(ITwoDDraw shape)
		{


		}
		static void Print3DShape(IThreeDDraw shape)
		{

		}

		#endregion


		static void Main(string[] args)
        {

            #region Abstraction
            //Shape shape = new Rectangle();
            //// Cannot create an instance of the abstract type or interface 'Shape'
            //// But You Can Create a Reference From Abstract Class Refer To An Object
            //// From Class That Inherit and Implement Abstract Class


            //Rectangle rectangle = new Rectangle() { Dim01 = 10, Dim02 = 20 };
            //ProcessShape(rectangle);
            ////Console.WriteLine($"Area Of Rectangle = {rectangle.CalcArea()} "); // 200
            ////Console.WriteLine($"Perimeter Of Rectangle = {rectangle.Perimeter} "); // 400

            //Square square = new Square(10);
            //ProcessShape(square);
            ////Console.WriteLine($"Area Of Square = {square.CalcArea()} "); // 40
            ////Console.WriteLine($"Perimeter Of Square = {square.Perimeter} "); // 40

            //Circle circle = new Circle(10);
            //ProcessShape(circle);
            ////Console.WriteLine($"Area Of Circle = {circle.CalcArea()} "); // 314.0
            //////Console.WriteLine($"Perimeter Of Circle = {circle.Perimeter} "); // 62.80  


            #endregion

            #region Static 

            #region Static Methods

            //Utility U01 = new Utility(1, 2);
            ////Console.WriteLine($"Convert From Meter To Cm {U01.MeterToCm(1.2)}"); // 120
            //Console.WriteLine($"Circle Area =  {U01.CalculateCircleArea(10)}"); // 314
            //U01.X = 10;
            //U01.Y = 20;
            //Console.WriteLine("after Changing X , Y ");
            ////Console.WriteLine($"Convert From Meter To Cm {U01.MeterToCm(1.2)}"); // 120	
            //// The Result of Calling Method [MeterToCm] Does not Change By Changing Object State [X , Y]
            //Console.WriteLine($"Circle Area =  {U01.CalculateCircleArea(10)}"); // 314
            //// The Result of Calling Method [CalculateCircleArea] Does not Change By Changing Object State [X , Y]

            //Utility U02 = new Utility(100, 200);
            //Console.WriteLine("Different Object");
            ////Console.WriteLine($"Convert From Meter To Cm {U01.MeterToCm(1.2)}"); // 120
            //// The Result of Calling Method [MeterToCm] will not differ when you call it from different objects
            //Console.WriteLine($"Circle Area =  {U01.CalculateCircleArea(10)}"); // 314
            //// The Result of Calling Method [CalculateCircleArea] will not differ when you call it from different objects


            //Console.WriteLine($"Convert From Meter To Cm {Utility.MeterToCm(1.2)}"); // 120
            //Console.WriteLine($"Circle Area =  {Utility.CalculateCircleArea(10)}"); // 314

            //Test t1 = new Test();
            //Test t2 = new Test();

            //Console.WriteLine(Test.count);

            #endregion

            #region Static Fields and Property  

            //Utility U01 = new Utility(100, 200);
            ////U01.pi = 20; // Invalid  [Attribute]
            //U01.PI = 20; // valid  [Property]

            //Console.WriteLine(U01.PI); // 20
            //                           // The Value of Property [PI] Does not Affect By Object State [X , Y]

            //Console.WriteLine(Utility.PI); // 20

            #endregion
            #endregion

            #region Sealed

            //Parent parent = new Parent();
            //parent.Salary = 10_000;
            //Console.WriteLine(parent.Salary); // 11_000
            //parent.MyFun(); // I am Parent

            //Child child = new Child();
            //child.Salary = 10_000;
            //Console.WriteLine(child.Salary); // 13_000
            //child.MyFun(); // I Am Child

            //GrandChild grandChild = new GrandChild();
            //grandChild.Salary = 10_000;
            //Console.WriteLine(grandChild.Salary); // 16_000
            //grandChild.MyFun(); // I am GrandChild

            //Parent parentRef = new GrandChild();
            //parentRef.Salary = 10_000;
            //Console.WriteLine(parentRef.Salary); // 13_000
            //parentRef.MyFun(); // I Am Child 

            //Child prantchild = new GrandChild();
            //prantchild.Salary = 10_000;
            //Console.WriteLine(prantchild.Salary); //13000
            //prantchild.MyFun();  // I Am Child


            #endregion

            #region Partial 

            //Employee employee = new Employee();
            //employee.Id = 10;
            //employee.Name = "Mona";
            //employee.Age = 30;
            //employee.Print(10); // Hello From Employee

            #endregion
        }
    }
}
