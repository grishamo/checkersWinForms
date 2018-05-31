
namespace B18_Ex05_Gregory_317612950_Mariya_321373136
{
	class Player
	{
		////Members:
		private string m_PlayerName; 
		private int m_score;
		private string m_Piece;
        private string m_Queen;
        int m_PlayerId;

        ////Methods:
        public Player(int i_PlayerId, string i_PlayerName, string i_Piece, string i_QueenPiece)
		{
            m_PlayerId = i_PlayerId;
			m_PlayerName = i_PlayerName;
            PieceValue = i_Piece;
            QueenPieceValue = i_QueenPiece;
		}

        public int PlayerId
        {
            get { return m_PlayerId; }
        }

		public string Name
		{
			get { return m_PlayerName; }
			set { m_PlayerName = value; }
		}

		public int Score
		{
			get { return m_score; }
			set { m_score = value; }
		}

		public string PieceValue
        {
			get { return m_Piece; }
			set { m_Piece = value; }
		}

        public string QueenPieceValue
        {
            get { return m_Queen; }
            set { m_Queen = value; }
        }

        public bool IsPlayerPiece(BoardPiece i_Piece)
        {
            return i_Piece.Text.Equals(PieceValue) || i_Piece.Text.Equals(QueenPieceValue);
        }
    }
}
