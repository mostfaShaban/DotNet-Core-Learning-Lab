using ASS06_OOP.ThirdProject.DiscountClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASS06_OOP.ThirdProject.UserClasses
{
    internal class RegularUser : User
    {
        public override string? Name => "Regular User";

        public override Abstract_Discount GetDiscount()
        {
            return new PercentageDiscount { Percentage = 5 }; // 5% discount for regular users
        }
    }
}
