using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASS03_OOP
{
    internal class HireDate : IComparable<HireDate>
    {
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }

        public HireDate(int day, int month, int year)
        {
            Day = (day >= 1 && day <= 31) ? day : 1;
            Month = (month >= 1 && month <= 12) ? month : 1;
            Year = (year > 1900) ? year : 2000;
        }

        public override string ToString()
        {
            return $"{Day}/{Month}/{Year}";
        }

        public int CompareTo(HireDate other)
        {
            if (Year != other.Year)
                return Year.CompareTo(other.Year);

            if (Month != other.Month)
                return Month.CompareTo(other.Month);

            return Day.CompareTo(other.Day);
        }

    }


    #region Gender & Securitylevel enums
    public enum Gender : byte
    {
        Male = 1,
        Female = 2,
        M = 1,
        F = 2

    }
   
    [Flags]
    enum SecurityLevel : byte
    {
        Guest = 1,
        Developer = 2,
        Secretary = 4,
        DBA = 8
    } 
    #endregion

}
