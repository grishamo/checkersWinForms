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
        private int m_BoardSize;

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

        public int BoardSize
        {
            get { return m_BoardSize; }
            set { m_BoardSize = value; }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {

            if(isValidInputs())
            {
                FirstPlayerName = textBoxFirstPlayer.Text;
                SecondPlayerName = textBoxSecondPlayer.Text;
                BoardSize = int.Parse(GetCheckedRadio(groupBoxBoardSize).Text[0].ToString());
                DialogResult = DialogResult.OK;
                Close();

            }

        }

        private RadioButton GetCheckedRadio(Control container)
        {
            foreach (var control in container.Controls)
            {
                RadioButton radio = control as RadioButton;

                if (radio != null && radio.Checked)
                {
                    return radio;
                }
            }

            return null;
        }

        private bool isValidInputs()
        {
            bool isValid = true;
            string firstPlayerName = textBoxFirstPlayer.Text;
            string secondPlayerName = textBoxSecondPlayer.Text;

            if (firstPlayerName.Length == 0 || secondPlayerName.Length == 0)
            {
                isValid = false;
                if (MessageBox.Show(
                                "Missing Player Name",
                                "Login",
                                MessageBoxButtons.RetryCancel,
                                MessageBoxIcon.Error) == DialogResult.Cancel)
                {
                    Application.Exit();
                }
            }

            return isValid;
        }

        private void checkBoxSecondPlayer_CheckStateChanged(object sender, EventArgs e)
        {
            textBoxSecondPlayer.Enabled = true;
            textBoxSecondPlayer.Text = null;
        }
    }
}
