using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ass01_OOP
{
    [Flags]
    internal enum Permissions
    {
        Read=1, 
        write=2,
        Delete=4, 
        Execute=8

    }
}
