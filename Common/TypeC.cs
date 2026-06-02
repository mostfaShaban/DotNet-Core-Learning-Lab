using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
	internal class TypeC
	{
		public void Print()
		{
			TypeB typeB = new TypeB();
			typeB.B = 2; // Valid internal
			typeB.C = 3; // Valid Public  
			//typeB.X = 10; // Invalid Private 
			//typeB.Y = 20; // Invalid Private 
			typeB.Z = 30; // Valid internal
		}
	}
}
