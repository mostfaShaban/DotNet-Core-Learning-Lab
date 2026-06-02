using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ASS05_OOP.Q1
{
    internal class Rectangle : IRectangle
    {
        public double Width { get; set ; }
        public double Height { get; set ; }
        public double Area { get => Width * Height; }

        public void DisplayShapeInfo()
        {
            Console.WriteLine($"Rectangle: Width = {Width}, Height = {Height}, Area = {Area}");
        }
    }
}
