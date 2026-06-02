using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASS05_OOP.Q1
{
    internal class Circle : ICircle
    {
        public double Radius { get ; set ; }

        public double Area => Math.PI * Math.Pow(Radius, 2);

        public void DisplayShapeInfo()
        {
            Console.WriteLine($"Circle: Radius = {Radius}, Area = {Area}");
        }
    }
}
