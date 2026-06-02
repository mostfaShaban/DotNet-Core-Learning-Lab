using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Inheritance
{
	internal class TypeD : TypeA
	{
		public TypeD()
		{
			//A = 1; // Not Inherited  Private
			//B = 2; // Not Inherited - Internal 
			C = 3; // Inherited - Public 
			//X = 10; // Not Inherited private protected  
			Y = 20; // Inherited [protected => private]
			Z = 30; // Inherited [Internal protected => private]
		}

	}
}
