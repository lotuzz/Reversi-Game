using System.Drawing;
using System.Windows.Forms;

namespace CBS.Reinaldo.Reversi
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void _PVPButton_Click(object sender, System.EventArgs e)
        {
            _StartGame(null);
        }

        private void _WhitePlayerButton_Click(object sender, System.EventArgs e)
        {
            _StartGame(Color.Black);
        }

        private void _BlackPlayerButton_Click(object sender, System.EventArgs e)
        {
            _StartGame(Color.White);
        }

        private void _StartGame(Color? AI)
        {
            var othelloGame = new OthelloGame(AI);
            othelloGame.Shown += (s, args) => Hide();
            othelloGame.Closed += (s, args) => Close();

            othelloGame.Show();
        }
    }
}
