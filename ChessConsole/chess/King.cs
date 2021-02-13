using board;

namespace chess {
    class King : Piece {
        public King(Board board, Color color) : base(board, color) {
        }

        public override string ToString() {
            return "K";
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
            if (board.validPosition(pos) && validateMove(pos)) {
                boolMatrix[pos.row, pos.column] = true;
            }
            //NORTHEAST
            pos.changePosition(position.row - 1, position.column + 1);
            if (board.validPosition(pos) && validateMove(pos)) {
                boolMatrix[pos.row, pos.column] = true;
            }
            //EAST
            pos.changePosition(position.row, position.column + 1);
            if (board.validPosition(pos) && validateMove(pos)) {
                boolMatrix[pos.row, pos.column] = true;
            }
            //SOUTHEAST
            pos.changePosition(position.row + 1, position.column + 1);
            if (board.validPosition(pos) && validateMove(pos)) {
                boolMatrix[pos.row, pos.column] = true;
            }
            //SOUTH
            pos.changePosition(position.row + 1, position.column);
            if (board.validPosition(pos) && validateMove(pos)) {
                boolMatrix[pos.row, pos.column] = true;
            }
            //SOUTHWEST
            pos.changePosition(position.row + 1, position.column - 1);
            if (board.validPosition(pos) && validateMove(pos)) {
                boolMatrix[pos.row, pos.column] = true;
            }
            //WEST
            pos.changePosition(position.row, position.column - 1);
            if (board.validPosition(pos) && validateMove(pos)) {
                boolMatrix[pos.row, pos.column] = true;
            }
            //NORTHWEST
            pos.changePosition(position.row - 1, position.column - 1);
            if (board.validPosition(pos) && validateMove(pos)) {
                boolMatrix[pos.row, pos.column] = true;
            }

            return boolMatrix;
        }
    }
}
