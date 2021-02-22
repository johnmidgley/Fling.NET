using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fling
{
	class Piece
	{
		Coordinate position;
		internal Coordinate Position
		{
			get { return position; }
            set { position = value; }
		}

		public Piece(Int32 x, Int32 y)
		{
			position = new Coordinate(x, y);
		}

        public override string ToString()
        {
            return position.ToString();
        }
	}
}
