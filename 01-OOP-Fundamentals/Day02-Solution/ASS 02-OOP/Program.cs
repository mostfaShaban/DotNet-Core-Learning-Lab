using System.Xml.Linq;

namespace ASS_02_OOP
{
    internal class Program
    {
        static void Main(string[] args)
        {

            #region 1.Define a struct "Person" with properties "Name" and "Age" write a C# program to display the details of all the persons in the array.

            //Person[] people = new Person[3];

            //people[0] = new Person("Mohamed", 25);
            //people[1] = new Person("Ahmed", 30);
            //people[2] = new Person("Sara", 28);

            //Console.WriteLine("--- Details of Persons in Array ---");

            //// Display the details using a loop
            //foreach (var person in people)
            //{
            //    Console.WriteLine($"Name: {person.Name}, Age: {person.Age}");
            //}
            #endregion

            #region 2.Create a struct called "Point" to represent a 2D point with properties "X" and   "Y". Write a C# program that takes two points as input from the user and calculates the distance between them.

            //Console.Write("Enter X1: ");
            //double.TryParse(Console.ReadLine(), out double x1);
            //Console.Write("Enter Y1: ");
            //double.TryParse(Console.ReadLine(), out double y1);
            //Point p1 = new Point(x1, y1);

            //// p2
            //Console.Write("Enter X2: ");
            //double.TryParse(Console.ReadLine(), out double x2);
            //Console.Write("Enter Y2: ");
            //double.TryParse(Console.ReadLine(), out double y2);
            //Point p2 = new Point(x2, y2);

            //double distance = p1.CalculateDistance(p2);
            //Console.WriteLine($"Distance is: {distance:F2}");


            #endregion

            #region  3.Create a struct called "Person" with properties "Name" and "Age". 
            //Write a C# program that takes details of 3 persons as input from the user and displays
            //the name and age of the oldest person.

            //Person[] Workers = new Person[3];

            //for (int i = 0; i < Workers.Length; i++)
            //{
            //    Console.WriteLine($"Enter the person {i+1}");
            //    Workers[i] = new Person();
            //    Workers[i].ReadData();
            //}

            ////for (int i = 0; i < Workers.Length; i++)
            ////{
            ////    Workers[i].Display();
            ////}


            //Person oldperson = Person.GetOldest(Workers);

            //Console.WriteLine("Oldest person is: " + oldperson.Name + " Age: " + oldperson.Age);

            #endregion

            #region 4 . Create a struct named Rectangle

            Rectangle rectangle = new Rectangle();
            rectangle.Width = 10;
            rectangle.Height = 20;
            rectangle.DisplayInfo();

            #endregion

        }

    }
}
