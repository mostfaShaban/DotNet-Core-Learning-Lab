using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Interface_Example02
{
	internal class Airplane : Vehicle, IMoveOnGround, IMoveOnAir
	{
		// Methods That Implemented Explicitly can not Be non-Private
		void IMoveOnGround.Backward()
		{
			Console.WriteLine(value: "Airplane Move Backward on Ground");
		}
		void IMoveOnAir.Backward()
		{
			Console.WriteLine(value: "Airplane Move Backward on Air");
		}

		public void Forward()
		{
			Console.WriteLine(value: "Airplane Move Forward");
		}

		void IMoveOnGround.Left()
		{
			throw new NotImplementedException();
		}

		void IMoveOnAir.Left()
		{
			throw new NotImplementedException();
		}

		void IMoveOnGround.Right()
		{
			throw new NotImplementedException();
		}

		void IMoveOnAir.Right()
		{
			throw new NotImplementedException();
		}

	}
}
