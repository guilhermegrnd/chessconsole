using board;

namespace chess {
    class Pawn : Piece {

        private ChessMatch match;
        public Pawn(Board board, Color color, ChessMatch match) : base(board, color) {
            this.match = match;
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

                //EN PASSANT
                if(position.row == 3) {
                    Position left = new Position(position.row, position.column - 1);
                    if (board.validPosition(left) && enemyAhead(left) && board.piece(left) == match.vulnerableEnPassant) {
                        boolMatrix[left.row - 1, left.column] = true;
                    }
                    Position right = new Position(position.row, position.column + 1);
                    if (board.validPosition(right) && enemyAhead(right) && board.piece(right) == match.vulnerableEnPassant) {
                        boolMatrix[right.row - 1, right.column] = true;
                    }
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
                //EN PASSANT
                if (position.row == 4) {
                    Position left = new Position(position.row, position.column - 1);
                    if (board.validPosition(left) && enemyAhead(left) && board.piece(left) == match.vulnerableEnPassant) {
                        boolMatrix[left.row + 1, left.column] = true;
                    }
                    Position right = new Position(position.row, position.column + 1);
                    if (board.validPosition(right) && enemyAhead(right) && board.piece(right) == match.vulnerableEnPassant) {
                        boolMatrix[right.row + 1, right.column] = true;
                    }
                }
            }
            
            return boolMatrix;
        }
    }
}
