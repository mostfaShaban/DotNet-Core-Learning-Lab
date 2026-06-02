using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Sealed
{
	internal class Parent
	{
		private int salary;
		public virtual int Salary
		{
			get { return salary; }
			set { salary = value + 1000; }
		}
		public virtual void MyFun()
		{
			Console.WriteLine("I am Parent");
		}
	}
	internal class Child : Parent
	{
		// Sealed Method
		public sealed override int Salary 
		{		
			get { return base.Salary; }
			set { base.Salary = value + 2000; }
		}

		// Sealed Method
		public sealed override void MyFun()
		{
			Console.WriteLine("I Am Child");
		}
	}

	sealed class GrandChild : Child
	{
		public new int Salary
		{
			get { return base.Salary; }
			set { base.Salary = value + 3000; }
		}

		public new void MyFun()
		{
			Console.WriteLine("I am GrandChild");
		}
	}

	//class test : GrandChild // Can not Be Inherit From Grandchild Because it is Sealed Class
	//{

	//}

}
