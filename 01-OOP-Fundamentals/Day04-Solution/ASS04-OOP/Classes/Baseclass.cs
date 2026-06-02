using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASS04_OOP.Classes
{
    internal class Baseclass
    {

        public virtual void DisplayMessage()
        {
            Console.WriteLine("Message from BaseClass");
        }


    }

    internal class DerivedClass1 : Baseclass
    {
        override public void DisplayMessage()
        {

            Console.WriteLine("Message from DerivedClass1");
        }
    }

    internal class DerivedClass2 : Baseclass
    {
        new public void DisplayMessage()
        {
            Console.WriteLine("Message from DerivedClass2");
        }
    }


}
