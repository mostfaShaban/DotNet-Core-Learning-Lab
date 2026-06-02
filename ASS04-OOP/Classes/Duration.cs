using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASS04_OOP.Classes
{
    internal class Duration
    {
        #region Methods

        //Hours, Minutes and Seconds

        public int Hours { get; set; }
        public int Minutes { get; set; }
        public int Seconds { get; set; }

        #endregion

        #region Constructors
        public Duration(int hours, int minutes, int seconds)
        {
            Hours = hours;
            Minutes = minutes;
            Seconds = seconds;
        }

        public Duration(int totalSeconds)
        {
            Hours = totalSeconds / 3600;
            Minutes = (totalSeconds % 3600) / 60;
            Seconds = totalSeconds % 60;
        }
        #endregion

        #region Ovrridemethod 
        override public string ToString()
        {
            return $"{Hours} hours, {Minutes} minutes, {Seconds} seconds";
        }

        override public bool Equals(object obj)
        {
            if (obj is Duration other) //Pattern Matching
            {
                return Hours == other.Hours && Minutes == other.Minutes && Seconds == other.Seconds;
            }
            return false;
        }

        override public int GetHashCode() //Generate a hash code based on content of obj when equal objects have same hash code
        {
            return HashCode.Combine(Hours, Minutes, Seconds);
        }
        #endregion

        #region OperatorOverloading


        public static Duration operator +(Duration d1, Duration d2)
        {
            int totalSeconds = (d1.Hours + d2.Hours) * 3600 + (d1.Minutes + d2.Minutes) * 60 + (d1.Seconds + d2.Seconds);
            return new Duration(totalSeconds);
        }

        // Duration +4000
        public static Duration operator +(Duration d1, int seconds)
        {
            int totalSeconds = (d1.Hours * 3600 + d1.Minutes * 60 + d1.Seconds) + seconds;
            return new Duration(totalSeconds);
        }

        // 4000 + Duration
        public static Duration operator +(int seconds, Duration d1)
        {
            int totalSeconds = seconds + (d1.Hours * 3600 + d1.Minutes * 60 + d1.Seconds);
            return new Duration(totalSeconds);
        }
        //D1- D2
        public static Duration operator -(Duration d1, Duration d2)
        {
            int totalSeconds = (d1.Hours - d2.Hours) * 3600 + (d1.Minutes - d2.Minutes) * 60 + (d1.Seconds - d2.Seconds);
            return new Duration(totalSeconds);
        }

        //++Duration
        public static Duration operator ++(Duration d1)
        {
            int totalSeconds = (d1.Hours * 3600 + d1.Minutes * 60 + d1.Seconds) + 1;
            return new Duration(totalSeconds);
        }

        //--Duration
        public static Duration operator --(Duration d1)
        {
            int totalSeconds = (d1.Hours * 3600 + d1.Minutes * 60 + d1.Seconds) - 1;
            return new Duration(totalSeconds);
        }

        // If (D1>D2)
        // If(D1<=D2)

        public static bool operator >(Duration d1, Duration d2)
        {
            int totalSeconds1 = d1.Hours * 3600 + d1.Minutes * 60 + d1.Seconds;
            int totalSeconds2 = d2.Hours * 3600 + d2.Minutes * 60 + d2.Seconds;
            return totalSeconds1 > totalSeconds2;
        }

        public static bool operator <(Duration d1, Duration d2)
        {
            int totalSeconds1 = d1.Hours * 3600 + d1.Minutes * 60 + d1.Seconds;
            int totalSeconds2 = d2.Hours * 3600 + d2.Minutes * 60 + d2.Seconds;
            return totalSeconds1 < totalSeconds2;
        }

        ////If (D1)

        public static bool operator true(Duration d)
        {
            return d != null && (d.Hours != 0 || d.Minutes != 0 || d.Seconds != 0);
        }

        public static bool operator false(Duration d)
        {
            return d == null || (d.Hours == 0 && d.Minutes == 0 && d.Seconds == 0);
        }


        //DateTime Obj = (DateTime) D1 //cast Duration to DateTime

        public static explicit operator DateTime(Duration d)
        {
            return new DateTime(1, 1, 1).AddHours(d.Hours).AddMinutes(d.Minutes).AddSeconds(d.Seconds);
        }









        #endregion



    }
}
