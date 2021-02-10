using System;
using board;

namespace ChessConsole {
    class Display {
        public static void printBoard(Board board) {
            for (int i = 0; i < board.rows; i++) {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.columns; j++) {
                    if(board.piece(i,j) == null) {
                        Console.Write("- ");
                    } else {
                        printPiece(board.piece(i, j));
                        Console.Write(" ");
                    }
                }
                Console.WriteLine("");
            }
            Console.WriteLine("  A B C D E F G H");
        }

        public static void printPiece(Piece piece) {
            if(piece.color == Color.White) {
                Console.Write(piece);
            } else {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(piece);
                Console.ForegroundColor = aux;
            }
        }
    }
}
