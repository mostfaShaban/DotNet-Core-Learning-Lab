using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Interface
{
	internal interface IType
	{
		// 1. Properties Signatures
		public int MyProperty { get; set; }

		// 2. Method Signatures
		public void MyMethod();

		// 3. Default Method Implementations (C# 8.0 and later)
		public void Print()
		{
			Console.WriteLine("Default Implemented Method");
		}

	}
}
