using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseFirst.Models
{
    public partial class CustOrderHistResult
    {
		public override string ToString()
		{
			return $"{ProductName} - {Total}";
		}
	}
}
