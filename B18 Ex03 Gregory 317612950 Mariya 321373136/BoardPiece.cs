using System.Drawing;
using System.Windows.Forms;

namespace B18_Ex05_Gregory_317612950_Mariya_321373136
{
    class BoardPiece : Button
    {
        Point m_PiecePosition;

        public BoardPiece(){}

        public BoardPiece(int i_Row, int i_Col)
        {
            m_PiecePosition = new Point(i_Row, i_Col);
        }

        public string Value
        {
            get { return this.Text; }
            set { Text = value; }
        }
        
        public bool isQueneValue()
        {
            return Value == "Q" || Value == "K";
        }

        public Point Position
        {
            get { return m_PiecePosition; }
            set { m_PiecePosition = value; }
        }
    }
}
