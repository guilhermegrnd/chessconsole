using System.Collections.Generic;
using board;

namespace chess {
    class ChessMatch {
        public Board board { get; private set; }
        public int move { get; private set; }
        public  Color currentPlayer { get; private set; }
        public bool gameOver { get; private set; }
        private HashSet<Piece> pieces;
        private HashSet<Piece> taken;

        public ChessMatch() {
            board = new Board(8, 8);
            move = 1;
            currentPlayer = Color.White;
            gameOver = false;
            pieces = new HashSet<Piece>();
            taken = new HashSet<Piece>();
            placePieces();
        }

        public void executeMove(Position origin, Position destination) {
            Piece p = board.takePiece(origin);
            p.incrementMovesMade();
            Piece pieceTaken = board.takePiece(destination);
            board.placePiece(p, destination);
            if(pieceTaken != null) {
                taken.Add(pieceTaken);
            }
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

        public HashSet<Piece> getPiecesTakenByColor(Color color) {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in taken) {
                if (x.color == color) {
                    aux.Add(x);
                }
            }
            return aux;
        }

        public HashSet<Piece> getPiecesByColor(Color color) {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in pieces) {
                if (x.color == color) {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(getPiecesByColor(color));
            return aux;
        }

        public void placePiece(char column, int row, Piece piece) {
            board.placePiece(piece, new ChessPosition(column, row).toPosition());
            pieces.Add(piece);
        }

        private void placePieces() {
            placePiece('C', 1, new Rook(board, Color.White));
            placePiece('C', 2, new Rook(board, Color.White));
            placePiece('D', 1, new King(board, Color.White));
            placePiece('D', 2, new Rook(board, Color.White));
            placePiece('E', 1, new Rook(board, Color.White));
            placePiece('E', 2, new Rook(board, Color.White));

            placePiece('C', 7, new Rook(board, Color.Black));
            placePiece('C', 8, new Rook(board, Color.Black));
            placePiece('D', 7, new Rook(board, Color.Black));
            placePiece('D', 8, new King(board, Color.Black));
            placePiece('E', 7, new Rook(board, Color.Black));
            placePiece('E', 8, new Rook(board, Color.Black));
        }
    }
}
