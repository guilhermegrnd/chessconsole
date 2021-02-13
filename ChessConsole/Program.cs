using System;
using board;
using chess;

namespace ChessConsole {
    class Program {
        static void Main(string[] args) {
            try {
                ChessMatch match = new ChessMatch();

                while(!match.gameOver) {
                    Console.Clear();
                    Display.printBoard(match.board);

                    Console.WriteLine();

                    Console.Write("Origem: ");
                    Position origin = Display.getChessPosition().toPosition();

                    bool[,] possibleMoves = match.board.piece(origin).possibleMoves();

                    Console.Clear();
                    Display.printBoard(match.board, possibleMoves);

                    Console.WriteLine();
                    Console.Write("Destino: ");
                    Position destination = Display.getChessPosition().toPosition();

                    match.executeMove(origin, destination);
                }

            } catch(BoardException e) {
                Console.WriteLine(e.Message);
            }
        }
    }
}
