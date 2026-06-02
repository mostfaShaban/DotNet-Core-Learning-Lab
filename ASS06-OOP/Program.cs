using ASS06_OOP.FirstProject;
using ASS06_OOP.SecondProject;
using ASS06_OOP.ThirdProject.DiscountClasses;
using ASS06_OOP.ThirdProject.UserClasses;
using System.Collections.Immutable;
using System.Globalization;

namespace ASS06_OOP
{
    internal class Program

    {
        #region Q1-HelperFunction
        public static _3D_Point ReadPointbyTryParse()
        {
            double x, y, z;

            Console.WriteLine("Enter Point Coordinates the point :");

            do
            {
                Console.Write("Enter X: ");
            } while (!double.TryParse(Console.ReadLine(), out x));

            do
            {
                Console.Write("Enter Y: ");
            } while (!double.TryParse(Console.ReadLine(), out y));

            do
            {
                Console.Write("Enter Z: ");
            } while (!double.TryParse(Console.ReadLine(), out z));

            return new _3D_Point(x, y, z);
        }

        public static _3D_Point ReadPointbyConvert()
        {
            double x = 0, y = 0, z = 0;
            bool isValid;

            Console.WriteLine("Enter Point Coordinates the point :");

            do
            {
                try
                {
                    Console.Write("Enter X: ");
                    x = Convert.ToDouble(Console.ReadLine());
                    isValid = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input for X. Please enter a valid number.");
                    isValid = false;
                }
            }
            while (!isValid);

            do
            {
                try
                {
                    Console.Write("Enter Y: ");
                    y = Convert.ToDouble(Console.ReadLine());
                    isValid = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input for Y. Please enter a valid number.");
                    isValid = false;
                }
            }
            while (!isValid);

            do
            {
                try
                {
                    Console.Write("Enter Z: ");
                    z = Convert.ToDouble(Console.ReadLine());
                    isValid = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input for Z. Please enter a valid number.");
                    isValid = false;
                }
            } while (!isValid);

            return new _3D_Point(x, y, z);
        }



        #endregion

        #region Q3-HelperFunction 
        static User GetUserFromInput()
        {
            string userType;
            do
            {
                Console.Write("Enter User Type (Regular / Premium / Guest): ");
                userType = Console.ReadLine()?.ToLower() ?? "";

            } while (userType != "regular" &&
                    userType != "premium" &&
                    userType != "guest");

            return userType switch
            {
                "regular" => new RegularUser(),
                "premium" => new PremiumUser(),
                _ => new GuestUser()
            };

        }

        static decimal GetPrice()
        {
            decimal price;

            do
            {
                Console.Write("Enter Product Price: ");
            }
            while (!decimal.TryParse(Console.ReadLine(), out price) || price < 0);

            return price;
        }

        static int GetQuantity()
        {
            int quantity;

            do
            {
                Console.Write("Enter Quantity: ");
            }
            while (!int.TryParse(Console.ReadLine(), out quantity) || quantity <= 0);

            return quantity;
        }
        #endregion

        static void Main(string[] args)
        {
            #region First Project

            //_3D_Point point0 = new _3D_Point(10, 10, 10);
            //Console.WriteLine(point0.ToString());

            #region  3.	Read from the User the Coordinates for 2 points P1, P2 (Check the input using try Pares, Parse, Convert).

            //_3D_Point P1 = ReadPointbyTryParse();
            //_3D_Point P2 = ReadPointbyTryParse();
            //Console.WriteLine(P1.ToString());
            //Console.WriteLine(P2.ToString());

            //_3D_Point P3 = ReadPointbyConvert();
            //_3D_Point P4 = ReadPointbyConvert();
            //Console.WriteLine(P3.ToString());
            //Console.WriteLine(P4.ToString()); 

            #endregion


            #region 4.	Try to use  ==  If(P1 == P2)Does it work properly

            //_3D_Point P1 = new _3D_Point(1, 2, 3);
            //_3D_Point P2 = new _3D_Point(1, 2, 3);
            //Console.WriteLine(P1.GetHashCode());
            //Console.WriteLine(P2.GetHashCode());
            //Console.WriteLine(P1 == P2); // reference equality, should be false if not overridden

            ////After overriding Equals and GetHashCode, we can check for value equality:
            //Console.WriteLine(P1 == P2 ? "P1 and P2 are equal." : "P1 and P2 are not equal."); 

            #endregion

            #region 5.Define an array of points and sort this array based on X & Y coordinates

            //_3D_Point[] points = new _3D_Point[6]
            //    {
            //    new _3D_Point(10, 2, 3),
            //    new _3D_Point(4, 5, 6),
            //    new _3D_Point(4, 8, 9),
            //    new _3D_Point(3, 11, 12),
            //    new _3D_Point(13, 14, 15),
            //    null
            //    };


            //Array.Sort(points);
            //Console.WriteLine("\nSorted Points:");
            //foreach (var point in points)
            //{
            //    Console.WriteLine(point);

            //}


            #endregion

            #region 6- Clone a point and change its coordinates

            //_3D_Point p1 = new _3D_Point(1, 2, 3);

            //// Clone Object
            //_3D_Point p2 = (_3D_Point)p1.Clone();

            //Console.WriteLine("P1 = " + p1);
            //Console.WriteLine("P2 = " + p2);

            //Console.WriteLine();

            //p2.X = 100;

            //Console.WriteLine("After Change:");

            //Console.WriteLine("P1 = " + p1);
            //Console.WriteLine("P2 = " + p2);  
            #endregion

            #endregion

            #region SecondProject

            //// non static class by class making object and calling the methods
            //Maths M1 = new Maths(10,2);
            //Console.WriteLine(M1.ToString());
            //Console.WriteLine("Addition: " + M1.Add());
            //Console.WriteLine("Subtraction: " + M1.Subtract());
            //Console.WriteLine("Multiplication: " + M1.Multiply());
            //Console.WriteLine("Division: " + M1.Divide());

            ////static class by calling the methods directly without making object
            //Maths.X = 10;
            //Maths.Y = 0;
            //Console.WriteLine("Addition: " + Maths.Add());
            //Console.WriteLine("Subtraction: " + Maths.Subtract());
            //Console.WriteLine("Multiplication: " + Maths.Multiply());
            //try
            //{
            //    Console.WriteLine("Division: " + Maths.Divide());
            //}
            //catch (DivideByZeroException ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}

            #endregion

            #region ThirdProject

            // Inputs
            User user = GetUserFromInput();
            decimal price = GetPrice();
            int quantity = GetQuantity();

            // Calculations
            Abstract_Discount discount = user.GetDiscount();
            decimal totalPrice = price * quantity;
            decimal discountAmount = discount.CalculateDiscount(price, quantity) ?? 0m;
            decimal finalPrice = totalPrice - discountAmount;

            Console.WriteLine(price.ToString("C", CultureInfo.CreateSpecificCulture("en-US")));
            // Output
            Console.WriteLine("\n===== Order Details =====");
            Console.WriteLine($"User Type      : {user.GetType().Name}");
            Console.WriteLine($"Price          : {price:C}");
            Console.WriteLine($"Quantity       : {quantity}");
            Console.WriteLine($"Discount Type  : {discount.Name}");
            Console.WriteLine($"Discount Amount: {discountAmount:C}");
            Console.WriteLine($"Final Price    : {finalPrice:C}");
            Console.WriteLine("=========================\n");

            #endregion


        }
    }
}
