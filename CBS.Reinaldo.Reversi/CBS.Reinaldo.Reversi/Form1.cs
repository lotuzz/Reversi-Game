﻿using CBS.Reinaldo.Reversi.Entity;
using CBS.Reinaldo.Reversi.Utility;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
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

        private IEnumerable<Button> _Board;

        public Form1()
        {
            InitializeComponent();
        }

        private void _StartGame(object sender, EventArgs e)
        {
            _CreateBoard();
            _InitializePlayers();

            //Enable Panels
            BoardUtility.EnablePossiblePanel(_Board, _CurrentTurn);

            _DisplayScore();
        }

        private void _RestartGame()
        {
            Controls.Clear();
            InitializeComponent();
            _StartGame(this, null);
        }

        //Event Handler
        private void _GetMove(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            //MakeMove
            GamePlayUtility.MakeMove(_CurrentTurn, btn);

            //Try Flip Enemy Disks
            BoardUtility.TryFlipEnemyDisks(_Board, _CurrentTurn, _Enemy(), _Index(btn));

            //Update Score Display
            _DisplayScore();

            //Set Next Turn
            MessageBox.Show("Waow");
            _NextTurn();
        }

        private void _NextTurn()
        {
            _CurrentTurn = _Enemy();
            _PlayerTurnLabel.Text = _CurrentTurn.PlayerSide.Name;
            
            if (!GamePlayUtility.IsPossibleToMove(_Board, _CurrentTurn))
            {
                if (!GamePlayUtility.IsPossibleToMove(_Board, _Enemy()))
                {
                    //Game Over
                    var whiteScore = _WhitePlayer.AcquiredPanels.Count;
                    var blackScore = _BlackPlayer.AcquiredPanels.Count;
                    var winner = whiteScore > blackScore ? _WhitePlayer : _BlackPlayer;

                    MessageBox.Show($"White Score = {whiteScore} {Environment.NewLine} Black Score = {blackScore} ", $"[GAME OVER] {winner.PlayerSide.Name} Player Win");

                    _RestartGame();
                    return;
                }
                MessageBox.Show($"[{_CurrentTurn.PlayerSide.Name}] Player can't move. [{_Enemy().PlayerSide.Name}] Turn", "Game Notification");

                _NextTurn();
            }

            if (_CurrentTurn is GreedyAI player) player.AutoMove(_Board);
        }

        #region Called Once
        private void _CreateBoard()
        {
            //Generate 8x8 Panel
            for (int i = 0; i <= 63; i++)
            {
                Controls.Add(_CreatePanel(i));
            }
            _Board = Controls.OfType<Button>();
        }
        
        private void _InitializePlayers()
        {
            _BlackPlayer = new Player
            {
                PlayerSide = Color.Black
            };
            _WhitePlayer = new GreedyAI
            {
                PlayerSide = Color.White
            };

            _CurrentTurn = _BlackPlayer;
            _PlayerTurnLabel.Text = _CurrentTurn.PlayerSide.Name;
            
            //Initialize Disks
            BoardUtility.InitializeDisks(_Board, _WhitePlayer, _BlackPlayer);
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
    }
}
