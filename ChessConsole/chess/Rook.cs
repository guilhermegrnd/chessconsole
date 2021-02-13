using board;

namespace chess {
    class Rook : Piece {
        public Rook(Board board, Color color) : base(board, color) {
        }

        public override string ToString() {
            return "R";
        }

        private bool validateMove(Position pos) {
            Piece p = board.piece(pos);
            return p == null || p.color != color;
        }

        public override bool[,] possibleMoves() {
            bool[,] boolMatrix = new bool[board.rows, board.columns];

            Position pos = new Position(0, 0);

            //NORTH
            pos.changePosition(position.row - 1, position.column);
            while (board.validPosition(pos) && validateMove(pos)) {
                if (board.piece(pos) != null && board.piece(pos).color != color) {
                    break;
                }
                boolMatrix[pos.row, pos.column] = true;
                pos.row--;
            }
            //EAST
            pos.changePosition(position.row, position.column + 1);
            while (board.validPosition(pos) && validateMove(pos)) {
                if (board.piece(pos) != null && board.piece(pos).color != color) {
                    break;
                }
                boolMatrix[pos.row, pos.column] = true;
                pos.column++;
            }
            //SOUTH
            pos.changePosition(position.row + 1, position.column);
            while (board.validPosition(pos) && validateMove(pos)) {
                if (board.piece(pos) != null && board.piece(pos).color != color) {
                    break;
                }
                boolMatrix[pos.row, pos.column] = true;
                pos.row++;
            }
            //WEST
            pos.changePosition(position.row, position.column - 1);
            while (board.validPosition(pos) && validateMove(pos)) {
                if (board.piece(pos) != null && board.piece(pos).color != color) {
                    break;
                }
                boolMatrix[pos.row, pos.column] = true;
                pos.column--;
            }


            return boolMatrix;
        }
    }
}
