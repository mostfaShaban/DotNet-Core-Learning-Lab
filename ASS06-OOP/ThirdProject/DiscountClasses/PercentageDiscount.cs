using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASS06_OOP.ThirdProject.DiscountClasses
{
    internal class PercentageDiscount : Abstract_Discount
    {
        //Accepts a percentage (e.g., 10%).


        public decimal Percentage { get; set; }
        public override string? Name => "Percentage Discount";

        public override decimal? CalculateDiscount(decimal price, int quantity)
        {
            decimal DiscountAmount = price * quantity * (Percentage / 100);
            return DiscountAmount;
        }
    }
}
