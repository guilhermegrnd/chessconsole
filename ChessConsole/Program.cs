using System;
using board;
using chess;

namespace ChessConsole {
    class Program {
        static void Main(string[] args) {
            try {
                ChessMatch match = new ChessMatch();

                while(!match.gameOver) {
                    try {
                        Console.Clear();
                        Display.printMatch(match);
                        Console.WriteLine();

                        Console.Write("Origem: ");
                        Position origin = Display.getChessPosition().toPosition();
                        match.validOriginPosition(origin);

                        bool[,] possibleMoves = match.board.piece(origin).possibleMoves();

                        Console.Clear();
                        Display.printBoard(match.board, possibleMoves);

                        Console.WriteLine();
                        Console.Write("Destino: ");
                        Position destination = Display.getChessPosition().toPosition();
                        match.validDestinationPosition(origin, destination);

                        match.executePlay(origin, destination);
                    }
                    catch (BoardException e) {
                        Console.WriteLine(e.Message);
                    }
                }

            } catch(BoardException e) {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
        }
    }
}
