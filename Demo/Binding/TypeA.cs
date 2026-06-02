using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Binding
{
	internal class TypeA
	{
		public int A { get; set; }
		public TypeA(int a)
		{
			A = a;
		}

		// Static Polymorphism 
		public void MyFun01()
		{
			Console.WriteLine("I am Type A [Base]");
		}

		// Dynamic Polymorphism 
		public virtual void MyFun02()
		{
			Console.WriteLine($"Type A : A = {A}");
		}
	}
}
