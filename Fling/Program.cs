using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fling
{
	class Program
	{
		static void Main(string[] args)
		{

            List<String> state = new List<String>
            {
                "-------",
                "-------",
                "-------",
                "-------",
                "-------",
                "-------",
                "-------",
                "-------"
            };

            state = new List<String>
            {
                "/---/--",
                "------/",
                "-------",
                "----/--",
                "-----/-",
                "--/--/-",
                "----//-",
                "----/--"
            };

            Board board = new Board(state);
            PathFinder game = new PathFinder(board);
            Stack<Move> path = game.FindSolution();

            if (path != null)
            {
                // board.Print();

                foreach (Move move in path)
                {
                    //Console.WriteLine("{0},{1} -> {2},{3}", move.OriginalPosition.X, move.OriginalPosition.Y,
                    //    move.NewPosition.X, move.NewPosition.Y);

                    if (move.NewPosition.X != -1 && move.NewPosition != move.OriginalPosition                        )
                    {
                        board.Print(move);
                        Console.ReadLine();
                    }

                    move.Apply();
                }
            }
		}
	}
}
