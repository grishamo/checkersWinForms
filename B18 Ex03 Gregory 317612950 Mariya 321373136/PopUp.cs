using System.Windows.Forms;

namespace B18_Ex05_Gregory_317612950_Mariya_321373136
{
    class PopUp
    {
        public static DialogResult GameOver(string i_WinnerName)
        {
            string message = string.Format(
@"Player {0} Won!
Another Round?", i_WinnerName);
            return MessageBox.Show(message, "Game Over", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        public static void Error(string i_msg)
        {
            MessageBox.Show(i_msg, "Error", MessageBoxButtons.OK);
        }
    }
}
