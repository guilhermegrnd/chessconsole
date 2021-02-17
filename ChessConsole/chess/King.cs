using board;

namespace chess {
    class King : Piece {

        private ChessMatch match;
        public King(Board board, Color color, ChessMatch match) : base(board, color) {
            this.match = match;
        }

        public override string ToString() {
            return "K";
        }

        private bool checkRookCastle(Position pos) {
            Piece p = board.piece(pos);
            return p != null && p is Rook && p.color == color && p.movesMade == 0;
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

            //CASTLE
            if(movesMade == 0 && !match.check) {
                //SHORT CASTLE
                Position posRook1 = new Position(position.row, position.column + 3);
                if(checkRookCastle(posRook1)) {
                    Position pos1 = new Position(position.row, position.column + 1);
                    Position pos2 = new Position(position.row, position.column + 2);
                    if(board.piece(pos1) == null && board.piece(pos2) == null) {
                        boolMatrix[position.row, position.column + 2] = true;
                    }
                }

                //LONG CASTLE
                Position posRook2 = new Position(position.row, position.column - 4);
                if (checkRookCastle(posRook2)) {
                    Position pos1 = new Position(position.row, position.column - 1);
                    Position pos2 = new Position(position.row, position.column - 2);
                    Position pos3 = new Position(position.row, position.column - 3);
                    if (board.piece(pos1) == null && board.piece(pos2) == null && board.piece(pos3) == null) {
                        boolMatrix[position.row, position.column - 2] = true;
                    }
                }
            }

            return boolMatrix;
        }
    }
}
