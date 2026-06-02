using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASS06_OOP.ThirdProject.DiscountClasses
{
    internal class FlatDiscount : Abstract_Discount
    {

        public decimal flatAmount { get; set; }

        public override string? Name => "Flat Discount";

        public override decimal? CalculateDiscount(decimal price, int quantity)
        {
            decimal DiscountAmount = flatAmount * Math.Min(quantity, 1);
            return DiscountAmount;
        }
    }
}
