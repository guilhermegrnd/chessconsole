using System;
using board;
using chess;

namespace ChessConsole {
    class Program {
        static void Main(string[] args) {
            try {
                chessPosition pos = new chessPosition('H', 3);

                Console.WriteLine(pos);

                Console.WriteLine(pos.toPosition());

                Console.ReadLine();
            } catch(BoardException e) {
                Console.WriteLine(e.Message);
            }
        }
    }
}
