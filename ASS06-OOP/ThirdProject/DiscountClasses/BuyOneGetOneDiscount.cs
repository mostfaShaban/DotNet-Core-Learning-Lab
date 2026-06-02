using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASS06_OOP.ThirdProject.DiscountClasses
{
    internal class BuyOneGetOneDiscount : Abstract_Discount
    {
        public override string? Name => "Buy One Get One Free";

        public override decimal? CalculateDiscount(decimal price, int quantity)
        {
            if(quantity>1)
            {
                decimal DiscountAmount = price/2 * (quantity / 2); // price of half quantity
                return DiscountAmount;
            }
            return 0;
        }
    }
}
