using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASS06_OOP.ThirdProject.DiscountClasses
{
    internal abstract class Abstract_Discount
    {
        public  abstract string? Name { get;  }


        public abstract decimal? CalculateDiscount(decimal price, int quantity);



    }
}
