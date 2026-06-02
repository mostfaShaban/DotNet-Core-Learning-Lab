using Demo.Sealed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Partial
{
	internal partial class Employee 
	{
		internal partial void Print(int x)
		{
			Console.WriteLine("Hello From Employee");
		}
	}
}
