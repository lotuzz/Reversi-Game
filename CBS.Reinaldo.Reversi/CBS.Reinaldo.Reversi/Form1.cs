using CBS.Reinaldo.Reversi.Entity;
using CBS.Reinaldo.Reversi.Utility;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CBS.Reinaldo.Reversi
{
    public partial class Form1 : Form
    {
        private int _Size = 45;
        private Point InitialPoint = new Point(45, 60);

        private Player _BlackPlayer;
        private Player _WhitePlayer;
        private Player _CurrentTurn;
        private Label _PlayerTurnLabel;

        private IEnumerable<Button> _Board;

        public Form1()
        {
            InitializeComponent();
        }

        private void _StartGame(object sender, EventArgs e)
        {
            _InitializePlayers();
            _InitializeBoard();
            
            _PlayerTurnLabel = Controls.Find("playerlabel", false).First() as Label;
            _PlayerTurnLabel.Text = _CurrentTurn.PlayerSide.Name;

            _EnablePossiblePanel(_CurrentTurn);
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

        private void _GetMove(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            //CheckMove
            //Auto valid

            //MakeMove
            _MakeMove(btn);

            _NextTurn();
        }

        private void _MakeMove(Control btn)
        {
            var index = _Board.ToList().FindIndex(item => item.Name == btn.Name);
            _Board.ElementAt(index).BackColor = _CurrentTurn.PlayerSide == Color.Black ? Color.Black : Color.White;


            _CurrentTurn.AcquiredPanels.Add(index);
        }

        private void _NextTurn()
        {
            BoardUtility.ResetPanelAccessAndText(_Board);
            
            _CurrentTurn = _CurrentTurn.PlayerSide == Color.Black ? _WhitePlayer : _BlackPlayer;

            _EnablePossiblePanel(_CurrentTurn);

            _PlayerTurnLabel.Text = _CurrentTurn.PlayerSide.Name;
        }

        private void _EnablePossiblePanel(Player player)
        {
            foreach(var panelIndex in player.AcquiredPanels)
            {
                BoardUtility.EnableNorth(_Board, player, panelIndex);
                BoardUtility.EnableNorthEast(_Board, player, panelIndex);
                BoardUtility.EnableEast(_Board, player, panelIndex);
                BoardUtility.EnableSouthEast(_Board, player, panelIndex);
                BoardUtility.EnableSouth(_Board, player, panelIndex);
                BoardUtility.EnableSouthWest(_Board, player, panelIndex);
                BoardUtility.EnableWest(_Board, player, panelIndex);
            }
        }
        
        private void _InitializeBoard()
        {
            //Generate 8x8 Panel
            for (int i = 0; i <= 63; i++)
            {
                Controls.Add(_CreatePanel(i));
            }
            _Board = Controls.OfType<Button>();

            //Initialize Disks
            _InitializeDisks();
        }

        private void _InitializeDisks()
        {
            Button panel;
            
            //28 35 White
            _CurrentTurn = _WhitePlayer;
            panel = _Board.Single(b => b.Name == 28.ToString());
            _MakeMove(panel);
            panel = _Board.Single(b => b.Name == 35.ToString());
            _MakeMove(panel);

            //27 36 Black
            _CurrentTurn = _BlackPlayer;
            panel = _Board.Single(b => b.Name == 27.ToString());
            _MakeMove(panel);
            panel.BackColor = Color.Black;
            panel = _Board.Single(b => b.Name == 36.ToString());
            _MakeMove(panel);
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

            _CurrentTurn = _BlackPlayer;
        }
    }
}
