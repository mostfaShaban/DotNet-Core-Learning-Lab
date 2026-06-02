using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
	public class TypeA
	{
		private int X;
		internal int Y;
		public int Z;

		public TypeA()
		{
			X = 1; // X is private [ assessable within its Scope ]
			Y = 2; // Y is Internal [ assessable within its Scope ] 
			Z = 3; // Z is Public [ assessable within its Scope ]
		}
	}
}
