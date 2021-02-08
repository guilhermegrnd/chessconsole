using System;
using board;
using chess;

namespace ChessConsole {
    class Program {
        static void Main(string[] args) {

            Board b = new Board(8, 8);

            b.placePiece(new Rook(b, Color.Black), new Position(0, 0));
            b.placePiece(new Rook(b, Color.Black), new Position(1, 3));
            b.placePiece(new King(b, Color.Black), new Position(2, 4));

            Display.printBoard(b);

            Console.ReadLine();
        }
    }
}
