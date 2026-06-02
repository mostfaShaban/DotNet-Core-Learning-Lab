using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASS_02_OOP
{
    internal struct Rectangle
    {
        private double width;
        private double height;


        public Double Width
        {
            get { return width; }

            set
            {
                if (value > 0)
                    width = value;
                else
                    Console.WriteLine("Error width can't negative");
            }

        }

        public Double Height
        {
            get { return height; }
            
            set {
                if (value > 0)
                    height = value;
                else
                    Console.WriteLine("Error height can't negative");
            }
        }

        public double Area
        {
            get { return width * height; }
        }

        public void DisplayInfo()
        {
            Console.WriteLine("Width: " + width);
            Console.WriteLine("Height: " + height);
            Console.WriteLine("Area: " + Area);
        }

    }
}
