using System;
using board;

namespace chess {
    class ChessMatch {
        public Board board { get; private set; }
        public int move { get; private set; }
        public  Color currentPlayer { get; private set; }
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

        public void executePlay(Position origin, Position destination) {
            executeMove(origin, destination);
            move++;
            changeCurrentPlayer();
        }

        public void validOriginPosition(Position pos) {
            if (board.piece(pos) == null) {
                throw new BoardException("Não existe peça na posição de origem escolhida!");
            }
            if (board.piece(pos).color != currentPlayer) {
                throw new BoardException("A peça de origem escolhida não é sua!");
            }
            if (!board.piece(pos).existsPossibleMovements()) {
                throw new BoardException("Não há movimentos possíveis para a peça de origem escolhida!");
            }
        }

        public void validDestinationPosition(Position origin, Position destination) {
            if(!board.piece(origin).canMoveTo(destination)) {
                throw new BoardException("Posição de destino inválida!");
            }
        }

        private void changeCurrentPlayer() {
            if(currentPlayer == Color.White) {
                currentPlayer = Color.Black;
            } else {
                currentPlayer = Color.White;
            }
        }

        private void placePieces() {
            board.placePiece(new Rook(board, Color.Black), new ChessPosition('C', 1).toPosition());
            board.placePiece(new Rook(board, Color.Black), new ChessPosition('C', 2).toPosition());
            board.placePiece(new King(board, Color.White), new ChessPosition('E', 2).toPosition());
            board.placePiece(new Rook(board, Color.White), new ChessPosition('E', 1).toPosition());
        }
    }
}
