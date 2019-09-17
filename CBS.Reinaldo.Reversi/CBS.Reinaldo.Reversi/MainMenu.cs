using CBS.Reinaldo.Reversi.DataRepository;
using CBS.Reinaldo.Reversi.Entity;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CBS.Reinaldo.Reversi
{
    public partial class MainMenu : Form
    {
        private OthelloRepository _othelloRepository = new OthelloRepository();
        private List<GameHistory> _gameHistories;

        public MainMenu()
        {
            InitializeComponent();
            _gameHistories = _othelloRepository.GetAll();
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
