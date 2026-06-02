using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASS04_OOP.Classes
{
    internal class Employee
    {
        public virtual void Work()
        {
            Console.WriteLine("Employee is working.");
        }


    }

    internal class Manger : Employee
    {
        override public void Work()
        {
            base.Work();
            Console.WriteLine("Manager is managing.");
        }


    }
}
