using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Static
{
	internal static class Utility
	{
        // Class Member Method 
        public static double MeterToCm(double value)
		{
			return value * 100;
		}
        

        // Class Member Constructor - Static Constructor 
        static Utility()
		{
			// Used to initialize static fields or perform other setup tasks that only need to occur once.
			Console.WriteLine("Static Constructor");
			pi = 10.22; // Valid [ Static Readonly Attribute ]
		}

		// Class member Attribute 
		//private static double pi = 3.14;

		private static readonly double pi = default; //  Readonly Attribute
		/// Assigned at runtime By CLR 
		/// CLR Will Initialize Every and Each Static Attribute with Default Value of Its Type 
		/// Before First Use of The Class
		/// Use Of Class :
		/// 1. Creating Object From Class Or Object From Class
		/// 2. Before any static members are accessed


		//private const double pi = 3.14; // must be initialized at this point [ declaration ]
		//								// cannot be assigned a value in a constructor [Static Or Non-Static] or method


		/// Class Member Property - Static Property
		/// Must Deal With Static Attribute	 Or Constant Only 
		public static double PI // readonly Property 
		{
			get { return pi; }
			//set { pi = value; } // It is A Readonly Attribute
		}

		// Class Member Method
		public static double CalculateCircleArea(double Radius)
		{
			return pi * Radius * Radius; // Can not Use pi Because it is non static member 
		}
	}


    class Test
    {
        public static int count = 0;

        public Test()
        {
            count++;
        }
    }
}
