using ASS06_OOP.ThirdProject.DiscountClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASS06_OOP.ThirdProject.UserClasses
{
    internal class GuestUser : User
    {
        public override string? Name => "Guest User";

        public override Abstract_Discount GetDiscount()
        {
            Console.WriteLine("Guest users do not receive any discounts.");
            return new NoDiscount(); // No discount for guest users
        }
    }

    internal class NoDiscount : Abstract_Discount
    {

        public override string? Name => "No Discount";

        public override decimal? CalculateDiscount(decimal price, int quantity)
        {
            return 0;
        }
    }
}
