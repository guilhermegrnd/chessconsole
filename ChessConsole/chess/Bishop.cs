using board;

namespace chess {
    class Bishop : Piece {
        public Bishop(Board board, Color color) : base(board, color) {
        }

        public override string ToString() {
            return "b";
        }

        private bool validateMove(Position pos) {
            Piece p = board.piece(pos);
            return p == null || p.color != color;
        }

        public override bool[,] possibleMoves() {
            bool[,] boolMatrix = new bool[board.rows, board.columns];

            Position pos = new Position(0, 0);

            //NORTHEAST
            pos.changePosition(position.row - 1, position.column + 1);
            while (board.validPosition(pos) && validateMove(pos)) {
                boolMatrix[pos.row, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color) {
                    break;
                }
                pos.changePosition(pos.row - 1, pos.column + 1);
            }
            //SOUTHEAST
            pos.changePosition(position.row + 1, position.column + 1);
            while (board.validPosition(pos) && validateMove(pos)) {
                boolMatrix[pos.row, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color) {
                    break;
                }
                pos.changePosition(pos.row + 1, pos.column + 1);
            }
            //SOUTHWEST
            pos.changePosition(position.row + 1, position.column - 1);
            while (board.validPosition(pos) && validateMove(pos)) {
                boolMatrix[pos.row, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color) {
                    break;
                }
                pos.changePosition(pos.row + 1, pos.column - 1);
            }
            //NORTHWEST
            pos.changePosition(position.row - 1, position.column - 1);
            while (board.validPosition(pos) && validateMove(pos)) {
                boolMatrix[pos.row, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color) {
                    break;
                }
                pos.changePosition(pos.row - 1, pos.column - 1);
            }

            return boolMatrix;
        }
    }
}
