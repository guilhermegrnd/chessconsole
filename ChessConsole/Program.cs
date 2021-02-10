using System;
using board;
using chess;

namespace ChessConsole {
    class Program {
        static void Main(string[] args) {
            try {
                Board b = new Board(8, 8);

                b.placePiece(new Rook(b, Color.White), new Position(0, 0));
                b.placePiece(new King(b, Color.White), new Position(1, 3));
                b.placePiece(new Rook(b, Color.Black), new Position(4, 6));
                b.placePiece(new King(b, Color.Black), new Position(7, 4));

                Display.printBoard(b);

                Console.ReadLine();
            } catch(BoardException e) {
                Console.WriteLine(e.Message);
            }
        }
    }
}
