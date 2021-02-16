using board;

namespace chess {
    class Pawn : Piece {
        public Pawn(Board board, Color color) : base(board, color) {
        }

        public override string ToString() {
            return "p";
        }

        private bool enemyAhead(Position pos) {
            Piece p = board.piece(pos);
            return p != null && p.color != color;
        }

        private bool clearSquare(Position pos) {
            return board.piece(pos) == null;
        }

        public override bool[,] possibleMoves() {
            bool[,] boolMatrix = new bool[board.rows, board.columns];

            Position pos = new Position(0, 0);

            if(color == Color.White) {
                pos.changePosition(position.row - 1, position.column);
                if (board.validPosition(pos) && clearSquare(pos)) {
                    boolMatrix[pos.row, pos.column] = true;
                }
                pos.changePosition(position.row - 2, position.column);
                if (board.validPosition(pos) && clearSquare(pos) && movesMade == 0) {
                    boolMatrix[pos.row, pos.column] = true;
                }
                pos.changePosition(position.row - 1, position.column - 1);
                if (board.validPosition(pos) && enemyAhead(pos)) {
                    boolMatrix[pos.row, pos.column] = true;
                }
                pos.changePosition(position.row - 1, position.column + 1);
                if (board.validPosition(pos) && enemyAhead(pos)) {
                    boolMatrix[pos.row, pos.column] = true;
                }
            } else {
                pos.changePosition(position.row + 1, position.column);
                if (board.validPosition(pos) && clearSquare(pos)) {
                    boolMatrix[pos.row, pos.column] = true;
                }
                pos.changePosition(position.row + 2, position.column);
                if (board.validPosition(pos) && clearSquare(pos) && movesMade == 0) {
                    boolMatrix[pos.row, pos.column] = true;
                }
                pos.changePosition(position.row + 1, position.column - 1);
                if (board.validPosition(pos) && enemyAhead(pos)) {
                    boolMatrix[pos.row, pos.column] = true;
                }
                pos.changePosition(position.row + 1, position.column + 1);
                if (board.validPosition(pos) && enemyAhead(pos)) {
                    boolMatrix[pos.row, pos.column] = true;
                }
            }
            
            return boolMatrix;
        }
    }
}
