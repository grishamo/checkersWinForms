using System;
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

            InitializeGameData(gameSettings);
            InitializeComponent();
        }

        private void InitializeGameData(Form i_GameSettings)
        {
            this.Player1Name.Text = "";
        }

    }
}
