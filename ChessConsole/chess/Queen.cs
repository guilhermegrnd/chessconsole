using board;

namespace chess {
    class Queen : Piece {
        public Queen(Board board, Color color) : base(board, color) {
        }

        public override string ToString() {
            return "Q";
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
            //NORTH
            pos.changePosition(position.row - 1, position.column);
            while (board.validPosition(pos) && validateMove(pos)) {
                boolMatrix[pos.row, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color) {
                    break;
                }
                pos.changePosition(pos.row - 1, pos.column);
            }
            //EAST
            pos.changePosition(position.row, position.column + 1);
            while (board.validPosition(pos) && validateMove(pos)) {
                boolMatrix[pos.row, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color) {
                    break;
                }
                pos.changePosition(pos.row, pos.column + 1);
            }
            //SOUTH
            pos.changePosition(position.row + 1, position.column);
            while (board.validPosition(pos) && validateMove(pos)) {
                boolMatrix[pos.row, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color) {
                    break;
                }
                pos.changePosition(pos.row + 1, pos.column);
            }
            //WEST
            pos.changePosition(position.row, position.column - 1);
            while (board.validPosition(pos) && validateMove(pos)) {
                boolMatrix[pos.row, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color) {
                    break;
                }
                pos.changePosition(pos.row, pos.column - 1);
            }

            return boolMatrix;
        }
    }
}
