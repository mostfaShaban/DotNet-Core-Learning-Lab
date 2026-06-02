using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASS05_OOP.Q1
{
    internal interface ICircle: IShape
    {
        public double Radius { get; set; }
    }
}
