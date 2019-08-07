﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiwotLib.Math
{
    public class Int2: IComparable
    {
        protected int x, y;
        public int X
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
            }
        }
        public int Y
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
            }
        }

        #region Static values
        public static Int2 Zero { get; } = new Int2(0, 0);
        public static Int2 One { get; } = new Int2(1, 1);
        public static Int2 Up { get; } = new Int2(0, 1);
        public static Int2 Right { get; } = new Int2(1, 0);
        public static Int2 Down { get; } = new Int2(0, -1);
        public static Int2 Left { get; } = new Int2(-1, 0);
        #endregion

        #region Constructors
        public Int2()
        {
            x = 0;
            y = 0;
        }

        public Int2(int xy)
        {
            x = xy;
            y = xy;
        }
        public Int2(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public Int2(Int2 i2)
        {
            x = i2.x;
            y = i2.y;
        }
        #endregion

        #region Manipulators
        ///<summary>Swaps values of x and y in this instance of the object.
        ///</summary>
        public void Flip()
        {
            int t = x;
            x = y;
            y = t;
        }

        ///<summary>Returns a new instance of Int2 with swapped x and y values.
        ///</summary>
        ///<param name="i">The instance of Int2 class to flip.</param>
        public static Int2 Flip(Int2 i)
        {
            return i.Flipped();
        }

        ///<summary>Returns a new instance of Int2 with swapped x and y values.
        ///</summary>
        public Int2 Flipped()
        {
            return new Int2(y, x);
        }

        ///<summary>Returns a new instance of Int2 with values of x and y clamped between 0 and inclusiveMax.
        ///</summary>
        ///<param name="i">The instance of Int2 class to be clamped.</param>
        ///<param name="inclusiveMax">The inclusive upper bound of the clamping range.</param>
        public static Int2 Clamp(Int2 i, int inclusiveMax)
        {
            return new Int2(Arit.Clamp(i.x, inclusiveMax), Arit.Clamp(i.y, inclusiveMax));
        }

        ///<summary>Returns a new instance of Int2 with values of x and y clamped between inclusiveMin and inclusiveMax.
        ///</summary>
        ///<param name="i">The instance of Int2 class to be clamped.</param>
        ///<param name="inclusiveMin">The inclusive lower bound of the clamping range.</param>
        ///<param name="inclusiveMax">The inclusive upper bound of the clamping range.</param>
        public static Int2 Clamp(Int2 i, int inclusiveMin, int inclusiveMax)
        {
            return new Int2(Arit.Clamp(i.x, inclusiveMin, inclusiveMax), Arit.Clamp(i.y, inclusiveMin, inclusiveMax));
        }

        ///<summary>Returns a new instance of Int2 with values of x and y clamped between 0 and respective inclusiveMax values.
        ///</summary>
        ///<param name="i">The instance of Int2 class to be clamped.</param>
        ///<param name="inclusiveMax">The respective inclusive upper bounds of the clamping range.</param>
        public static Int2 Clamp(Int2 i, Int2 inclusiveMax)
        {
            return new Int2(Arit.Clamp(i.x, inclusiveMax.x), Arit.Clamp(i.y, inclusiveMax.y));
        }

        ///<summary>Returns a new instance of Int2 with values of x and y clamped between respective inclusiveMin and inclusiveMax values.
        ///</summary>
        ///<param name="i">The instance of Int2 class to be clamped.</param>
        ///<param name="inclusiveMin">The respective inclusive lower bounds of the clamping range.</param>
        ///<param name="inclusiveMax">The respective inclusive upper bounds of the clamping range.</param>
        public static Int2 Clamp(Int2 i, Int2 inclusiveMin, Int2 inclusiveMax)
        {
            return new Int2(Arit.Clamp(i.x, inclusiveMin.x, inclusiveMax.x), Arit.Clamp(i.y, inclusiveMin.y, inclusiveMax.y));
        }

        ///<summary>Clamps this instance x and y values between 0 and inclusiveMax.
        ///</summary>
        ///<param name="inclusiveMax">The inclusive upper bound of the clamping range.</param>
        public void ClampThis(int inclusiveMax)
        {
            Arit.Clamp(x, inclusiveMax);
            Arit.Clamp(y, inclusiveMax);
        }

        ///<summary>Clamps this instance x and y values between inclusiveMin and inclusiveMax.
        ///</summary>
        ///<param name="inclusiveMin">The inclusive lower bound of the clamping range.</param>
        ///<param name="inclusiveMax">The inclusive upper bound of the clamping range.</param>
        public void ClampThis(int inclusiveMin, int inclusiveMax)
        {
            Arit.Clamp(x, inclusiveMin, inclusiveMax);
            Arit.Clamp(y, inclusiveMin, inclusiveMax);
        }

        ///<summary>Clamps this instance x and y values between 0 and respective inclusiveMax values.
        ///</summary>
        ///<param name="inclusiveMax">The respective inclusive upper bounds of the clamping range.</param>
        public void ClampThis(Int2 inclusiveMax)
        {
            Arit.Clamp(x, inclusiveMax.x);
            Arit.Clamp(y, inclusiveMax.y);
        }

        ///<summary>Clamps this instance x and y values between respective inclusiveMin and inclusiveMax values.
        ///</summary>
        ///<param name="inclusiveMin">The respective inclusive lower bounds of the clamping range.</param>
        ///<param name="inclusiveMax">The respective inclusive upper bounds of the clamping range.</param>
        public void ClampThis(Int2 inclusiveMin, Int2 inclusiveMax)
        {
            Arit.Clamp(x, inclusiveMin.x, inclusiveMax.x);
            Arit.Clamp(y, inclusiveMin.y, inclusiveMax.y);
        }
        #endregion

        #region Random
        ///<summary>Returns new instance of Int2 with random values of x and y.
        ///</summary>
        public static Int2 Random()
        {
            return new Int2(Rand.Int(), Rand.Int());
        }

        ///<summary> Returns new instance of Int2 with random values of x and y.
        ///<para>Both x and y will be winthin range from 0 to exclusiveMax.</para>
        ///</summary>
        ///<param name="exclusiveMax">The upper bound of the range(exclusive)</param>
        public static Int2 Random(int exclusiveMax)
        {
            return new Int2(Rand.Int(exclusiveMax), Rand.Int(exclusiveMax));
        }

        ///<summary> Returns new instance of Int2 with random values of x and y.
        ///<para>Both x and y will be winthin range from 0 to respective exclusiveMax.</para>
        ///</summary>
        ///<param name="exclusiveMax">The upper respective bounds of the range(exclusive)</param>
        public static Int2 Random(Int2 exclusiveMax)
        {
            return new Int2(Rand.Int(exclusiveMax.x), Rand.Int(exclusiveMax.y));
        }

        ///<summary> Returns new instance of Int2 with random values of x and y.
        ///<para>Both x and y will be winthin range from inclusiveMin to exclusiveMax.</para>
        ///</summary>
        ///<param name="inclusiveMin">The lower bound of the range(inclusive)</param>
        ///<param name="exclusiveMax">The upper bound of the range(exclusive)</param>
        public static Int2 Random(int inclusiveMin, int exclusiveMax)
        {
            return new Int2(Rand.Int(inclusiveMin, exclusiveMax), Rand.Int(inclusiveMin, exclusiveMax));
        }

        ///<summary> Returns new instance of Int2 with random values of x and y.
        ///<para>Both x and y will be winthin range from respective inclusiveMin to respective exclusiveMax.</para>
        ///</summary>
        ///<param name="inclusiveMin">The lower respective bounds of the range(inclusive)</param>
        ///<param name="exclusiveMax">The upper respective bounds of the range(exclusive)</param>
        public static Int2 Random(Int2 inclusiveMin, Int2 exclusiveMax)
        {
            return new Int2(Rand.Int(inclusiveMin.x, exclusiveMax.y), Rand.Int(inclusiveMin.y, exclusiveMax.y));
        }
        #endregion

        #region Box checks

        ///<summary>
        ///Checks if a given point is inside a given box (inclusve version).
        ///</summary>
        ///<param name="boxSize">The size of a box.</param>
        ///<param name="point">The point to be checked.</param>
        public static bool InBox(Int2 boxSize, Int2 point)
        {
            return point <= boxSize && point >= Zero;
        }

        ///<summary>
        ///Checks if a given point is inside a given box (exclusive version).
        ///</summary>
        ///<param name="boxSize">The size of a box.</param>
        ///<param name="point">The point to be checked.</param>
        public static bool InBoxEx(Int2 boxSize, Int2 point)
        {
            return point < boxSize && point > Zero;
        }

        ///<summary>
        ///Checks if a given point is inside a given box lying at specified position (inclusve version).
        ///</summary>
        ///<param name="boxSize">The size of a box.</param>
        ///<param name="boxPosition">The position of a box.</param>
        ///<param name="point">The point to be checked.</param>
        public static bool InBox(Int2 boxSize, Int2 boxPosition, Int2 point)
        {
            return InBox(boxSize, point - boxPosition);
        }

        ///<summary>
        ///Checks if a given point is inside a given box lying at specified position (exclusive version).
        ///</summary>
        ///<param name="boxSize">The size of a box.</param>
        ///<param name="boxPosition">The position of a box.</param>
        ///<param name="point">The point to be checked.</param>
        public static bool InBoxEx(Int2 boxSize, Int2 boxPosition, Int2 point)
        {
            return InBoxEx(boxSize, point - boxPosition);
        }

        ///<summary>
        ///Checks if a given box is inside another given box(inclusve version).
        ///</summary>
        ///<param name="outsideBoxSize">The size of the outside box.</param>
        ///<param name="outsideBoxPosition">The position of the outside box.</param>
        ///<param name="insideBoxSize">The size of the inside box.</param>
        ///<param name="insideBoxPosition">The position of the inside box.</param>
        public static bool InBox(Int2 outsideBoxSize, Int2 outsideBoxPosition, Int2 insideBoxSize, Int2 insideBoxPosition)
        {
            return insideBoxPosition + insideBoxSize <= outsideBoxPosition + outsideBoxSize && insideBoxPosition >= outsideBoxPosition;
        }

        ///<summary>
        ///Checks if a given box is inside another given box(exclusive version).
        ///</summary>
        ///<param name="outsideBoxSize">The size of the outside box.</param>
        ///<param name="outsideBoxPosition">The position of the outside box.</param>
        ///<param name="insideBoxSize">The size of the inside box.</param>
        ///<param name="insideBoxPosition">The position of the inside box.</param>
        public static bool InBoxEx(Int2 outsideBoxSize, Int2 outsideBoxPosition, Int2 insideBoxSize, Int2 insideBoxPosition)
        {
            return insideBoxPosition + insideBoxSize < outsideBoxPosition + outsideBoxSize && insideBoxPosition > outsideBoxPosition;
        }
        #endregion

        #region Operators
        public static Int2 operator +(Int2 i1, Int2 i2) { return new Int2(i1.x + i2.x, i1.y + i2.y); }
        public static Int2 operator +(Int2 i1, int x) { return new Int2(i1.x + x, i1.y + x); }

        public static Int2 operator -(Int2 i1, Int2 i2) { return new Int2(i1.x - i2.x, i1.y - i2.y); }
        public static Int2 operator -(Int2 i1, int x) { return new Int2(i1.x - x, i1.y - x); }

        public static Int2 operator *(Int2 i1, Int2 i2) { return new Int2(i1.x * i2.x, i1.y * i2.y); }
        public static Int2 operator *(Int2 i1, int x) { return new Int2(i1.x * x, i1.y * x); }

        public static Int2 operator /(Int2 i1, Int2 i2) { return new Int2(i1.x / i2.x, i1.y / i2.y); }
        public static Int2 operator /(Int2 i1, int x) { return new Int2(i1.x / x, i1.y / x); }

        public static bool operator ==(Int2 i1, Int2 i2)
        {
            if ((object)i2 == null) return (object)i1 == null; if ((object)i1 == null) return (object)i2 == null;
            if (i1.x == i2.x && i1.y == i2.y) return true; return false;
        }
        public static bool operator !=(Int2 i1, Int2 i2)
        {
            if ((object)i2 == null) return (object)i1 != null; if ((object)i1 == null) return (object)i2 != null;
            if (i1.x == i2.x && i1.y == i2.y) return false; return true;
        }
        public static bool operator >=(Int2 i1, Int2 i2)
        {
            if (i1 == null) throw new ArgumentNullException("i1");
            if (i2 == null) throw new ArgumentNullException("i2");
            if (i1.x >= i2.x && i1.y >= i2.y) return true; return false;
        }
        public static bool operator <=(Int2 i1, Int2 i2)
        {
            if (i1 == null) throw new ArgumentNullException("i1");
            if (i2 == null) throw new ArgumentNullException("i2");
            if (i1.x <= i2.x && i1.y <= i2.y) return true; return false;
        }
        public static bool operator >(Int2 i1, Int2 i2)
        {
            if (i1 == null) throw new ArgumentNullException("i1");
            if (i2 == null) throw new ArgumentNullException("i2");
            if (i1.x > i2.x && i1.y > i2.y) return true; return false;
        }
        public static bool operator <(Int2 i1, Int2 i2)
        {
            if (i1 == null) throw new ArgumentNullException("i1");
            if (i2 == null) throw new ArgumentNullException("i2");
            if (i1.x < i2.x && i1.y < i2.y) return true; return false;
        }


        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (this.GetType() != obj.GetType()) return false;
            Int2 p = (Int2)obj;
            return this == p;
        }
        #endregion

        public override int GetHashCode()
        {
            unchecked
            {
                var result = 0;
                result = (result * 397) ^ x;
                result = (result * 397) ^ y;
                return result;
            }
        }
        override public string ToString()
        {
            return x + ", " + y;
        }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;
            Int2 other = obj as Int2;
            if (other != null)
            {
                if(this == other)
                    return 0;
                return this > other ? 1 : -1;
            }
            else
                throw new ArgumentException("Object is not an Int2");
        }
    }
}