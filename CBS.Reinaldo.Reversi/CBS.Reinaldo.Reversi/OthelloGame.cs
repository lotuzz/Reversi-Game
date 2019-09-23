using CBS.Reinaldo.Reversi.Entity;
using CBS.Reinaldo.Reversi.Utility;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CBS.Reinaldo.Reversi
{
    public partial class OthelloGame : Form
    {
        private int _Size = 45;
        private Point InitialPoint = new Point(45, 60);

        private Player _BlackPlayer;
        private Player _WhitePlayer;
        private Player _CurrentTurn;
        private Color? _AIColor = null;

        private IEnumerable<Button> _Board;
        private int _ticks = 0;

        public OthelloGame(Color? AI)
        {
            InitializeComponent();
            _AIColor = AI;
        }

        private async void _StartGame(object sender, EventArgs e)
        {
            _InitializePlayers();
            _CreateBoard();
            
            //Enable Panels
            await BoardUtility.EnablePossiblePanel(_Board, _CurrentTurn);

            _GameTimer.Start();

            if (_CurrentTurn is GreedyAI player)
            {
                await player.AutoMove(_Board);
            }
        }
        
        //Event Handler
        private async void _GetMove(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            //MakeMove
            GamePlayUtility.MakeMove(_CurrentTurn, btn);

            //Try Flip Enemy Disks
            await BoardUtility.TryFlipEnemyDisks(_Board, _CurrentTurn, _Enemy(), _Index(btn));

            //Update Score Display
            _DisplayScore();

            //Set Next Turn
            await _NextTurn();
        }

        private async Task _NextTurn()
        {
            BoardUtility.DisablePanelAndResetText(_Board);
            if (!GamePlayUtility.IsPossibleToMove(_Board, _Enemy()))
            {
                if (!GamePlayUtility.IsPossibleToMove(_Board, _CurrentTurn))
                {
                    _GameOver();
                    return;
                }
                MessageBox.Show($"[{_Enemy().PlayerSide.Name}] Player can't move. [{_CurrentTurn.PlayerSide.Name}] Turn", "Game Notification");
            }

            _CurrentTurn = _Enemy();
            _PlayerTurnLabel.Text = _CurrentTurn.PlayerSide.Name;
            if (_CurrentTurn is GreedyAI player)
            {
                await player.AutoMove(_Board);
            }
        }

        #region Called Once
        private void _CreateBoard()
        {
            //Generate 8x8 Panel
            for (int i = 0; i <= 63; i++)
            {
                Controls.Add(_CreatePanel(i));
            }
            _Board = Controls.OfType<Button>().ToList();

            //Initialize Disks
            BoardUtility.InitializeDisks(_Board, _WhitePlayer, _BlackPlayer);

            _DisplayScore();
        }
        
        private void _InitializePlayers()
        {
            _BlackPlayer = new Player
            {
                PlayerSide = Color.Black
            };
            _WhitePlayer = new Player
            {
                PlayerSide = Color.White
            };
            _SetAI();

            _CurrentTurn = _BlackPlayer;
            _PlayerTurnLabel.Text = _CurrentTurn.PlayerSide.Name;
        }

        private Button _CreatePanel(int index)
        {
            Point location = new Point
            {
                X = InitialPoint.X + ((index % 8) * _Size),
                Y = InitialPoint.Y + ((index / 8) * _Size)
            };

            Button btn = new Button
            {
                Name = index.ToString(),
                Width = _Size,
                Height = _Size,
                BackColor = Color.Lime,
                Text = "",
                Location = location,
                TabIndex = index,
                Enabled = false
            };
            btn.Click += new EventHandler(_GetMove);
            return btn;
        }

        private void _SetAI()
        {
            if(!_AIColor.HasValue)
            {
                return;
            }

            if(_AIColor.Value == Color.Black)
            {
                _BlackPlayer = new GreedyAI(_BlackPlayer);
            }
            else if(_AIColor.Value == Color.White)
            {
                _WhitePlayer = new GreedyAI(_WhitePlayer);
            }
        }

        private void _GameOver()
        {
            _GameTimer.Stop();

            var whiteScore = _WhitePlayer.AcquiredPanels.Count;
            var blackScore = _BlackPlayer.AcquiredPanels.Count;
            var winner = whiteScore > blackScore ? _WhitePlayer : _BlackPlayer;

            _InsertHistory(winner);
            MessageBox.Show($"White Score = {whiteScore} {Environment.NewLine} Black Score = {blackScore} ", $"[GAME OVER] {winner.PlayerSide.Name} Player Win");

            //_RestartGame();
            _BackToMainMenu();
        }

        private void _InsertHistory(Player winner)
        {
            var history = new GameHistory
            {
                White = _WhitePlayer.GetType().ToString(),
                Black = _BlackPlayer.GetType().ToString(),
                DatePlayed = DateTime.UtcNow,
                Winner = winner.PlayerSide.Name.ToString()
            };
        }

        private void _BackToMainMenu()
        {
            var mainMenu = new MainMenu();

            mainMenu.Show();
        }
        
        private void _RestartGame()
        {
            Controls.Clear();
            InitializeComponent();
            _StartGame(this, null);
        }
        #endregion

        private Player _Enemy()
        {
            return _CurrentTurn.PlayerSide == Color.Black ? _WhitePlayer : _BlackPlayer;
        }

        private int _Index(Button panel)
        {
            return int.Parse(panel.Name);
        }

        private void _DisplayScore()
        {
            _WhitePlayerScoreLabel.Text = _WhitePlayer.AcquiredPanels.Count.ToString();
            _BlackPlayerScoreLabel.Text = _BlackPlayer.AcquiredPanels.Count.ToString();
        }

        private void _gameTimer_Tick(object sender, EventArgs e)
        {
            _ticks++;
            _gameTimerLabel.Text = _ticks.ToString();
        }
    }
}
