using ASS06_OOP.ThirdProject.DiscountClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASS06_OOP.ThirdProject.UserClasses
{
    internal class PremiumUser : User
    {
        public override string? Name => "Premium User";

        public override Abstract_Discount GetDiscount()
        {
            return new FlatDiscount { flatAmount = 100 }; // 100 units discount for premium users
        }
    }
}
