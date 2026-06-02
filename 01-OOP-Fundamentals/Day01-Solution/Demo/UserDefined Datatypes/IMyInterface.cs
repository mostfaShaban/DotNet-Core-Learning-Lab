using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.UserDefined_Datatypes
{
	internal interface IMyInterface
	{
		///What You Can Write Inside?
		///1. Signature For Property => C# 7.0
		public int MyProperty { get; set; }

		///2. Signature For Method => C# 7.0
		internal void MyFunction();
		// Can not Use Private As Access Modifier

		///3. Default Implemented Method => C# 8.0 Feature .Net Core 3.1 [2019] 
		private void MyFunction02()
		{
			Console.WriteLine(MyProperty);
		}

	}
}
