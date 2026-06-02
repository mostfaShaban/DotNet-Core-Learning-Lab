using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASS06_OOP.FirstProject
{
    internal class _3D_Point : IComparable, ICloneable
    {
        #region propeties
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        #endregion

        public _3D_Point(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        override public string ToString()
        {
            return $"Point Coordinates:  : ({X}, {Y}, {Z})";
        }


        #region Implement interface Method
        public object Clone()
        {
            return new _3D_Point(this.X, this.Y, this.Z);
        }

        public int CompareTo(object? obj)
        {
            _3D_Point? otherPoint = obj as _3D_Point;

            if (otherPoint == null)
                return 1;

            if (X != otherPoint.X)
                return X.CompareTo(otherPoint.X);

            if (Y != otherPoint.Y)
                return Y.CompareTo(otherPoint.Y);

            return Z.CompareTo(otherPoint.Z);
        }

        #endregion


        #region operator overloading
        public static bool operator ==(_3D_Point right, _3D_Point left)
        {
            if (ReferenceEquals(right, left))
                return true;

            if (right is null || left is null)
                return false;

            return right.X == left.X &&
                   right.Y == left.Y &&
                   right.Z == left.Z;
        }
        public static bool operator !=(_3D_Point right, _3D_Point left)
        {
            return !(right == left);
        }

        // Override Equals and GetHashCode to ensure consistency with the overloaded operators
        public override bool Equals(object obj)
        {
            if (obj is _3D_Point other)
                return this == other; // يستخدم معامل == 
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y, Z);
        }

        #endregion

    }
}
