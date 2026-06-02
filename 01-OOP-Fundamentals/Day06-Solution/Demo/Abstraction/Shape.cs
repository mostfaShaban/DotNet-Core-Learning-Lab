using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Abstraction
{
	// Abstract Class : Is a Container For Common Code For Other Classes
	// Common Code => [Fully Implemented Members , Abstracted Members ]
	internal abstract class Shape
	{
		protected Shape()
		{
			
		}
		public Shape(decimal dim01, decimal dim02)
		{
			Dim01 = dim01;
			Dim02 = dim02;
		}

		public decimal Dim01 { get; set; }
		public decimal Dim02 { get; set; }

		// Abstract Property [ ReadOnly Property ]
		public abstract decimal Perimeter { get; }

		// Abstract Method 
		abstract public decimal CalcArea();
	}

	abstract class RecBase : Shape
	{
		public override decimal CalcArea()
		{
			return Dim01 * Dim02;
		}
	}

	// Concrete Class => Triangle is a shape 
	class Triangle : Shape
	{
		public decimal Dim03 { get; set; }
		public Triangle(decimal dim01 , decimal dim02  , decimal dim03):base(dim01 , dim02 )
		{
			//Dim01 = dim01;
			//Dim02 = dim02;
			Dim03 = dim03;
		}
		public override decimal Perimeter => throw new NotImplementedException();

		public override decimal CalcArea()
		{
			throw new NotImplementedException();
		}
	}

	// Concrete Class : Fully Implemented Class
	class Rectangle : RecBase
	{
		public override decimal Perimeter
		{
			get
			{
				return Dim02 * Dim01 * 2;
			}
		}
	}

	class Square : RecBase , ITwoDDraw , IThreeDDraw
	{
		public Square(decimal side)
		{
			Dim01 = Dim02 = side;
		}
		public override decimal Perimeter
		{
			get { return Dim01 * 4; }
		}

        void ITwoDDraw.Draw()
        {
            throw new NotImplementedException();
        }

        void IThreeDDraw.Draw()
        {
            throw new NotImplementedException();
        }
    }

	class Circle : Shape, ITwoDDraw
	{
		public Circle(decimal Radius)
		{
			Dim01 = Dim02 = Radius;
		}
		public override decimal Perimeter
		{
			get
			{
				return 2 * 3.14M * Dim01;
			}
		}
		public override decimal CalcArea()
		{
			return 3.14M * Dim01 * Dim01; 
		}
		public void Draw()
		{
			throw new NotImplementedException();
		}
	}

	interface ITwoDDraw
	{
		void Draw();
	}

	interface IThreeDDraw 
	{
		void Draw();

	}
}

