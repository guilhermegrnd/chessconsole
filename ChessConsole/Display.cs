using System;
using board;
using chess;

namespace ChessConsole {
    class Display {
        public static void printBoard(Board board) {
            for (int i = 0; i < board.rows; i++) {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.columns; j++) {
                    printPiece(board.piece(i, j));
                }
                Console.WriteLine("");
            }
            Console.WriteLine("  A B C D E F G H");
        }

        public static void printBoard(Board board, bool[,] possiblePositions) {
            ConsoleColor originalBackgroundColor = Console.BackgroundColor;
            ConsoleColor highlightedBackgroundColor = ConsoleColor.DarkGray;
            for (int i = 0; i < board.rows; i++) {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.columns; j++) {
                    if(possiblePositions[i,j]) {
                        Console.BackgroundColor = highlightedBackgroundColor;
                    } else {
                        Console.BackgroundColor = originalBackgroundColor;
                    }
                    printPiece(board.piece(i, j));
                    Console.BackgroundColor = originalBackgroundColor;
                }
                Console.WriteLine("");
            }
            Console.WriteLine("  A B C D E F G H");
        }

        public static ChessPosition getChessPosition() {
            string s = Console.ReadLine();
            char column = s[0];
            int row = int.Parse(s[1] + "");
            return new ChessPosition(column, row);
        }

        public static void printPiece(Piece piece) {
            if(piece == null) {
                Console.Write("- ");
            } else {
                if (piece.color == Color.White) {
                    Console.Write(piece);
                }
                else {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(piece);
                    Console.ForegroundColor = aux;
                }
                Console.Write(" ");
            }            
        }
    }
}
