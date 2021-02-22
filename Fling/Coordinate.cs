using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fling
{
	struct Coordinate
	{
		Int32 x;
		public Int32 X
		{
			get { return x; }
		}

		Int32 y;
		public Int32 Y
		{
			get { return y; }
		}

		public Coordinate(Int32 x, Int32 y)
		{
            this.x = x;
            this.y = y;
		}

		public void Set(Int32 x, Int32 y)
		{
			this.x = x;
			this.y = y;
		}

        public void Add(Int32 x, Int32 y)
        {
            this.x += x;
            this.y += y;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            Coordinate other = (Coordinate)obj;
            Boolean equal = other.x == x && other.y == y;

            return equal;           
        }

        public static Boolean operator ==(Coordinate c1, Coordinate c2)
        {
            return c1.Equals(c2);
        }
        public static Boolean operator !=(Coordinate c1, Coordinate c2)
        {
            return !(c1 == c2);
        }

        public void Add(Coordinate other)
        {
            Add(other.X, other.Y);
        }

        public void Subtract(Coordinate other)
        {
            Add(-other.X, -other.Y);
        }

        public override string ToString()
        {
            return String.Format("{{0},{1}}", x, y);
        }




	}


	
}
