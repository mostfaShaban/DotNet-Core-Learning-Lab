using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
	internal class TypeB
	{
		public TypeB()
		{
			TypeA typeA = new TypeA();
			//typeA.X = 1;// Invalid  // X is private [ assessable within its Scope Only ]
			typeA.Y = 1; // Valid // Y is Internal [ assessable within its Scope and in Same Project Only] 
			typeA.Z = 1; // Valid // Z is Public [ assessable within its Scope and in Same Project ]
		}
	}
}
