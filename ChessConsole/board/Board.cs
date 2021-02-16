namespace board {
    class Board {
        public int rows { get; set; }
        public int columns { get; set; }
        private Piece[,] pieces;

        public Board(int rows, int columns) {
            this.rows = rows;
            this.columns = columns;
            pieces = new Piece[rows, columns];
        }

        public Piece piece(int row, int column) {
            return pieces[row, column];
        }

        public Piece piece(Position pos) {
            try {
                return pieces[pos.row, pos.column];
            }
            catch (System.Exception e) {
                throw new BoardException("Digite uma posição!");
            }
        }

        public bool piecePlaced(Position pos) {
            validatePosition(pos);
            return piece(pos) != null;
        }

        public void placePiece(Piece p, Position pos) {
            if(piecePlaced(pos)) {
                throw new BoardException("Já existe uma peça nessa posição!");
            }
            pieces[pos.row, pos.column] = p;
            p.position = pos;
        }

        public Piece takePiece(Position pos) {
            if(piece(pos) == null) {
                return null;
            }
            Piece aux = piece(pos);
            aux.position = null;
            pieces[pos.row, pos.column] = null;
            return aux;
        }

        public bool validPosition(Position pos) {
            if (pos.row < 0 || pos.row >= rows || pos.column < 0 || pos.column >= columns) {
                return false;
            }
            return true;
        }

        public void validatePosition(Position pos) {
            if(!validPosition(pos)) {
                throw new BoardException("Posição Inválida!");
            }
        }
    }
}
