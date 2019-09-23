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
        public static void DisablePanelAndResetText(IEnumerable<Button> board)
        {
            foreach (var btn in board)
            {
                btn.Enabled = false;
                btn.Text = string.Empty;
            }
        }

        public static async Task<int> EnablePossiblePanel(IEnumerable<Button> board, Player player)
        {
            var count = 0;
            foreach (var panelIndex in player.AcquiredPanels)
            {
                if(await _EnableNorth(board, player, panelIndex)) count++;
                if(await _EnableNorthEast(board, player, panelIndex)) count++;
                if(await _EnableEast(board, player, panelIndex)) count++;
                if(await _EnableSouthEast(board, player, panelIndex)) count++;
                if(await _EnableSouth(board, player, panelIndex)) count++;
                if(await _EnableSouthWest(board, player, panelIndex)) count++;
                if(await _EnableWest(board, player, panelIndex)) count++;
            }
            return count;
        }

        public static async Task TryFlipEnemyDisks(IEnumerable<Button> board, Player player, Player enemy, int index)
        {
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

            return;
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
        private static async Task<bool> _EnableNorth(IEnumerable<Button> board, Player player, int index)
        {
            var enemyColor = player.PlayerSide == Color.Black ? Color.White : Color.Black;

            var northPanels = DirectionUtility.GetNorthPanels(board, index, enemyColor).Result;
            int count = northPanels.Count();
            if (count == 0) return false;

            var lastPanelIndex = int.Parse(northPanels.Last().Name) - 8;
            if (lastPanelIndex < 0) return false;

            var lastPanel = board.ElementAt(lastPanelIndex);
            if (lastPanel.BackColor != Color.Lime) return false;

            if (!(player is GreedyAI))
            {
                lastPanel.Enabled = true;
            }
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
            return true;
        }

        private static async Task<bool> _EnableSouth(IEnumerable<Button> board, Player player, int index)
        {
            var enemyColor = player.PlayerSide == Color.Black ? Color.White : Color.Black;

            var southPanels = DirectionUtility.GetSouthPanels(board, index, enemyColor).Result;
            int count = southPanels.Count();
            if (count == 0) return false;

            var lastPanelIndex = int.Parse(southPanels.Last().Name) + 8;
            if (lastPanelIndex > 63) return false;

            var lastPanel = board.ElementAt(lastPanelIndex);
            if (lastPanel.BackColor != Color.Lime) return false;

            if(!(player is GreedyAI)) lastPanel.Enabled = true;
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
            return true;
        }

        private static async Task<bool> _EnableEast(IEnumerable<Button> board, Player player, int index)
        {
            var enemyColor = player.PlayerSide == Color.Black ? Color.White : Color.Black;

            var eastPanels = DirectionUtility.GetEastPanels(board, index, enemyColor).Result;
            int count = eastPanels.Count();
            if (count == 0) return false;

            var lastPanelIndex = int.Parse(eastPanels.Last().Name);
            if ((lastPanelIndex % 8) + 1 > 7) return false;
            else lastPanelIndex += 1;

            var lastPanel = board.ElementAt(lastPanelIndex);
            if (lastPanel.BackColor != Color.Lime) return false;

            if(!(player is GreedyAI)) lastPanel.Enabled = true;
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
            return true;
        }

        private static async Task<bool> _EnableWest(IEnumerable<Button> board, Player player, int index)
        {
            var enemyColor = player.PlayerSide == Color.Black ? Color.White : Color.Black;

            var westPanels = DirectionUtility.GetWestPanels(board, index, enemyColor).Result;
            int count = westPanels.Count();
            if (count == 0) return false;

            var lastPanelIndex = int.Parse(westPanels.Last().Name);
            if ((lastPanelIndex % 8) - 1 > 7) return false;
            else lastPanelIndex -= 1;

            var lastPanel = board.ElementAt(lastPanelIndex);
            if (lastPanel.BackColor != Color.Lime) return false;

            if(!(player is GreedyAI)) lastPanel.Enabled = true;
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
            return true;
        }

        private static async Task<bool> _EnableNorthEast(IEnumerable<Button> board, Player player, int index)
        {
            var enemyColor = player.PlayerSide == Color.Black ? Color.White : Color.Black;

            var northEastPanels = DirectionUtility.GetNorthEastPanels(board, index, enemyColor).Result;
            int count = northEastPanels.Count();
            if (count == 0) return false;

            var lastPanelIndex = int.Parse(northEastPanels.Last().Name) - 8;
            if (lastPanelIndex < 0) return false;

            var modEast = (lastPanelIndex % 8) + 1;
            if (modEast > 7) return false;
            else lastPanelIndex += 1;

            var lastPanel = board.ElementAt(lastPanelIndex);
            if (lastPanel.BackColor != Color.Lime) return false;

            if(!(player is GreedyAI)) lastPanel.Enabled = true;
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
            return true;
        }

        private static async Task<bool> _EnableSouthEast(IEnumerable<Button> board, Player player, int index)
        {
            var enemyColor = player.PlayerSide == Color.Black ? Color.White : Color.Black;

            var southEastPanels = DirectionUtility.GetSouthEastPanels(board, index, enemyColor).Result;
            int count = southEastPanels.Count();
            if (count == 0) return false;

            var lastPanelIndex = int.Parse(southEastPanels.Last().Name) + 8;
            if (lastPanelIndex > 63) return false;

            var modEast = (lastPanelIndex % 8) + 1;
            if (modEast > 7) return false;
            else lastPanelIndex += 1;

            var lastPanel = board.ElementAt(lastPanelIndex);
            if (lastPanel.BackColor != Color.Lime) return false;

            if(!(player is GreedyAI)) lastPanel.Enabled = true;
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
            return true;
        }

        private static async Task<bool> _EnableSouthWest(IEnumerable<Button> board, Player player, int index)
        {
            var enemyColor = player.PlayerSide == Color.Black ? Color.White : Color.Black;

            var southWestPanels = DirectionUtility.GetSouthWestPanels(board, index, enemyColor).Result;
            int count = southWestPanels.Count();
            if (count == 0) return false;

            var lastPanelIndex = int.Parse(southWestPanels.Last().Name) + 8;
            if (lastPanelIndex > 63) return false;

            var modWest = (lastPanelIndex % 8) - 1;
            if (modWest < 0) return false;
            else lastPanelIndex -= 1;

            var lastPanel = board.ElementAt(lastPanelIndex);
            if (lastPanel.BackColor != Color.Lime) return false;

            if(!(player is GreedyAI)) lastPanel.Enabled = true;
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
            return true;
        }

        private static async Task<bool> _EnableNorthWest(IEnumerable<Button> board, Player player, int index)
        {
            var enemyColor = player.PlayerSide == Color.Black ? Color.White : Color.Black;

            var northWestPanels = DirectionUtility.GetNorthWestPanels(board, index, enemyColor).Result;
            int count = northWestPanels.Count();
            if (count == 0) return false;

            var lastPanelIndex = int.Parse(northWestPanels.Last().Name) - 8;
            if (lastPanelIndex < 0) return false;

            var modWest = (lastPanelIndex % 8) - 1;
            if (modWest < 0) return false;
            else lastPanelIndex -= 1;

            var lastPanel = board.ElementAt(lastPanelIndex);
            if (lastPanel.BackColor != Color.Lime) return false;

            if(!(player is GreedyAI)) lastPanel.Enabled = true;
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
            return true;
        }
        #endregion
    }
}
