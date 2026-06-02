using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASS06_OOP.SecondProject
{
    internal static class Maths
    {
       
        public static double X { get; set; }
        public static double Y { get; set; }

        //public  Maths(double x, double y)
        //{
        //    X = x;
        //    Y = y;
        //}
        public static double Add()
        {
            return X + Y;
        }
        public static double Subtract()
        {
            return X - Y;
        }
        public static double Multiply()
        {
            return X * Y;
        }
        public static double Divide()
        {
            if (Y == 0)
            {
                throw new DivideByZeroException("Cannot divide by zero.");
            }
            return X / Y;
        }

        new  public static string ToString()
        {
            return $"X: {X}, Y: {Y}";
        }


    }
}
