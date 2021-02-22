using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fling
{
    enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }

	class PathFinder
	{
		Board state;

		public PathFinder(Board state)
		{
			this.state = state;
		}

        public Stack<Move> FindSolution()
        {
            Stack<Move> path = new Stack<Move>();
            FindSolution(path);

            if (path.Count == 0)
            {
                path = null;
            }

            return path;
        }

        // Can this be generalized? Each piece could have a GetMovesToTry method.
		private Boolean FindSolution(Stack<Move> path)
		{
            if (state.InGoalState)
            {
                return true;
            }

			foreach (Piece piece in state.ActivePieces.ToList())
			{
                foreach (Direction direction in Enum.GetValues(typeof(Direction)))
                {
                    List<Move> moves = Fling(piece, direction);

                    if (moves != null && moves.TrueForAll(s => s.Apply()))
                    {
                        Boolean foundSolution = FindSolution(path);
                        moves.TrueForAll(s => s.Reverse());

                        if (foundSolution)
                        {
                            foreach (Move move in moves.Reverse<Move>())
                            {
                                path.Push(move);
                            }

                            return true;
                        }
                    }
                }
			}

			return false;
		}

        void AddMove(ref List<Move> moves, Move move)
        {
            if (moves == null)
            {
                moves = new List<Move>();
            }

            moves.Add(move);
        }

        List<Move> Fling(Piece piece, Direction direction)
        {
            List<Move> moves = null;
            Coordinate position = piece.Position;
            Coordinate increment = new Coordinate(0, 0);

            switch (direction)
            {
                case Direction.Up:
                    increment = new Coordinate(0, 1);
                    break;
                case Direction.Down:
                    increment = new Coordinate(0, -1);
                    break;
                case Direction.Left:
                    increment = new Coordinate(-1, 0);
                    break;
                case Direction.Right:
                    increment = new Coordinate(1, 0);
                    break;
            }

            position.Add(increment);

            // Find piece above
            if (state.GetPiece(position) == null)
            {
                // No piece adjacent in fling direction, so ok
                Piece currentPiece = piece;
                Piece nextPiece = null;
                position.Add(increment);

                while ((nextPiece = state.SearchForPiece(position, increment)) != null)
                {
                    Coordinate moveToPosition = nextPiece.Position;
                    moveToPosition.Subtract(increment);
                    Move move = new Move(currentPiece, direction, moveToPosition);
                    AddMove(ref moves, move);
                    currentPiece = nextPiece;
                    position = nextPiece.Position;
                    position.Add(increment);
                }

                // Last pice that was hit needs to be removed
                if (moves != null)
                {
                    Coordinate offBoard = new Coordinate(-1, -1);
                    Move move = new Move(currentPiece, direction, offBoard);
                    moves.Add(move);
                }
            }

            return moves;
        }
	}
}
