using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Polymorphism_Overriding
{
	internal class TypeA
	{

		#region Properties
		public int A { get; set; } 
		#endregion

		#region Constructors
		public TypeA(int a)
		{
			A = a;
		}
		#endregion

		#region Methods 
		public void MyFun01()
		{
			Console.WriteLine("This Is MyFun01 And I am Base");
		}

		public virtual void MyFun02()
		{
			Console.WriteLine($"This Is MyFun 02 TypeA : A = {A}");
		}
		#endregion
	}
}
