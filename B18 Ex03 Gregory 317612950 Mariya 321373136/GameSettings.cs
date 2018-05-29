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
    public partial class GameSettings : Form
    {
        private string m_Player1Name;
        private string m_Player2Name;


        public GameSettings()
        {
            InitializeComponent();
        }

        public string FirstPlayerName
        {
            get { return m_Player1Name; }
            set {m_Player1Name = value; }
        }

        public string SecondPlayerName
        {
            get { return m_Player2Name; }
            set { m_Player2Name = value; }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {

            if(isValidInputs())
            {

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {

            }

        }

        private bool isValidInputs()
        {
            bool isValid = true;
            return isValid;
        }
    }
}
