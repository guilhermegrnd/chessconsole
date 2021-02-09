﻿using board;

namespace chess {
    class chessPosition {
        public char column { get; set; }
        public int row { get; set; }

        public chessPosition(char column, int row) {
            this.column = column;
            this.row = row;
        }

        public Position toPosition() {
            return new Position(8 - row, column - 'A');
        }

        public override string ToString() {
            return "" + column + row;
        }
    }
}