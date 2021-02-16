using board;

namespace chess {
    class Knight : Piece {
        public Knight(Board board, Color color) : base(board, color) {
        }

        public override string ToString() {
            return "k";
        }

        private bool validateMove(Position pos) {
            Piece p = board.piece(pos);
            return p == null || p.color != color;
        }

        public override bool[,] possibleMoves() {
            bool[,] boolMatrix = new bool[board.rows, board.columns];

            Position pos = new Position(0, 0);

            //NORTHWEST
            pos.changePosition(position.row - 1, position.column - 2);
            if (board.validPosition(pos) && validateMove(pos)) {
                boolMatrix[pos.row, pos.column] = true;
            }
            pos.changePosition(position.row - 2, position.column - 1);
            if (board.validPosition(pos) && validateMove(pos)) {
                boolMatrix[pos.row, pos.column] = true;
            }
            //NORTHEAST
            pos.changePosition(position.row - 2, position.column + 1);
            if (board.validPosition(pos) && validateMove(pos)) {
                boolMatrix[pos.row, pos.column] = true;
            }
            pos.changePosition(position.row - 1, position.column + 2);
            if (board.validPosition(pos) && validateMove(pos)) {
                boolMatrix[pos.row, pos.column] = true;
            }
            //SOUTHEAST
            pos.changePosition(position.row + 1, position.column + 2);
            if (board.validPosition(pos) && validateMove(pos)) {
                boolMatrix[pos.row, pos.column] = true;
            }
            pos.changePosition(position.row + 2, position.column + 1);
            if (board.validPosition(pos) && validateMove(pos)) {
                boolMatrix[pos.row, pos.column] = true;
            }
            //SOUTHWEST
            pos.changePosition(position.row + 1, position.column - 2);
            if (board.validPosition(pos) && validateMove(pos)) {
                boolMatrix[pos.row, pos.column] = true;
            }
            pos.changePosition(position.row + 2, position.column - 1);
            if (board.validPosition(pos) && validateMove(pos)) {
                boolMatrix[pos.row, pos.column] = true;
            }

            return boolMatrix;
        }
    }
}
