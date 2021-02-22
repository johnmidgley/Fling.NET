using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fling
{
    class Move : IStateTransition
    {
        Piece piece;
        internal Piece Piece
        {
            get { return piece; }
        }

        readonly Coordinate originalPosition;
        public Coordinate OriginalPosition
        {
            get { return originalPosition; }
        } 

        readonly Coordinate newPosition;
        internal Coordinate NewPosition
        {
            get { return newPosition; }
        }

        Direction direction;
        internal Direction Direction
        {
            get { return direction; }
        }

        public Move(Piece piece, Direction direction, Coordinate newPosition)
        {
            this.piece = piece;
            this.direction = direction;
            this.originalPosition = piece.Position;
            this.newPosition = newPosition;
        }

        public Boolean Apply()
        {
            piece.Position = newPosition;

            return true;
        }

        public Boolean Reverse()
        {
            piece.Position = originalPosition;

            return true;
        }
    }
}
