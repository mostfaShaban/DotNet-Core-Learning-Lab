using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Polymorphism_Overriding
{
	internal class TypeB : TypeA
	{
		public int B { get; set; }
		public TypeB(int a, int b) : base(a)
		{
			B = b;
		}

		// Using Keyword New To Hide Inherited Member TypeA.MyFun01 [Masking - New Version]	
		new public void MyFun01() 
		{
			Console.WriteLine("This Is MyFun01 And I am Child");
		}
		// Using Keyword Override To Override Inherited Member TypeA.MyFun01 That Is Must be Marked As Virtual and Public in its First Appearance
		public override void MyFun02()
		{
			Console.WriteLine($"This Is MyFun02 TypeB : A = {A}  , B = {B}");
		}
	}
}
