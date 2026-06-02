using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Interface
{
	internal class Type : IType
	{
		public int MyProperty { get; set ; }

		public void MyMethod()
		{
			Console.WriteLine("Hello From Type");
		}
		//// Invalid To Change Method Signature 
		//public bool MyMethod()
		//{
		//}
	}
}
