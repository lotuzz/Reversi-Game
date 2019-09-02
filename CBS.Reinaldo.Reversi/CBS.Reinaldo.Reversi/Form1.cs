using CBS.Reinaldo.Reversi.Entity;
using System;
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
                TabIndex = index
            };
            btn.Click += new EventHandler(_GetMove);
            return btn;
        }

        private void _GetMove(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            //CheckMove

            //MakeMove
            _MakeMove(btn);

            _NextTurn();
        }

        private void _MakeMove(Control btn)
        {
            var index = Controls.GetChildIndex(btn);
            if (_CurrentTurn.PlayerSide == Color.Black)
            {
                Controls[index].BackColor = Color.Black;
            }
            else if (_CurrentTurn.PlayerSide == Color.White)
            {
                Controls[index].BackColor = Color.White;
            }
            else
            {
                throw new Exception("Current player color undefined");
            }
            btn.Enabled = false;
        }

        private void _NextTurn()
        {
            if(_CurrentTurn.PlayerSide == Color.Black)
            {
                _CurrentTurn = _WhitePlayer;
            }
            else
            {
                _CurrentTurn = _BlackPlayer;
            }

            _PlayerTurnLabel.Text = _CurrentTurn.PlayerSide.Name;
        }
        
        private void _InitializeBoard()
        {
            //Generate 8x8 Panel
            for (int i = 0; i <= 63; i++)
            {
                Controls.Add(_CreatePanel(i));
            }

            //Initialize Disks
            _InitializeDisks();
        }

        private void _InitializeDisks()
        {
            var buttons = Controls.OfType<Button>();
            Button panel;
            
            //28 35 White
            _CurrentTurn = _WhitePlayer;
            panel = buttons.Single(b => b.TabIndex == 28);
            _MakeMove(panel);
            panel = buttons.Single(b => b.TabIndex == 35);
            _MakeMove(panel);

            //27 36 Black
            _CurrentTurn = _BlackPlayer;
            panel = buttons.Single(b => b.TabIndex == 27);
            _MakeMove(panel);
            panel.BackColor = Color.Black;
            panel = buttons.Single(b => b.TabIndex == 36);
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
