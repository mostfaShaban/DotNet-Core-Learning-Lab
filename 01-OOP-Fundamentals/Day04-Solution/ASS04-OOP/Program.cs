using ASS04_OOP.Classes;

namespace ASS04_OOP
{
    internal class Program
    {
        static void Main(string[] args)
        {

            #region Q1 Write a class named Calculator that contains a method named Add. Overload the Add method 

            //Calculator calculator = new Calculator();
            //int sum1 = calculator.Add(5, 10);
            //Console.WriteLine($"Sum of 5 and 10 is: {sum1}");
            //int sum2 = calculator.Add(5, 10, 15);
            //Console.WriteLine($"Sum of 5, 10 and 15 is: {sum2}");
            //double sum3 = calculator.Add(5.4, 10.5);
            //Console.WriteLine($"Sum of 5.5 and 10.5 is: {sum3}"); 

            #endregion

            #region Q2 Create a class named Rectangle with the following constructors:

            //Rectangle rect1 = new Rectangle();
            //Console.WriteLine(rect1.ToString()); // Output: "Height: 0, Width: 0"
            //Rectangle rect2 = new Rectangle { Height = 5, Width = 10 };
            //Console.WriteLine(rect2.ToString()); // Output: "Height: 5, Width: 10"
            //Rectangle rect3 = new Rectangle { Height = 3.5, Width = 7.2 };
            //Console.WriteLine(rect3.ToString()); // Output: "Height: 3.5, Width: 7.2"
            //Rectangle rect4 = new Rectangle(5);
            //Console.WriteLine(rect4.ToString()); // Output: "Height: 5, Width: 0" 

            #endregion

            #region Q3) Define a class Complex Number that represents a complex number with real and imaginary parts.
            //Note: Overload the +, - operator to add and subtract two complex numbers.

            //Complex_Number complex1 = new Complex_Number { Real = 3, Imaginary = 4 };
            //Console.WriteLine(complex1.ToString()); // Output: "3 + 4i"

            //Complex_Number complex2 = new Complex_Number { Real = 5, Imaginary = -2 };
            //Console.WriteLine(complex2.ToString()); // Output: "5 - 2i"
            //Complex_Number sumComplex = new Complex_Number();


            //sumComplex = complex1 + complex2;
            //Console.WriteLine($"Sum of and is: {sumComplex}"); // Output: "8 + 2i" 

            #endregion

            #region Q4 Create a base class named Employee & derived class named Manager that overrides the Work method 

            //Manger manger = new Manger();
            //manger.Work();  // Output: "Manger is working" 

            #endregion

            #region Q5 Create a base class BaseClass with a virtual........ then explain the difference between using override and new (using binding behavior)

            //Baseclass baseclass = new Baseclass();
            //baseclass.DisplayMessage();  // Output: "Message from BaseClass"

            ////binding
            //Baseclass baseclass1 = new DerivedClass1();
            //baseclass1.DisplayMessage(); // dynamic binding - runtime polymorphism
            //                             // resolve at runtime based on object type(DerivedClass1)

            //Baseclass baseclass2 = new DerivedClass2();
            //baseclass2.DisplayMessage(); // static binding - compile-time polymorphism
            //                             // resolve at compile time based on reference type(Baseclass) 
            #endregion

            #region Q5 Define Class Duration To include Three Attributes Hours, Minutes and Seconds......

            //Duration duration = new Duration(1, 30, 30);
            //Console.WriteLine(duration.ToString());
            //Console.WriteLine(duration.GetHashCode());
            ////Console.WriteLine(duration.Equals(new Duration { Hours = 2, Minutes = 30, Seconds = 45 }));

            //Duration D1 = new Duration(3600);
            //Console.WriteLine(D1.ToString());//1 hours, 0 minutes, 0 seconds

            //Duration D2 = new Duration(7800);
            //Console.WriteLine(D2.ToString());//2 hours, 10 minutes, 0 seconds

            //Duration D3 = new Duration(666);
            //Console.WriteLine(D3.ToString()); //0 hours, 11 minutes, 6 seconds

            #region Implement All required Operators overloading to enable this Code:

            ////1. Arithmetic Operators
            //D3 = D1 + D2;
            //Console.WriteLine(D3.ToString()); //3 hours, 10 minutes, 0 seconds

            //D3 = D1 + 500;
            //Console.WriteLine(D3.ToString()); //1 hours, 8 minutes, 20 seconds

            //D3 = 500 + D1;

            //D3 = D1 - D2;

            //// 2.unary Operators
            //D3 = ++D1;
            //Console.WriteLine(D3.ToString()); //1 hours, 0 minutes, 1 seconds
            //D3 = --D1;
            //Console.WriteLine(D3.ToString()); //1 hours, 0 minutes, 0 seconds



            //// 3. Comparison Operators
            ////If (D1>D2)
            //Console.WriteLine(D1 > D2 ? "D1 > D2" : "D1 < D2");
            ////If(D1 <= D2)
            //Console.WriteLine(D1 < D2 ? "D1 < D2" : "D1 > D2");

            ////if(D1)
            //Console.WriteLine(D1 ? "D1 is a Duration object" : "D1 is not a Duration object");

            ////4 casting operators
            ////DateTime DateTime Obj = (DateTime)D1

            //DateTime Obj = (DateTime)D1;
            //Console.WriteLine(Obj); // 01/01/0001 01:00:00 

            #endregion

            #endregion




        }

    }
}
