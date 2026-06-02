using Demo.Binding;
using Demo.Builtin_Interfaces;
using Demo.Interface;
using Demo.Interface_Example01;
using Demo.Interface_Example02;
using System.Text;

//using TypeA = Demo.Binding.TypeA;
//using TypeB = Demo.Binding.TypeB;
//using TypeC = Demo.Binding.TypeC;

using Type = Demo.Interface.Type;
using TypeA = Demo.Interface_Example01.TypeA;
using TypeB = Demo.Interface_Example01.TypeB;
using TypeC = Demo.Interface_Example01.TypeC;

namespace Demo
{
    internal class Program
    {

        static void PrintFiveNumbersFromSeries(ISeries series)
        {
            if (series is not null)
            {
                for (int i = 1; i <= 5; i++)
                {
                    Console.WriteLine($"{series.Current} ");
                    series.GetNext();
                }
                series.Reset();
            }
            else
            {
                return;
            }
        }

        static void Main(string[] args)
        {
            #region Binding 



            //TypeA typeARef = new TypeB(1, 2);
            //typeARef.MyFun01();  //I am Type A [Base]
            //					 // Static Binding 
            //					 // Called Based On Reference Type 

            //typeARef.MyFun02(); // TypeB : A = 1 , B = 2
            //					// Dynamic Binding 
            //					// Called Based On Object Type 

            //TypeA typeARef = new TypeC(1, 2, 3);
            //typeARef.MyFun01(); // I am Type A [Base]
            //typeARef.MyFun02(); // TypeC : A = 1 , B = 2 , C = 3

            //TypeB typeBRef = new TypeC(1, 2, 3);
            //typeBRef.MyFun01(); // I am TypeB (Child)
            //typeBRef.MyFun02(); // TypeC : A = 1 , B = 2 , C = 3

            //TypeA typeARef = new TypeD(1, 2, 3, 4);
            //typeARef.MyFun01(); // I am Type A [Base]
            //typeARef.MyFun02(); // TypeC : A = 1 , B = 2 , C = 3

            //TypeB typeBRef = new TypeD(1, 2, 3, 4);
            //typeBRef.MyFun01(); // I am TypeB (Child)
            //typeBRef.MyFun02(); // TypeC : A = 1 , B = 2 , C = 3

            //TypeC typeCRef = new TypeD(1, 2, 3, 4);
            //typeCRef.MyFun01(); // I am TypeC (Grand Child)
            //typeCRef.MyFun02(); // TypeC : A = 1 , B = 2 , C = 3

            //TypeA typeARef = new TypeE(1, 2, 3, 4, 5); // Indirect Parent
            //TypeB typeBRef = new TypeE(1, 2, 3, 4, 5); // Indirect Parent 
            //TypeC typeCRef = new TypeE(1, 2, 3, 4, 5); // Indirect Parent 
            //TypeD typeDRef = new TypeE(1, 2, 3, 4, 5); // Direct Parent 

            //typeARef.MyFun02(); // TypeC : A = 1 , B = 2 , C = 3
            //typeBRef.MyFun02();	// TypeC : A = 1 , B = 2 , C = 3
            //typeCRef.MyFun02(); // TypeC : A = 1 , B = 2 , C = 3
            //typeDRef.MyFun02(); // TypeE : A = 1 , B = 2 , C = 3 , D = 4 , E = 5

            #endregion

            #region Interface 
            //IType refType;
            //// Declare Reference From Type "IType"
            //// This Reference Can Refer To An Object From Any Type That Implement Interface "IType"
            //// CLR Will Allocate 4 Uninitialized Bytes At Stack 

            ////refType = new IType(); // Invalid 

            //refType = new Type();
            //refType.MyProperty = 10;
            //refType.MyMethod(); // Hello From Type
            //refType.Print(); // Default Implemented Method


            //Type typeObj = new Type();
            //typeObj.MyProperty = 10;
            //typeObj.MyMethod(); // Hello From Type
            //                    //typeObj.Print(); // Invalid 
            #endregion

            #region Interface Example 01


            //TypeA typeA = new TypeA();
            //PrintFiveNumbersFromSeries(typeA); // 0 2 4 6 8

            //Console.WriteLine("======================");

            //TypeB typeB = new TypeB();
            //PrintFiveNumbersFromSeries(typeB); // 0 3 6 9 12 

            //TypeC typeC = new TypeC();
            //PrintFiveNumbersFromSeries(typeC); // Invalid [Class Doesn't Implement Interface]

            #endregion

            #region Interface Example 02

            //Car carObj = new Car();
            //carObj.Speed = 120;
            //carObj.Backward(); // Move Car Backward
            //carObj.Forward();  // Move Car Forward
            //carObj.Left();     // Move Car Left
            //carObj.Right();    // Move Car Right


            //Airplane airplaneObj = new Airplane();
            ////airplaneObj.Backward(); // Invalid
            //airplaneObj.Forward();  // Airplane Move Forward
            ////airplaneObj.Left();    // Invalid
            ////airplaneObj.Right();    // Invalid


            //IMoveOnAir moveAirplaneOnAir = new Airplane();
            //moveAirplaneOnAir.Backward(); // Airplane Move Backward on Air
            //moveAirplaneOnAir.Forward();  // Airplane Move Forward
            //moveAirplaneOnAir.Left();     // NotImplementedException
            //moveAirplaneOnAir.Right();    // NotImplementedException


            //IMoveOnGround moveAirplaneOnGround = new Airplane();
            //moveAirplaneOnGround.Backward(); // Airplane Move Backward on Ground
            //moveAirplaneOnGround.Forward();  // Airplane Move Forward
            //moveAirplaneOnGround.Left();     // NotImplementedException
            //moveAirplaneOnGround.Right();    // NotImplementedException

            #endregion

            #region Shallow Copy And Deep Copy 

            #region Array Of Value Type 

            //int[] Arr01 = { 1, 2, 3 };
            //int[] Arr02 = new int[3];

            //Console.WriteLine($"HashCode Of Arr01 = {Arr01.GetHashCode()}"); // 54267293
            //Console.WriteLine($"HashCode Of Arr02 = {Arr02.GetHashCode()}"); // 18643596

            #region Shallow Copy 
            //Arr02 = Arr01; // Shallow Copy 
            //			   // Copy Value Of Arr01 To Arr02
            //			   // Copy Happened In Stack
            //			   // [ Arr01 , Arr02 ] => Has Same Value [Address]
            //			   // [ Arr01 , Arr02 ] => Refer To Same Object 

            ////Console.WriteLine("Shallow Copy");
            ////Console.WriteLine($"HashCode Of Arr01 = {Arr01.GetHashCode()}"); // 54267293
            ////Console.WriteLine($"HashCode Of Arr02 = {Arr02.GetHashCode()}"); // 54267293 
            ////Console.WriteLine("After Change Any Value From Arr01");
            ////Arr01[0] = 100;

            ////Console.WriteLine($"Arr01[0] = {Arr01[0]}"); // 100
            ////Console.WriteLine($"Arr02[0] = {Arr02[0]}"); // 100

            #endregion

            #region Deep Copy 

            ////Arr02 = (int[])Arr01.Clone(); // Deep Copy 
            ////							  // Happened In Heap
            ////							  // Create New Object With Different and New Identity and Return It
            ////							  // The New Object Will Have The Same Object State [Data] Of Caller "Arr01"

            ////Console.WriteLine("Deep Copy");
            ////Console.WriteLine($"HashCode Of Arr01 = {Arr01.GetHashCode()}"); // 54267293
            ////Console.WriteLine($"HashCode Of Arr02 = {Arr02.GetHashCode()}"); // 33574638 
            ////Console.WriteLine("After Change Any Value From Arr01");
            ////Arr01[0] = 100;

            ////Console.WriteLine($"Arr01[0] = {Arr01[0]}"); // 100
            ////Console.WriteLine($"Arr02[0] = {Arr02[0]}"); // 1

            #endregion

            #endregion

            #region Array Of Reference Type 


            #region Immutable Reference Type [String]
            //string[] names01 = { "Omar", "Amr" };
            //string[] names02 = new string[2]; // { null , null }

            //Console.WriteLine($"Hash code Of names01 ={names01.GetHashCode()} "); // 54267293
            //Console.WriteLine($"Hash code Of names02 ={names02.GetHashCode()} "); // 18643596

            #region Shallow Copy 

            ////names02 = names01; // Shallow Copy 
            ////				   // Copy Value Of names01 To names02 
            ////				   // Copy Happened In Stack
            ////				   // [ names01 , names02 ] => Has Same Value [Address]
            ////				   // [ names01 , names02 ] => Refer To Same Object 

            ////Console.WriteLine("after Shallow Copy");
            ////Console.WriteLine($"Hash code Of names01 ={names01.GetHashCode()} "); // 54267293
            ////Console.WriteLine($"Hash code Of names02 ={names02.GetHashCode()} "); // 54267293

            ////Console.WriteLine($"Names01[0] = {names01[0]}"); //  Omar
            ////Console.WriteLine($"Names02[0] = {names02[0]}"); //  Omar

            ////names01[0] = "Salma";
            ////Console.WriteLine("after Changing names01[0]");
            ////Console.WriteLine($"Names01[0] = {names01[0]}"); // Salma
            ////Console.WriteLine($"Names02[0] = {names02[0]}"); // Salma

            #endregion

            #region Deep Copy 
            ////names02 = (string[])names01.Clone(); // Deep Copy 
            ////									 // Happened In Heap
            ////									 // Create New Object With Different and New Identity and Return It
            ////									 // The New Object Will Have The Same Object State [Data] Of Caller "names01"
            ////									 // [ names01 , names02 ] => Refer To Different Objects

            ////Console.WriteLine("after Deep Copy");
            ////Console.WriteLine($"Hash code Of names01 ={names01.GetHashCode()} "); // 54267293
            ////Console.WriteLine($"Hash code Of names02 ={names02.GetHashCode()} "); // 33574638

            ////Console.WriteLine($"Names01[0] = {names01[0]}"); //  Omar
            ////Console.WriteLine($"Names02[0] = {names02[0]}"); //  Omar

            ////names01[0] = "Salma";
            ////Console.WriteLine("after Changing names01[0]");
            ////Console.WriteLine($"Names01[0] = {names01[0]}"); // Salma
            ////Console.WriteLine($"Names02[0] = {names02[0]}"); // Omar
            #endregion

            #endregion

            #region Mutable Reference Type [stringbuilder]

            ////StringBuilder[] names01 = new StringBuilder[1];
            ////names01[0] = new StringBuilder("Omar");

            //StringBuilder[] names01 = [new StringBuilder("Omar")]; // Collection expressions  [ C# 12 Feature ]
            //StringBuilder[] names02 = new StringBuilder[1];

            //Console.WriteLine($"Hash code Of names01 ={names01.GetHashCode()} "); // 54267293
            //Console.WriteLine($"Hash code Of names02 ={names02.GetHashCode()} "); // 18643596

            #region Shallow Copy 

            ////names02 = names01; // Shallow Copy 
            ////				   // Copy Value Of names01 To names02 
            ////				   // Copy Happened In Stack
            ////				   // [ names01 , names02 ] => Has Same Value [Address]
            ////				   // [ names01 , names02 ] => Refer To Same Object 

            ////Console.WriteLine("after Shallow Copy");
            ////Console.WriteLine($"Hash code Of names01 ={names01.GetHashCode()} "); // 54267293
            ////Console.WriteLine($"Hash code Of names02 ={names02.GetHashCode()} "); // 54267293

            ////Console.WriteLine($"Names01[0] = {names01[0]}"); //  Omar
            ////Console.WriteLine($"Names02[0] = {names02[0]}"); //  Omar

            ////names01[0].Append(" Salma");
            ////Console.WriteLine("after Changing names01[0]");
            ////Console.WriteLine($"Names01[0] = {names01[0]}"); // Omar Salma
            ////Console.WriteLine($"Names02[0] = {names02[0]}"); // Omar Salma

            #endregion

            #region Deep Copy 
            ////names02 = (StringBuilder[])names01.Clone(); // Deep Copy 
            ////											// Happened In Heap
            ////											// Create New Object With Different and New Identity and Return It
            ////											// The New Object Will Have The Same Object State [Data] Of Caller "names01"
            ////											// [ names01 , names02 ] => Refer To Different Objects

            ////Console.WriteLine("after Deep Copy");
            ////Console.WriteLine($"Hash code Of names01 ={names01.GetHashCode()} "); // 54267293
            ////Console.WriteLine($"Hash code Of names02 ={names02.GetHashCode()} "); // 33574638

            ////Console.WriteLine($"Names01[0] = {names01[0]}"); //  Omar
            ////Console.WriteLine($"Names02[0] = {names02[0]}"); //  Omar

            ////names01[0].Append(" Ahmed");
            ////Console.WriteLine("after Changing names01[0]");
            ////Console.WriteLine($"Names01[0] = {names01[0]}"); // Omar Ahmed
            ////Console.WriteLine($"Names02[0] = {names02[0]}"); // Omar Ahmed
            //#endregion

            #endregion


            #endregion

            #endregion

            #endregion

            #region Built in Interface

            #region ICloneable

            //Employee employee01 = new Employee() { Id = 10, Name = "Omar", Salary = 5000 };
            //Employee employee02 = new Employee() { Id = 20, Name = "Mona", Salary = 7500 };
            //Console.WriteLine($"employee01 = {employee01}"); // Id = 10 , Name = Omar , Salary = $5,000.00
            //Console.WriteLine($"employee01.GetHashCode() = {employee01.GetHashCode()}"); // 54267293
            //Console.WriteLine($"employee02 = {employee02}"); // Id = 20 , Name = Mona , Salary = $7,500.00
            //Console.WriteLine($"employee02.GetHashCode() = {employee02.GetHashCode()}"); // 18643596
            //employee02 = (Employee)employee01.Clone(); // This Is Deep Copy 

            ///// Clone Method : This Method Generates new Object With New  and Different Identity
            ///// This Object Will Have Same Object State [Data] of Caller Object  

            //// 2nd Way To Do Deep Copy [Copy Constructor]
            //// Copy Constructor : is a Special Constructor Used To Make a Deep Copy For Reference Type Object 
            //employee02 = new Employee(employee01);

            //Console.WriteLine("after Deep Copy");
            //Console.WriteLine("=========================");
            //employee01.Salary = 9000;
            //employee01.Name = "Ahmed";
            //Console.WriteLine($"employee01 = {employee01}"); // Id = 10 , Name = Ahmed , Salary = $9,000.00
            //Console.WriteLine($"employee01.GetHashCode() = {employee01.GetHashCode()}"); // 54267293
            //Console.WriteLine($"employee02 = {employee02}"); // Id = 10 , Name = Omar , Salary = $5,000.00
            //Console.WriteLine($"employee02.GetHashCode() = {employee02.GetHashCode()}"); // 33574638 

            #endregion

            #region IComparable

            //Employee[] employees =
            //{
            //	new Employee(){Id= 10 , Name = "Omar" , Salary = 6000},
            //	new Employee(){Id= 20 , Name = "Ahmed" , Salary = 10000},
            //	new Employee(){Id= 30 , Name = "Sama" , Salary = 4000},
            //	new Employee(){Id= 40 , Name = "May" , Salary = 5000},
            //};

            //Array.Sort(employees); 
            //Array.Reverse(employees); // To Reverse Order 
            //foreach (Employee employee in employees)
            //{
            //	Console.WriteLine(employee);
            //}
            //// Id = 30 , Name = Sama , Salary = $4,000.00
            //// Id = 40 , Name = May , Salary = $5,000.00
            //// Id = 10 , Name = Omar , Salary = $6,000.00
            //// Id = 20 , Name = Ahmed , Salary = $10,000.00
            //// Sorting Employee Based On Salary In ascending Order  

            #endregion

            #region IComparer

            //Employee[] employees =
            //{
            //    new Employee(){Id= 10 , Name = "Omar" , Salary = 6000},
            //    new Employee(){Id= 20 , Name = "Ahmed" , Salary = 10000},
            //    new Employee(){Id= 30 , Name = "Sama" , Salary = 4000},
            //    new Employee(){Id= 40 , Name = "May" , Salary = 5000},
            //};
            //// Sorting Array Based On Name


            //Array.Sort(employees, new EmployeeNameComparer());
            //foreach (Employee employee in employees)
            //{
            //    Console.WriteLine(employee);
            //}
            //// Id = 20 , Name = Ahmed , Salary = $10,000.00
            //// Id = 40 , Name = May , Salary = $5,000.00
            //// Id = 10 , Name = Omar , Salary = $6,000.00
            //// Id = 30 , Name = Sama , Salary = $4,000.00
            ////// Sorting Employee Based On Name In ascending Order  

            #endregion

            #endregion

        }

    }
}
