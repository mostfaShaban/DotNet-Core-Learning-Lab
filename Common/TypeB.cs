using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
	public class TypeB : TypeA
	{
		public TypeB()
		{
			//A = 1; // Not Inherited  Private
			B = 2; // Inherited - Internal 
			C = 3; // Inherited - Public 
			X = 10; // Inherited private protected => private
			Y = 20; // Inherited protected => private
			Z = 30; // Inherited internal protected => internal
		}
		public void Print()
		{
			TypeA typeA = new TypeA();
			//typeA.A = 1; // Invalid Private 
			typeA.B = 2; // Valid Internal 
			typeA.C = 3; // Valid Public 
						 //typeA.X = 10; // Invalid private protected
						 //typeA.Y = 20; // Invalid protected
			typeA.Z = 30; // Valid Internal protected 
		}
	}
}
