using System;
using board;

namespace chess {
    class ChessMatch {
        public Board board { get; private set; }
        private int move;
        private Color currentPlayer;
        public bool gameOver { get; private set; }

        public ChessMatch() {
            board = new Board(8, 8);
            move = 1;
            currentPlayer = Color.White;
            gameOver = false;
            placePieces();
        }

        public void executeMove(Position origin, Position destination) {
            Piece p = board.takePiece(origin);
            p.incrementMovesMade();
            Piece pieceTaken = board.takePiece(destination);
            board.placePiece(p, destination);
        }

        private void placePieces() {
            board.placePiece(new Rook(board, Color.Black), new ChessPosition('C', 1).toPosition());
            board.placePiece(new Rook(board, Color.Black), new ChessPosition('C', 2).toPosition());
            board.placePiece(new King(board, Color.White), new ChessPosition('E', 2).toPosition());
            board.placePiece(new Rook(board, Color.White), new ChessPosition('E', 1).toPosition());
        }
    }
}
