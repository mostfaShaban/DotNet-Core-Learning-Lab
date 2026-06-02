using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Reflection;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ASS05
{
    internal class Program
    {
        #region Methods

        //static void Calculate(int a, int b, int c, int d, out int sum, out int subtract)
        //{
        //    sum = a + b;
        //    subtract = c - d;
        //}

        /* static int SumOfDigits(int number)
         {
             int sum = 0;

             while (number != 0)
             {
                 sum += number % 10; // ناخد آخر رقم
                 number /= 10;       // نحذف آخر رقم
             }

             return sum;
         }*/

        /*static bool IsPrime(int number)
        {
            if (number <= 1)
                return false;

            for (int i = 2; i * i <= number; i++)
            {
                if (number % i == 0)
                    return false;
            }

            return true;
        }  */

        //static void MinMaxArray(int[] arr, ref int min, ref int max)
        //{
        //    min = arr[0];
        //    max = arr[0];

        //    for (int i = 1; i < arr.Length; i++)
        //    {
        //        if (arr[i] < min)
        //            min = arr[i];

        //        if (arr[i] > max)
        //            max = arr[i];
        //    }
        //}

        /*static int Factorial(int number)
        {
            int result = 1;

            for (int i = 1; i <= number; i++)
            {
                result *= i;
            }

            return result;
        }*/

        //static string ChangeChar(string text, int position, char newChar)
        //{
        //    char[] chars = text.ToCharArray(); // نحولها لمصفوفة

        //    chars[position] = newChar; // نغير الحرف في المكان المطلوب

        //    return new string(chars); // نرجعها string جديدة
        //}


        #endregion


        static void Main(string[] args)
        {
            #region 1-	Explain the difference between passing (Value type parameters) by value and by reference then write a suitable c# example.

            /* => Passing by Value(Value Type Parameters)
                A copy of the variable is passed to the method.
                Any changes made inside the method do NOT affect the original variable.
                This is the default behavior in C#. */

            /* Passing by Reference
                    The actual variable itself is passed to the method.
                    Any changes inside the method DO affect the original variable.
                    In C#, this is done using the ref or out keyword.  */


            #endregion

            #region 2-	Explain the difference between passing (Reference type parameters) by value and by reference then write a suitable c# example

            /* => Passing by Value(Reference Type Parameters)
                A copy of the reference (pointer) to the object is passed to the method.
                The method can modify the object that the reference points to, but it cannot change the reference itself to point to a different object. */

            /* => Passing by Reference(Reference Type Parameters)
                        The actual reference (pointer) to the object is passed to the method. */

            //Reference Type by value = "copy of reference"
            //Reference Type by reference = "reference itself"

            #endregion

            #region 3-	Write a c# Function that accept 4 parameters from user and return result of summation and subtracting of two numbers

            //Console.Write("Enter 4 numbers: ");

            //int n1 = int.Parse(Console.ReadLine()??"0");
            //int n2 = int.Parse(Console.ReadLine()??"0");
            //int n3 = int.Parse(Console.ReadLine()??"0");
            //int n4 = int.Parse(Console.ReadLine()??"0");

            //int sumResult, subResult;

            //Calculate(n1, n2, n3, n4, out sumResult, out subResult);

            //Console.WriteLine("Sum = " + sumResult);
            //Console.WriteLine("Subtract = " + subResult);

            #endregion

            #region 4-	Write a program in C# Sharp to create a function to calculate the sum of the individual digits of a given number.

            // //Output should be like
            // //Enter a number: 25
            // //The sum of the digits of the number 25 is: 7


            //Console.Write("Enter a number: ");
            //int num = int.Parse(Console.ReadLine());

            //int result = SumOfDigits(num);

            //Console.WriteLine("The sum of the digits of the number " + num + " is: " + result);


            #endregion

            #region 5-	Create a function named "IsPrime", which receives an integer number and retuns true if it is prime, or false if it is not:


            //Console.Write("Enter a number: ");
            //int number = int.Parse(Console.ReadLine());
            //Console.WriteLine(
            //    IsPrime(number) ? $"{number} is a prime number." : $"{number} is not a prime number."

            //);




            #endregion

            #region 6-	Create a function named MinMaxArray, to return the minimum and maximum values stored in an array, using reference parameters

            //int[] numbers = { 5, 2, 9, 1, 7 };

            //int minValue=0, maxValue=0 ;

            //MinMaxArray(numbers, ref minValue, ref maxValue);

            //Console.WriteLine("Min = " + minValue);
            //Console.WriteLine("Max = " + maxValue);




            #endregion

            #region 7-	Write a C# function to calculate the factorial of a number

            //Console.Write("Enter a number: ");

            //int num = int.Parse(Console.ReadLine()??"0");

            //int factorial = Factorial(num);
            //Console.WriteLine("The factorial of " + num + " is: " + factorial);

            #endregion

            #region 8-	Create a function named "ChangeChar" to modify a letter in a certain position (0 based) of a string, replacing it with a different letter

            //Console.Write("Enter a string: ");
            //string input = Console.ReadLine() ?? "";
            //Console.Write("Enter the position to change (0-based): ");
            //int position = int.Parse(Console.ReadLine() ?? "0");
            //Console.Write("Enter the new character: ");
            //char newChar = Console.ReadLine()?[0] ?? ' ';

            //string modifiedString = ChangeChar(input, position, newChar);
            //Console.WriteLine("Modified string: " + modifiedString);
            
            #endregion

        }
    }
}
