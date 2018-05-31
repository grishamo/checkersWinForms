using System;
using System.Drawing;
using System.Windows.Forms;

namespace B18_Ex05_Gregory_317612950_Mariya_321373136
{
    public partial class Game : Form
    {
        Player m_FirstPlayer;
        Player m_SecondPlayer;
        BoardPiece[,] m_PlayBoard;
        Panel m_BoardContainer;
        GameLogic m_GameLogic;
        BoardPiece m_SelectedBoardPiece = null;
        bool m_IsPlayVsComp = false;
        int m_BoardSize;

        public Game()
        {
            GameSettings gameSettings = new GameSettings();
            gameSettings.ShowDialog();

            InitializeComponent();
            InitializeGameData(gameSettings);

            m_GameLogic = new GameLogic(m_FirstPlayer, m_SecondPlayer, m_PlayBoard, m_IsPlayVsComp);
            drawGameBoard();

        }

        private void drawGameBoard()
        {
            foreach (BoardPiece buttonPiece in m_PlayBoard)
            {
                m_BoardContainer.Controls.Add(buttonPiece);
            }
           
        }

        private void InitializeGameData(GameSettings i_GameSettings)
        {
            labelFirstPlayer.Text = i_GameSettings.FirstPlayerName;
            labelSecondPlayer.Text = i_GameSettings.SecondPlayerName;
            m_BoardSize = i_GameSettings.BoardSize;
            m_IsPlayVsComp = i_GameSettings.IsVsComp;

            m_FirstPlayer = new Player(1, i_GameSettings.FirstPlayerName, "X", "K");
            m_SecondPlayer = new Player(2, i_GameSettings.SecondPlayerName, "O", "Q");

            m_BoardContainer = initializeBoardPanel();

            m_PlayBoard = buildGameBoard(m_BoardSize);
            initializePiecesValues();

        }

        private Panel initializeBoardPanel()
        {
            Panel BoardContainer = new Panel();
            BoardContainer.Location = new Point(0, 70);
            BoardContainer.AutoSize = true;
            this.Controls.Add(BoardContainer);
            return BoardContainer;
        }

        private BoardPiece[,] buildGameBoard(int size)
        {
            int xLoc = m_BoardContainer.Location.X;
            int yLoc = m_BoardContainer.Location.Y;

            BoardPiece[,] playBoard = new BoardPiece[size,size];

            int colorCount = 0;
            for(int i = 0; i < size; i++)
            {
                for(int j = 0; j < size; j++)
                {
                    playBoard[i,j] = new BoardPiece(i,j);
                    playBoard[i, j].Name = "sqrBox" + (i+j).ToString();
                    xLoc = 14 + 58 * j;
                    yLoc = 36 + 54 * i;
                    playBoard[i, j].BackColor = (((colorCount / size) % 2) + colorCount) % 2 == 0 ? Color.Gray : Color.White;
                    playBoard[i, j].Location = new Point(xLoc, yLoc);
                    playBoard[i, j].Size = new Size(58, 54);
                    playBoard[i, j].Value = "";

                    if (playBoard[i, j].BackColor == Color.White)
                    {
                        playBoard[i, j].Click += GameBoard_Click;
                    }
                    colorCount++;
                }
            }
            return playBoard;
        }

        private void initializePiecesValues()
        {
            if(m_PlayBoard != null)
            {
                //First player's pieces postion - bottom player
                initPieces(m_BoardSize / 2 + 1, m_BoardSize, m_BoardSize, "X");

                //Second player's pieces postion - top player
                initPieces(0, m_BoardSize / 2 - 1, m_BoardSize, "O");

                //Empty pieces
                initPieces(m_BoardSize / 2 - 1, m_BoardSize / 2 + 1, m_BoardSize, "");
            }
        }

        private void initPieces(int i_StartRow, int i_EndRow, int i_BoardSize, string i_PieceValue)
        {

            for (int i = i_StartRow; i < i_EndRow; i++)
            {
                if ((i % 2) == 0)
                {
                    for (int j = 1; j < i_BoardSize; j += 2)
                    {
                        m_PlayBoard[i, j].Value = i_PieceValue;
                    }
                }
                else
                {
                    for (int j = 0; j < i_BoardSize; j += 2)
                    {
                        m_PlayBoard[i, j].Value = i_PieceValue;
                    }
                }
            }
        }

        private void GameBoard_Click(object sender, EventArgs e)
        {
            BoardPiece currentButton = (sender as BoardPiece);

            togglePieceBackgroundColor(currentButton, m_SelectedBoardPiece);
            if (isValidMove(m_SelectedBoardPiece, currentButton))
            {
                try
                {
                    m_GameLogic.Move(m_SelectedBoardPiece, currentButton);
                    if(m_GameLogic.isGameOver())
                    {
                        if (PopUp.GameOver(m_GameLogic.CurrentPlayer.Name) == DialogResult.Yes)
                        {
                            updatePlayerScore(m_GameLogic.CurrentPlayer);
                            initializePiecesValues();
                            m_GameLogic = new GameLogic(m_FirstPlayer, m_SecondPlayer, m_PlayBoard, m_IsPlayVsComp);
                        }
                        else
                        {
                            Application.Exit();
                        };
                    }
                }
                catch(Exception ex)
                {
                    PopUp.Error(ex.Message);
                }
            }

            m_SelectedBoardPiece = currentButton;
        }

        private void updatePlayerScore(Player i_Winner)
        {
            i_Winner.Score++;
            if (i_Winner.PlayerId == 1)
            {
                Player1Score.Text = i_Winner.Score.ToString();
            }
            else
            {
                Player2Score.Text = i_Winner.Score.ToString();
            }
        }

        private bool isValidMove(BoardPiece i_From, BoardPiece i_To)
        {
            return i_From != null && i_To.Value == "";
        }

        private void togglePieceBackgroundColor(BoardPiece i_CurrentButton, BoardPiece i_PreviousButton)
        {
            if (i_PreviousButton != null && i_PreviousButton != i_CurrentButton)
            {
                i_PreviousButton.BackColor = Color.White;
            }


            if (i_CurrentButton.BackColor == Color.LightGreen)
            {
                i_CurrentButton.BackColor = Color.White;
            }
            else
            {
                i_CurrentButton.BackColor = Color.LightGreen;
            }
        }
    }
}
