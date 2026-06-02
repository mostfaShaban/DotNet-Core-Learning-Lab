using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASS_02_OOP
{
    internal struct Point
    {

        public double X { get; set; }
        public double Y { get; set; }

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double CalculateDistance(Point secondPoint)
        {
            // القانون: √((x2-x1)² + (y2-y1)²)
            return Math.Sqrt(Math.Pow(secondPoint.X - this.X, 2) + Math.Pow(secondPoint.Y - this.Y, 2));
        }
    }
}
