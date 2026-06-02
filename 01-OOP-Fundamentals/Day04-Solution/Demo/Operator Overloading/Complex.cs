using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Operator_Overloading
{
	internal class Complex
	{
		public int Real { get; set; }
		public int Img { get; set; }

		public override string ToString()
		{
			return $"{Real} + {Img}i";
		}


		#region Operator Overloading
		public static Complex operator +(Complex left, Complex right)
		{
			return new Complex()
			{
				Real = (left?.Real ?? 0) + (right?.Real ?? 0),
				Img = (left?.Img ?? 0) + (right?.Img ?? 0)
			};
		}

		public static Complex operator -(Complex left, Complex right)
		{
			return new Complex()
			{
				Real = (left?.Real ?? 0) - (right?.Real ?? 0),
				Img = (left?.Img ?? 0) - (right?.Img ?? 0)
			};
		}



		public static Complex operator ++(Complex C)
		{
			return new Complex()
			{
				Real = (C?.Real ?? 0) + 1,
				Img = (C?.Img ?? 0)
			};
		}

		public static Complex operator --(Complex C)
		{
			return new Complex()
			{
				Real = (C?.Real ?? 0) - 1,
				Img = (C?.Img ?? 0)
			};
		}

		public static bool operator >(Complex left, Complex right)
		{
			if (left?.Real == right?.Real)
				return left?.Img > right?.Img;
			else
				return left?.Real > right?.Real;
		}
		public static bool operator <(Complex left, Complex right)
		{
			if (left?.Real == right?.Real)
				return left?.Img < right?.Img;
			else
				return left?.Real < right?.Real;
		}

		public static explicit operator int(Complex C)
		{
			return C?.Real ?? 0;
		}
		public static implicit operator string(Complex C)
		{
			//return $"{C.Real} + {C.Img}i";
			return C?.ToString() ?? string.Empty;
		}
		#endregion
	}
}
