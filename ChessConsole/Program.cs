using System;
using board;

namespace ChessConsole {
    class Program {
        static void Main(string[] args) {

            Board b = new Board(8, 8);

            Console.WriteLine(b);

            Console.ReadLine();
        }
    }
}
