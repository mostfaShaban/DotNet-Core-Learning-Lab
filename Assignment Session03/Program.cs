using System.Collections.Generic;

namespace Assignment_Session03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region 1.	Write a program that allows the user to enter a number then print it.

            //Console.Write("please Enter A Number ");

            //if (int.TryParse(Console.ReadLine(), out int number))
            //        Console.WriteLine("You entered: " + number);
            //else
            //        Console.WriteLine("Invalid input. Please enter a valid number.");

            /////or best solution

            //int number;
            //string input;

            //do
            //{
            //    Console.Write("Enter a number: ");
            //    input = Console.ReadLine();

            //    if (!int.TryParse(input, out number))
            //    {
            //        Console.WriteLine("Invalid input. Please enter a valid number.");
            //    }

            //} while (!int.TryParse(input, out number));

            //Console.WriteLine("You entered: " + number);

            #endregion

            #region 2.Write C# program that converts a string to an integer, but the string contains non-numeric characters. And mention what will happen

            //Console.Write("enter string value : ");
            //String text = Console.ReadLine() ?? "";
            //int rus=Convert.ToInt32(((string)text).Trim());
            //Console.WriteLine(rus);
            //Unhandled exception. System.FormatException

            //or better solution

            //Console.Write("enter string value : ");
            //string text = Console.ReadLine()??"";

            //if (int.TryParse(text, out int number))
            //{
            //    Console.WriteLine("Converted: " + number);
            //}
            //else
            //{
            //    Console.WriteLine("Invalid number");
            //}


            #endregion

            #region 3.Write C# program that Perform a simple arithmetic operation with floating-point numbers And mention what will happen

            //double num1 = 0.1;
            //double num2 = 0.2;

            //double result = num1 + num2;

            //Console.WriteLine("Result = " + result); //Result = 0.30000000000000004

            #endregion

            #region 4. Write C# program that Extract a substring from a given string.

            //String text = "Programming" ??"";
            //string Substring1 = text.Substring(3, 4);
            //Console.WriteLine(Substring1); //gram


            #endregion

            #region 5.Write C# program that Assigning one value type variable to another and modifying the value of one variable and mention what will happen

            //int value01 = 30;
            //int value02 = 20;

            //Console.WriteLine("value 01 : " + value01);
            //Console.WriteLine("value 02 : " + value02);

            //value01 = value02;
            //Console.WriteLine("After Assigning ");
            //Console.WriteLine("value 01 : " + value01);
            //Console.WriteLine("value 02 : " + value02);

            #endregion

            #region 6.Write C# program that Assigning one reference type variable to another and modifying the object through one variable and mention what will happen

            //Person p1 = new Person();
            //p1.Name = "Ali";

            //Person p2 = p1; // هنا الاتنين بيشيروا لنفس الكائن

            //p2.Name = "Ahmed";

            //Console.WriteLine("p1 Name: " + p1.Name);
            //Console.WriteLine("p2 Name: " + p2.Name);


            #endregion

            #region 7.Write C# program that take two string variables and print them as one variable 

            //String text01 = " Mostfa Shaban";
            //String text02 = "Soudy";
            //string result = $"{text01} {text02}"; //string interpolation
            //string result01 = text01+" "+ text02; //string.Concat

            //Console.WriteLine(result);
            //Console.WriteLine(result01);

            #endregion

            #region 8.Write a program that calculates the simple interest given the principal amount, rate of interest, and time. 

            ////The formula for simple interest is Interest = (principal * rate * time ) /100.
            //double principal, rate, time;


            //Console.Write("Enter principal amount: ");
            //while (!double.TryParse(Console.ReadLine(), out principal))
            //{
            //    Console.WriteLine("Invalid input. Enter a valid number:");
            //}

            //Console.Write("Enter rate of interest: ");
            //while (!double.TryParse(Console.ReadLine(), out rate))
            //{
            //    Console.WriteLine("Invalid input. Enter a valid number:");
            //}

            //Console.Write("Enter time (in years): ");
            //while (!double.TryParse(Console.ReadLine(), out time))
            //{
            //    Console.WriteLine("Invalid input. Enter a valid number:");
            //}

            //double interest = (principal * rate * time) / 100;

            //Console.WriteLine("Simple Interest = " + interest);

            #endregion

            #region 9.Write a program that calculates the Body Mass Index (BMI) given a person's weight in kilograms and height in meters

            //Note :The formula for BMI is BMI = (Weight)/(Height*Height)

            //double weight, height;

            //Console.Write("Enter weight in kg: ");
            //while (!double.TryParse(Console.ReadLine(), out weight) || weight <= 0)
            //{
            //    Console.WriteLine("Invalid input. Enter a valid weight:");
            //}

            //Console.Write("Enter height in meters: ");
            //while (!double.TryParse(Console.ReadLine(), out height) || height <= 0)
            //{
            //    Console.WriteLine("Invalid input. Enter a valid height:");
            //}

            //double bmi = weight / (height * height);

            //Console.WriteLine("BMI = " + bmi);

            #endregion

            #region 10.Write a program that uses the ternary operator to check if the temperature is too hot, too cold, or just good. Assign the result in a variable then display the result

            //Console.Write("Enter a temperature :");
            //bool temp =double.TryParse(Console.ReadLine(), out double gratemperature);

            //string result =
            //    (gratemperature < 10) ? "Just Cold" :
            //    (gratemperature > 30) ? "Just Hot" : "Just Good";

            //Console.WriteLine(result);

            #endregion

            #region 11.Write a program that takes the date from the user and displays it in various formats using string interpolation.

            //DateTime date;

            //Console.Write("Enter Date: ");
            //while (!DateTime.TryParse(Console.ReadLine(), out date))
            //{
            //    Console.WriteLine("Invalid input. Enter a valid day:");
            //}

            //Console.WriteLine($"Today's date : {date.Day} , {date.Month} , {date.Year}");
            //Console.WriteLine($"Today's date : {date.Day} / {date.Month} / {date.Year}");
            //Console.WriteLine($"Today's date : {date.Day} - {date.Month} - {date.Year}");


            #endregion

            #region 12- Write a program that takes a number from the user then print yes if that number can be divided by 3 and 4 otherwise print no.

            //Console.Write("Enter A Number: ");
            //if (int.TryParse(Console.ReadLine(), out int number))
            //{
            //    if (number % 3 == 0 && number % 4 ==0)
            //        Console.WriteLine("Yes");
            //    else
            //        Console.WriteLine("NO");
            //}
            //else
            //{
            //    Console.WriteLine("Invalid input");
            //}

            #endregion

            #region 13- Write a program that allows the user to insert an integer then print negative if it is negative number otherwise print positive

            //Console.Write("Enter an integer: ");

            //if (int.TryParse(Console.ReadLine(), out int number))
            //{
            //    if (number < 0)
            //    {
            //        Console.WriteLine("negative");
            //    }
            //    else
            //    {
            //        Console.WriteLine("positive");
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("Invalid input");
            //}
            #endregion

            #region 14- Write a program that takes 3 integers from the user then prints the max element and the min element.

            //int a, b, c;

            //Console.Write("Enter first number: ");
            //while (!int.TryParse(Console.ReadLine(), out a))
            //{
            //    Console.WriteLine("Invalid input, try again:");
            //}

            //Console.Write("Enter second number: ");
            //while (!int.TryParse(Console.ReadLine(), out b))
            //{
            //    Console.WriteLine("Invalid input, try again:");
            //}

            //Console.Write("Enter third number: ");
            //while (!int.TryParse(Console.ReadLine(), out c))
            //{
            //    Console.WriteLine("Invalid input, try again:");
            //}

            //int max = a;
            //int min = a;

            //if (b > max) max = b;
            //if (c > max) max = c;

            //if (b < min) min = b;
            //if (c < min) min = c;

            //Console.WriteLine($"Max = {max}");
            //Console.WriteLine($"Min = {min}");
            #endregion

            #region 15- Write a program that allows the user to insert an integer number then check If a number is even or odd.

            //Console.Write("Enter an integer: ");

            //if (int.TryParse(Console.ReadLine(), out int number))
            //{
            //    if (number % 2 == 0)
            //    {
            //        Console.WriteLine("Even");
            //    }
            //    else
            //    {
            //        Console.WriteLine("Odd");
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("Invalid input");
            //}
            #endregion

            #region 16- Write a program that takes character from the user then if it is a vowel chars (a,e,I,o,u) then print (vowel) otherwise print (consonant).

            //Console.Write("Enter a character: ");

            //if (char.TryParse(Console.ReadLine(), out char ch))
            //{
            //    ch = char.ToLower(ch); // عشان نتعامل مع الحروف الكبيرة والصغيرة

            //    switch (ch)
            //    {
            //        case 'a':
            //        case 'e':
            //        case 'i':
            //        case 'o':
            //        case 'u':
            //            Console.WriteLine("vowel");
            //            break;

            //        default:
            //            Console.WriteLine("consonant");
            //            break;
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("Invalid input");
            //}
            #endregion

            #region 17- Write a program to input the month number and print the number of days in that month.

            //Console.Write("Enter month number (1-12): ");

            //if (int.TryParse(Console.ReadLine(), out int month) || month>1 || month<12)
            //{
            //    switch (month)
            //    {
            //        case 1: case 3:case 5:case 7:case 8:case 10:case 12:
            //            Console.WriteLine("31 days");
            //            break;

            //        case 4:case 6:case 9:case 11:
            //            Console.WriteLine("30 days");
            //            break;

            //        case 2:
            //            Console.WriteLine("28 or 29 days");
            //            break;

            //        default:
            //            Console.WriteLine("Invalid month number");
            //            break;
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("Invalid input");
            //}
            #endregion
        }
    }
}


class Person
{
    public string Name;
    public int Age;
}