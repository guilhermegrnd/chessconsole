using System;
using System.Collections.Generic;
using System.Text;

namespace board {
    abstract class Piece {
        public Position position { get; set; }
        public Color color { get; protected set; }
        public int movesMade { get; protected set; }
        public Board board { get; protected set; }

        public Piece(Board board, Color color) {
            position = null;
            this.board = board;
            this.color = color;
            movesMade = 0;
        }

        public void incrementMovesMade() {
            movesMade++;
        }

        public abstract bool[,] possibleMoves();
    }
}
