using ASS06_OOP.ThirdProject.DiscountClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASS06_OOP.ThirdProject.UserClasses
{
    internal abstract class User 
    {
        public abstract string? Name { get; } //readonly property
        public abstract Abstract_Discount GetDiscount();

    }
}
