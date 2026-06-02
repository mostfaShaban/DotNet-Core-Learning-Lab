using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ASS04_OOP.Classes
{
    internal class Complex_Number
    {

        public int Real { get; set; }
        public int Imaginary { get; set; }

        //operator  +

        public static Complex_Number operator +(Complex_Number c1, Complex_Number c2)
        {
            return new Complex_Number
            {
                Real = (c1?.Real ?? 0) + (c2?.Real ?? 0),
                Imaginary = (c1?.Imaginary ?? 0) + (c2?.Imaginary ?? 0)
            };
        }


        override public string ToString()
        {
            if (Imaginary < 0)
                return $"{Real} - {Math.Abs(Imaginary)}i";
            else
                return $"{Real} + {Imaginary}i";
        }
    }
}
