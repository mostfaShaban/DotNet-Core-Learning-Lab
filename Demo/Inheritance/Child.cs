using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Inheritance
{
	class Child : Parent
	{
		#region Proprties
		public int Z { get; set; }

		#endregion

		#region Constructors

		public Child(int x, int y, int z) : base(x, y)
		{
			Z = z;
		} 
		#endregion

		#region Methods 
		public override string ToString()
		{
			return $"X = {X} , Y = {Y} , Z = {Z}";
		}
		public new int Product()
		{
			return X * Y * Z;
		}
		#endregion

	}
}
