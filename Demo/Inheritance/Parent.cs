using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Inheritance
{
	class Parent
	{
		#region Properties 
		public int X { get; set; }
		public int Y { get; set; }
		#endregion
		#region Constructors
		public Parent()
		{
			
		}
		public Parent(int x, int y)
		{
			X = x;
			Y = y;
		}
		#endregion
		#region Methods 
		public override string ToString()
		{
			return $"X = {X} , Y = {Y}";
		}
		public int Product()
		{
			return X * Y;
		}
		#endregion
	}
}
