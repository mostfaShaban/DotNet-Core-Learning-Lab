using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASS04_OOP.Classes
{
    internal class Rectangle
    {
        public double Height { get; set; }
        public double Width { get; set; }


        // 1. Parameterless constructor
        public Rectangle()
        {
            Width = 0;
            Height = 0;
        }

        // 2. Constructor with width and height
        public Rectangle(int width, int height)
        {
            Width = width;
            Height = height;
        }

        // 3. Constructor with one parameter
        public Rectangle(int side)
        {
            Width = side;
            Height = side;


        }

        override public string ToString()
        {
            return $"Rectangle: Width = {Width}, Height = {Height}";
        }
    }
}
