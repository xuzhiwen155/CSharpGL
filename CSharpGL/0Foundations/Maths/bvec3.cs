using System;
using System.ComponentModel;

namespace CSharpGL
{
    /// <summary>
    /// Represents a three dimensional vector.
    /// </summary>
    [TypeConverter(typeof(StructTypeConverter<bvec3>))]
    public struct bvec3 : IEquatable<bvec3>, ILoadFromString
    {
        /// <summary>
        /// Don't change the order of x, y, z appears!
        /// </summary>
        public bool x;

        /// <summary>
        /// Don't change the order of x, y, z appears!
        /// </summary>
        public bool y;

        /// <summary>
        /// Don't change the order of x, y, z appears!
        /// </summary>
        public bool z;

        /// <summary>
        ///
        /// </summary>
        /// <param name="s"></param>
        public bvec3(bool s)
        {
            x = y = z = s;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public bvec3(bool x, bool y, bool z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="v"></param>
        public bvec3(bvec3 v)
        {
            this.x = v.x;
            this.y = v.y;
            this.z = v.z;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="v"></param>
        public bvec3(bvec4 v)
        {
            this.x = v.x;
            this.y = v.y;
            this.z = v.z;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="xy"></param>
        /// <param name="z"></param>
        public bvec3(bvec2 xy, bool z)
        {
            this.x = xy.x;
            this.y = xy.y;
            this.z = z;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public bool this[int index]
        {
            get
            {
                if (index == 0) return x;
                else if (index == 1) return y;
                else if (index == 2) return z;
                else throw new Exception("Out of range.");
            }
            set
            {
                if (index == 0) x = value;
                else if (index == 1) y = value;
                else if (index == 2) z = value;
                else throw new Exception("Out of range.");
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static bool operator !=(bvec3 lhs, bvec3 rhs)
        {
            return (lhs.x != rhs.x || lhs.y != rhs.y || lhs.z != rhs.z);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static bool operator ==(bvec3 lhs, bvec3 rhs)
        {
            return (lhs.x == rhs.x && lhs.y == rhs.y && lhs.z == rhs.z);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return (obj is bvec3) && (this.Equals((bvec3)obj));
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(bvec3 other)
        {
            return (this.x == other.x && this.y == other.y && this.z == other.z);
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return string.Format("{0}#{1}#{2}", x, y, z).GetHashCode();
        }

        void ILoadFromString.Load(string value)
        {
            string[] parts = value.Split(VectorHelper.separator, StringSplitOptions.RemoveEmptyEntries);
            this.x = bool.Parse(parts[0]);
            this.y = bool.Parse(parts[1]);
            this.z = bool.Parse(parts[2]);
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public bool[] ToArray()
        {
            return new[] { x, y, z };
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0}, {1}, {2}", x, y, z);
        }
    }
}