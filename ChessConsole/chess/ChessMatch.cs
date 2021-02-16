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
        public bool check { get; private set; }

        public ChessMatch() {
            board = new Board(8, 8);
            move = 1;
            currentPlayer = Color.White;
            gameOver = false;
            pieces = new HashSet<Piece>();
            taken = new HashSet<Piece>();
            check = false;
            placePieces();
        }

        public Piece executeMove(Position origin, Position destination) {
            Piece p = board.takePiece(origin);
            p.incrementMovesMade();
            Piece pieceTaken = board.takePiece(destination);
            board.placePiece(p, destination);
            if(pieceTaken != null) {
                taken.Add(pieceTaken);
            }
            return pieceTaken;
        }

        public void undoMove(Position origin, Position destination, Piece pieceTaken) {
            Piece piece = board.takePiece(destination);
            piece.decrementMovesMade();
            if(pieceTaken != null) {
                board.placePiece(pieceTaken, destination);
                taken.Remove(pieceTaken);
            }
            board.placePiece(piece, origin);
        }

        public void executePlay(Position origin, Position destination) {
            Piece pieceTaken = executeMove(origin, destination);

            if(inCheck(currentPlayer)) {
                undoMove(origin,destination,pieceTaken);
                throw new BoardException("Você não pode se colocar em xeque!");
            }

            if (inCheck(adversary(currentPlayer))) {
                check = true;
            } else {
                check = false;
            }

            if(checkMate(adversary(currentPlayer))) {
                gameOver = true;
            } else {
                move++;
                changeCurrentPlayer();
            }
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
            if(!board.piece(origin).possibleMove(destination)) {
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
            aux.ExceptWith(getPiecesTakenByColor(color));
            return aux;
        }

        private Color adversary(Color color) {
            if(color == Color.White) {
                return Color.Black;
            } else {
                return Color.White;
            }
        }

        private Piece getKing(Color color) {
            foreach (Piece x in getPiecesByColor(color)) {
                if (x is King) {
                    return x;
                }
            }
            return null;
        }

        public bool inCheck(Color color) {
            Piece king = getKing(color);
            if(king == null) {
                throw new BoardException("Não tem rei da cor " + color + " no tabuleiro!");
            }

            foreach(Piece x in getPiecesByColor(adversary(color))) {
                bool[,] matrix = x.possibleMoves();
                if(matrix[king.position.row,king.position.column]) {
                    return true;
                }
            }
            return false;
        }

        public bool checkMate(Color color) {
            if(!inCheck(color)) {
                return false;
            }
            foreach(Piece x in getPiecesByColor(color)) {
                bool[,] matrix = x.possibleMoves();
                for(int i = 0; i < board.rows; i++) {
                    for(int j = 0; j < board.columns; j++) {
                        if(matrix[i, j]) {
                            Position origin = x.position;
                            Position destination = new Position(i, j);
                            Piece pieceTaken = executeMove(origin, destination);
                            bool checkTest = inCheck(color);
                            undoMove(origin, destination, pieceTaken);
                            if(!checkTest) {
                                return false;
                            }
                        }
                    }
                }
            }
            
            return true;
        }

        public void placePiece(char column, int row, Piece piece) {
            board.placePiece(piece, new ChessPosition(column, row).toPosition());
            pieces.Add(piece);
        }

        private void placePieces() {
            placePiece('A', 1, new Rook(board, Color.White));
            placePiece('B', 1, new Knight(board, Color.White));
            placePiece('C', 1, new Bishop(board, Color.White));
            placePiece('D', 1, new Queen(board, Color.White));
            placePiece('E', 1, new King(board, Color.White));
            placePiece('F', 1, new Bishop(board, Color.White));
            placePiece('G', 1, new Knight(board, Color.White));
            placePiece('H', 1, new Rook(board, Color.White));
            placePiece('A', 2, new Pawn(board, Color.White));
            placePiece('B', 2, new Pawn(board, Color.White));
            placePiece('C', 2, new Pawn(board, Color.White));
            placePiece('D', 2, new Pawn(board, Color.White));
            placePiece('E', 2, new Pawn(board, Color.White));
            placePiece('F', 2, new Pawn(board, Color.White));
            placePiece('G', 2, new Pawn(board, Color.White));
            placePiece('H', 2, new Pawn(board, Color.White));

            placePiece('A', 8, new Rook(board, Color.Black));
            placePiece('B', 8, new Knight(board, Color.Black));
            placePiece('C', 8, new Bishop(board, Color.Black));
            placePiece('D', 8, new Queen(board, Color.Black));
            placePiece('E', 8, new King(board, Color.Black));
            placePiece('F', 8, new Bishop(board, Color.Black));
            placePiece('G', 8, new Knight(board, Color.Black));
            placePiece('H', 8, new Rook(board, Color.Black));
            placePiece('A', 7, new Pawn(board, Color.Black));
            placePiece('B', 7, new Pawn(board, Color.Black));
            placePiece('C', 7, new Pawn(board, Color.Black));
            placePiece('D', 7, new Pawn(board, Color.Black));
            placePiece('E', 7, new Pawn(board, Color.Black));
            placePiece('F', 7, new Pawn(board, Color.Black));
            placePiece('G', 7, new Pawn(board, Color.Black));
            placePiece('H', 7, new Pawn(board, Color.Black));
        }
    }
}
