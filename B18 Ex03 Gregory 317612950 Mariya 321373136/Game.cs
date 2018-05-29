﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace B18_Ex05_Gregory_317612950_Mariya_321373136
{
    public partial class Game : Form
    {
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

            int boardSize = i_GameSettings.BoardSize;
        }


    }
}
