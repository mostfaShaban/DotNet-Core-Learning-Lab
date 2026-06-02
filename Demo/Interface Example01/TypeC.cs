using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Interface_Example01
{
	internal class TypeC
	{
		public int Current { get; set; }

		public void GetNext()
		{
			Current += 4;
		}
		public void Reset()
		{
			Current = 0;
		}
	}
}
