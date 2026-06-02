using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Interface_Example01
{
	internal class TypeB : ISeries
	{
        //public TypeB(int v1, int v2)
        //{
        //    V1 = v1;
        //    V2 = v2;
        //}

        public int Current { get; set; }
        public int V1 { get; }
        public int V2 { get; }

        public void GetNext()
		{
			Current += 3;
		}
	}
}
