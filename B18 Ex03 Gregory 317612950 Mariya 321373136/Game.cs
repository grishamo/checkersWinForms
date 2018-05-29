using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace B18_Ex05_Gregory_317612950_Mariya_321373136
{
    public partial class Game : Form
    {
        //Player m_FirstPlayer;
        //Player m_SecondPlayer;
        Button[,] playBoard;
        Button m_SelectedBoardPiece = new Button();
        int m_BoardSize;

        public Game()
        {
            GameSettings gameSettings = new GameSettings();
            gameSettings.ShowDialog();

            InitializeComponent();
            InitializeGameData(gameSettings);
            
        }

        private void InitializeGameData(GameSettings i_GameSettings)
        {
            labelFirstPlayer.Text = i_GameSettings.FirstPlayerName;
            labelSecondPlayer.Text = i_GameSettings.SecondPlayerName;
            m_BoardSize = i_GameSettings.BoardSize;
            //m_FirstPlayer = new Player(i_GameSettings.FirstPlayerName);
            //m_SecondPlayer = new Player(i_GameSettings.SecondPlayerName);


            drawGameBoard(i_GameSettings.BoardSize);
            initializePiecesValues();
        }

        private void drawGameBoard(int size)
        {
            int xLoc = boardContainer.Location.X;
            int yLoc = boardContainer.Location.Y;

            playBoard = new Button[size,size];

            int colorCount = 0;
            for(int i = 0; i < size; i++)
            {
                for(int j = 0; j < size; j++)
                {
                    playBoard[i,j] = new Button();
                    playBoard[i, j].Name = "sqrBox" + (i+j).ToString();
                    xLoc = 14 + 58 * j;
                    yLoc = 36 + 54 * i;
                    playBoard[i, j].BackColor = (((colorCount / size) % 2) + colorCount) % 2 == 0 ? Color.Gray : Color.White;
                    playBoard[i, j].Location = new Point(xLoc, yLoc);
                    playBoard[i, j].Size = new Size(58, 54);

                    if(playBoard[i, j].BackColor == Color.White)
                    {
                        playBoard[i, j].Click += GameBoard_Click;
                    }
                    boardContainer.Controls.Add(playBoard[i, j]);
                    colorCount++;
                }
            }
        }

        private void initializePiecesValues()
        {
            if(playBoard != null)
            {
                ////First player's pieces postion - bottom player
                initPlayerPieces(m_BoardSize / 2 + 1, m_BoardSize, m_BoardSize, "O");

                ////Second player's pieces postion - top player
                initPlayerPieces(0, m_BoardSize / 2 - 1, m_BoardSize, "X");
            }
        }

        private void initPlayerPieces(int i_StartRow, int i_EndRow, int i_BoardSize, string i_PieceValue)
        {

            for (int i = i_StartRow; i < i_EndRow; i++)
            {
                if ((i % 2) == 0)
                {
                    for (int j = 1; j < i_BoardSize; j += 2)
                    {
                        playBoard[i, j].Text = i_PieceValue;
                    }
                }
                else
                {
                    for (int j = 0; j < i_BoardSize; j += 2)
                    {
                        playBoard[i, j].Text = i_PieceValue;
                    }
                }
            }
        }

        private void GameBoard_Click(object sender, EventArgs e)
        {
            Button currentButton = (sender as Button);

            if (m_SelectedBoardPiece != currentButton)
            {
                m_SelectedBoardPiece.BackColor = Color.White;
            }
            
        
            if (currentButton.BackColor == Color.LightGreen)
            {
                currentButton.BackColor = Color.White;
            }
            else
            {
                currentButton.BackColor = Color.LightGreen;
            }

            m_SelectedBoardPiece = currentButton;
        }
    }
}
