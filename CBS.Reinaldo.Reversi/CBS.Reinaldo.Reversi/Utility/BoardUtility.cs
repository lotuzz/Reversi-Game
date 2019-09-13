using CBS.Reinaldo.Reversi.Entity;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Drawing;
using System.Threading.Tasks;

namespace CBS.Reinaldo.Reversi.Utility
{
    public static class BoardUtility
    {
        public static void ResetPanelAccessAndText(IEnumerable<Button> board)
        {
            foreach(var btn in board)
            {
                btn.Enabled = false;
                btn.Text = string.Empty;
            }
        }

        public static async void EnablePossiblePanel(IEnumerable<Button> board, Player player)
        {
            foreach (var panelIndex in player.AcquiredPanels)
            {
                await _EnableNorth(board, player, panelIndex);
                await _EnableNorthEast(board, player, panelIndex);
                await _EnableEast(board, player, panelIndex);
                await _EnableSouthEast(board, player, panelIndex);
                await _EnableSouth(board, player, panelIndex);
                await _EnableSouthWest(board, player, panelIndex);
                await _EnableWest(board, player, panelIndex);
            }
        }

        public static async void TryFlipEnemyDisks(IEnumerable<Button> board, Player player, Player enemy, int index)
        {
            ResetPanelAccessAndText(board);

            var enemyColor = enemy.PlayerSide;
            bool isValid;

            //north
            var northPanels = await DirectionUtility.GetNorthPanels(board, index, enemyColor);
            if (northPanels.Count() == 0) isValid = false;
            else isValid = board.ElementAt(int.Parse(northPanels.Last().Name) -8).BackColor == player.PlayerSide;
            if(isValid)
            {
                foreach (var panel in northPanels)
                {
                    player.AcquirePanel(panel, enemy);
                }
            }

            //east
            var eastPanels = await DirectionUtility.GetEastPanels(board, index, enemyColor);
            if (eastPanels.Count() == 0) isValid = false;
            else isValid = board.ElementAt(int.Parse(eastPanels.Last().Name) + 1).BackColor == player.PlayerSide;
            if (isValid)
            {
                foreach (var panel in eastPanels)
                {
                    player.AcquirePanel(panel, enemy);
                }
            }

            //south
            var southPanels = await DirectionUtility.GetSouthPanels(board, index, enemyColor);
            if (southPanels.Count() == 0) isValid = false;
            else isValid = board.ElementAt(int.Parse(southPanels.Last().Name) + 8).BackColor == player.PlayerSide;
            if (isValid)
            {
                foreach (var panel in southPanels)
                {
                    player.AcquirePanel(panel, enemy);
                }
            }

            //west
            var westPanels = await DirectionUtility.GetWestPanels(board, index, enemyColor);
            if (westPanels.Count() == 0) isValid = false;
            else isValid = board.ElementAt(int.Parse(westPanels.Last().Name) - 1).BackColor == player.PlayerSide;
            if (isValid)
            {
                foreach (var panel in westPanels)
                {
                    player.AcquirePanel(panel, enemy);
                }
            }

            //north east
            var northEasPanels = await DirectionUtility.GetNorthEastPanels(board, index, enemyColor);
            if (northEasPanels.Count() == 0) isValid = false;
            else isValid = board.ElementAt(int.Parse(northEasPanels.Last().Name) + 1 - 8).BackColor == player.PlayerSide;
            if (isValid)
            {
                foreach (var panel in northEasPanels)
                {
                    player.AcquirePanel(panel, enemy);
                }
            }

            //south east
            var southEastPanels = await DirectionUtility.GetSouthEastPanels(board, index, enemyColor);
            if (southEastPanels.Count() == 0) isValid = false;
            else isValid = board.ElementAt(int.Parse(southEastPanels.Last().Name) + 1 + 8).BackColor == player.PlayerSide;
            if (isValid)
            {
                foreach (var panel in southEastPanels)
                {
                    player.AcquirePanel(panel, enemy);
                }
            }

            //south west
            var southWestPanels = await DirectionUtility.GetSouthWestPanels(board, index, enemyColor);
            if (southWestPanels.Count() == 0) isValid = false;
            else isValid = board.ElementAt(int.Parse(southWestPanels.Last().Name) - 1 + 8).BackColor == player.PlayerSide;
            if (isValid)
            {
                foreach (var panel in southWestPanels)
                {
                    player.AcquirePanel(panel, enemy);
                }
            }

            //north west
            var northWestPanels = await DirectionUtility.GetNorthWestPanels(board, index, enemyColor);
            if (northWestPanels.Count() == 0) isValid = false;
            else isValid = board.ElementAt(int.Parse(northWestPanels.Last().Name) - 1 - 8).BackColor == player.PlayerSide;
            if (isValid)
            {
                foreach (var panel in northWestPanels)
                {
                    player.AcquirePanel(panel, enemy);
                }
            }
        }

        public static void InitializeDisks(IEnumerable<Button> board, Player whitePlayer, Player blackPlayer)
        {
            Button panel;

            //28 35 White
            panel = board.Single(b => b.Name == 28.ToString());
            GamePlayUtility.MakeMove(whitePlayer, panel);
            panel = board.Single(b => b.Name == 35.ToString());
            GamePlayUtility.MakeMove(whitePlayer, panel);

            //27 36 Black
            panel = board.Single(b => b.Name == 27.ToString());
            GamePlayUtility.MakeMove(blackPlayer, panel);
            panel = board.Single(b => b.Name == 36.ToString());
            GamePlayUtility.MakeMove(blackPlayer, panel);
        }

        #region Private Method(s)
        private static async Task _EnableNorth(IEnumerable<Button> board, Player player, int index)
        {
            var enemyColor = player.PlayerSide == Color.Black ? Color.White : Color.Black;

            var northPanels = await DirectionUtility.GetNorthPanels(board, index, enemyColor);
            int count = northPanels.Count();
            if (count == 0) return;

            var lastPanelIndex = int.Parse(northPanels.Last().Name) - 8;
            if (lastPanelIndex < 0) return;

            var lastPanel = board.ElementAt(lastPanelIndex);
            if (lastPanel.BackColor != Color.Lime) return;

            lastPanel.Enabled = true;
            lastPanel.ForeColor = player.PlayerSide;
            if (string.IsNullOrEmpty(lastPanel.Text))
            {
                lastPanel.Text = count.ToString();
            }
            else
            {
                count = count + int.Parse(lastPanel.Text);
                lastPanel.Text = count.ToString();
            }
        }

        private static async Task _EnableSouth(IEnumerable<Button> board, Player player, int index)
        {
            var enemyColor = player.PlayerSide == Color.Black ? Color.White : Color.Black;

            var southPanels = await DirectionUtility.GetSouthPanels(board, index, enemyColor);
            int count = southPanels.Count();
            if (count == 0) return;

            var lastPanelIndex = int.Parse(southPanels.Last().Name) + 8;
            if (lastPanelIndex > 63) return;

            var lastPanel = board.ElementAt(lastPanelIndex);
            if (lastPanel.BackColor != Color.Lime) return;

            lastPanel.Enabled = true;
            lastPanel.ForeColor = player.PlayerSide;
            if (string.IsNullOrEmpty(lastPanel.Text))
            {
                lastPanel.Text = count.ToString();
            }
            else
            {
                count = count + int.Parse(lastPanel.Text);
                lastPanel.Text = count.ToString();
            }
        }

        private static async Task _EnableEast(IEnumerable<Button> board, Player player, int index)
        {
            var enemyColor = player.PlayerSide == Color.Black ? Color.White : Color.Black;

            var eastPanels = await DirectionUtility.GetEastPanels(board, index, enemyColor);
            int count = eastPanels.Count();
            if (count == 0) return;

            var lastPanelIndex = int.Parse(eastPanels.Last().Name);
            if ((lastPanelIndex % 8) + 1 > 7) return;
            else lastPanelIndex += 1;

            var lastPanel = board.ElementAt(lastPanelIndex);
            if (lastPanel.BackColor != Color.Lime) return;

            lastPanel.Enabled = true;
            lastPanel.ForeColor = player.PlayerSide;
            if (string.IsNullOrEmpty(lastPanel.Text))
            {
                lastPanel.Text = count.ToString();
            }
            else
            {
                count = count + int.Parse(lastPanel.Text);
                lastPanel.Text = count.ToString();
            }
        }

        private static async Task _EnableWest(IEnumerable<Button> board, Player player, int index)
        {
            var enemyColor = player.PlayerSide == Color.Black ? Color.White : Color.Black;

            var westPanels = await DirectionUtility.GetWestPanels(board, index, enemyColor);
            int count = westPanels.Count();
            if (count == 0) return;

            var lastPanelIndex = int.Parse(westPanels.Last().Name);
            if ((lastPanelIndex % 8) - 1 > 7) return;
            else lastPanelIndex -= 1;

            var lastPanel = board.ElementAt(lastPanelIndex);
            if (lastPanel.BackColor != Color.Lime) return;

            lastPanel.Enabled = true;
            lastPanel.ForeColor = player.PlayerSide;
            if (string.IsNullOrEmpty(lastPanel.Text))
            {
                lastPanel.Text = count.ToString();
            }
            else
            {
                count = count + int.Parse(lastPanel.Text);
                lastPanel.Text = count.ToString();
            }
        }

        private static async Task _EnableNorthEast(IEnumerable<Button> board, Player player, int index)
        {
            var enemyColor = player.PlayerSide == Color.Black ? Color.White : Color.Black;

            var northEastPanels = await DirectionUtility.GetNorthEastPanels(board, index, enemyColor);
            int count = northEastPanels.Count();
            if (count == 0) return;

            var lastPanelIndex = int.Parse(northEastPanels.Last().Name) - 8;
            if (lastPanelIndex < 0) return;

            var modEast = (lastPanelIndex % 8) + 1;
            if (modEast > 7) return;
            else lastPanelIndex += 1;

            var lastPanel = board.ElementAt(lastPanelIndex);
            if (lastPanel.BackColor != Color.Lime) return;

            lastPanel.Enabled = true;
            lastPanel.ForeColor = player.PlayerSide;
            if (string.IsNullOrEmpty(lastPanel.Text))
            {
                lastPanel.Text = count.ToString();
            }
            else
            {
                count = count + int.Parse(lastPanel.Text);
                lastPanel.Text = count.ToString();
            }
        }

        private static async Task _EnableSouthEast(IEnumerable<Button> board, Player player, int index)
        {
            var enemyColor = player.PlayerSide == Color.Black ? Color.White : Color.Black;

            var southEastPanels = await DirectionUtility.GetSouthEastPanels(board, index, enemyColor);
            int count = southEastPanels.Count();
            if (count == 0) return;

            var lastPanelIndex = int.Parse(southEastPanels.Last().Name) + 8;
            if (lastPanelIndex > 63) return;

            var modEast = (lastPanelIndex % 8) + 1;
            if (modEast > 7) return;
            else lastPanelIndex += 1;

            var lastPanel = board.ElementAt(lastPanelIndex);
            if (lastPanel.BackColor != Color.Lime) return;

            lastPanel.Enabled = true;
            lastPanel.ForeColor = player.PlayerSide;
            if (string.IsNullOrEmpty(lastPanel.Text))
            {
                lastPanel.Text = count.ToString();
            }
            else
            {
                count = count + int.Parse(lastPanel.Text);
                lastPanel.Text = count.ToString();
            }
        }

        private static async Task _EnableSouthWest(IEnumerable<Button> board, Player player, int index)
        {
            var enemyColor = player.PlayerSide == Color.Black ? Color.White : Color.Black;

            var southWestPanels = await DirectionUtility.GetSouthWestPanels(board, index, enemyColor);
            int count = southWestPanels.Count();
            if (count == 0) return;

            var lastPanelIndex = int.Parse(southWestPanels.Last().Name) + 8;
            if (lastPanelIndex > 63) return;

            var modWest = (lastPanelIndex % 8) - 1;
            if (modWest < 0) return;
            else lastPanelIndex -= 1;

            var lastPanel = board.ElementAt(lastPanelIndex);
            if (lastPanel.BackColor != Color.Lime) return;

            lastPanel.Enabled = true;
            lastPanel.ForeColor = player.PlayerSide;
            if (string.IsNullOrEmpty(lastPanel.Text))
            {
                lastPanel.Text = count.ToString();
            }
            else
            {
                count = count + int.Parse(lastPanel.Text);
                lastPanel.Text = count.ToString();
            }
        }

        private static async Task _EnableNorthWest(IEnumerable<Button> board, Player player, int index)
        {
            var enemyColor = player.PlayerSide == Color.Black ? Color.White : Color.Black;

            var northWestPanels = await DirectionUtility.GetNorthWestPanels(board, index, enemyColor);
            int count = northWestPanels.Count();
            if (count == 0) return;

            var lastPanelIndex = int.Parse(northWestPanels.Last().Name) - 8;
            if (lastPanelIndex < 0) return;

            var modWest = (lastPanelIndex % 8) - 1;
            if (modWest < 0) return;
            else lastPanelIndex -= 1;

            var lastPanel = board.ElementAt(lastPanelIndex);
            if (lastPanel.BackColor != Color.Lime) return;

            lastPanel.Enabled = true;
            lastPanel.ForeColor = player.PlayerSide;
            if (string.IsNullOrEmpty(lastPanel.Text))
            {
                lastPanel.Text = count.ToString();
            }
            else
            {
                count = count + int.Parse(lastPanel.Text);
                lastPanel.Text = count.ToString();
            }
        }
        #endregion
    }
}
