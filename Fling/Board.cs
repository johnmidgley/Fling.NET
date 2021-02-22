using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fling
{
	class Board : IState
	{
		Int32 xLength;
		Int32 yLength;

		List<Piece> pieces = new List<Piece>();
		public IEnumerable<Piece> Pieces
		{
			get { return pieces; }
		}

        public Boolean InGoalState
        {
            get
            {
                return pieces.Where(p => ValidPosition(p.Position)).Count() == 1;
            }
        }


        public IEnumerable<Piece> ActivePieces
        {
            get
            {
                return pieces.Where(p => ValidPosition(p.Position));
            }
        }

		public Board(Int32 xLength, Int32 yLength)
		{
			this.xLength = xLength;
			this.yLength = yLength;
		}

        public Board(List<String> board)
        {
            this.xLength = board.Max(l => l.Length);
            this.yLength = board.Count;

            for(Int32 y = 0; y < yLength; y++)
            {
                String row = board[yLength - y - 1];

                for (Int32 x = 0; x < row.Length; x++)
                {
                    if (row[x] != '-')
                    {
                        AddPiece(x, y);
                    }
                }
            }
        }

		public void AddPiece(Int32 x, Int32 y)
		{
			if (!ValidPosition(x, y))
			{
				throw new ArgumentException("Invalid position.");
			}

			Piece piece = new Piece(x, y);
			pieces.Add(piece);
		}

        Boolean ValidPosition(Int32 x, Int32 y)
        {
            return x >= 0 && x < xLength && y >= 0 && y < yLength;
        }

        Boolean ValidPosition(Coordinate position)
        {
            return ValidPosition(position.X, position.Y);
        }

        public Piece GetPiece(Coordinate position)
        {
            Piece piece = null;

            if (ValidPosition(position.X, position.Y))
            {
                piece = pieces.Where(p => p.Position.X == position.X && p.Position.Y == position.Y).FirstOrDefault();
            }

            return piece;
        }

        public Piece SearchForPiece(Coordinate startCoordinate, Coordinate increment)
        {
            Coordinate current = startCoordinate;
            Piece piece = null;

            while (ValidPosition(current))
            {
                piece = GetPiece(current);

                if (piece != null)
                {
                    break;
                }

                current.Add(increment);
            }

            return piece;
        }

        public void Print()
        {
            Print(null);
        }

        public void Print(Move move)
        {
            for (int y = yLength - 1; y >= 0; y--)
            {
                for (int x = 0; x < xLength; x++)
                {
                    Coordinate position = new Coordinate(x, y);
                    Piece piece = GetPiece(position);

                    if (move != null && x== move.OriginalPosition.X && y == move.OriginalPosition.Y)
                    {
                        Console.Write(move.Direction.ToString()[0]);
                    }
                    else
                    {
                        Console.Write(piece == null ? "-" : "*");
                    }
                }

                Console.WriteLine();
            }
        }

        #region IState Members


        public IEnumerable<IStateTransition> GetSuccessorTransitions()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
