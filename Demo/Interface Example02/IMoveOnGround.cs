using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Interface_Example02
{
	internal interface IMoveOnGround
	{
		public void Forward();
		public void Backward();
		public void Left();
		public void Right();
	}
}
