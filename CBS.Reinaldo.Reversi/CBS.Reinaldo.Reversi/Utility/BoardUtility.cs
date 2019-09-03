using CBS.Reinaldo.Reversi.Entity;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Drawing;

namespace CBS.Reinaldo.Reversi.Utility
{
    public static class BoardUtility
    {
        public static void ResetPanelAccessAndText(IEnumerable<Button> board)
        {
            foreach(var btn in board)
            {
                btn.Enabled = false;
                btn.Text = "";
            }
        }

        public static void EnableNorth(IEnumerable<Button> board, Player player, int index)
        {
            var enemyColor = player.PlayerSide == Color.Black ? Color.White : Color.Black;
            
            var northPanels = DirectionUtility.GetNorthPanels(board, index, enemyColor);
            int count = northPanels.Count();
            if (count == 0) return;

            var lastPanelIndex = int.Parse(northPanels.Last().Name) - 8;
            var lastPanel = board.ElementAt(lastPanelIndex);
            lastPanel.Enabled = true;
            lastPanel.ForeColor = player.PlayerSide;
            if(string.IsNullOrEmpty(lastPanel.Text))
            {
                lastPanel.Text = count.ToString();
            }
            else
            {
                count = count + int.Parse(lastPanel.Text);
                lastPanel.Text = count.ToString();
            }
        }

        public static void EnableSouth(IEnumerable<Button> board, Player player, int index)
        {
            var enemyColor = player.PlayerSide == Color.Black ? Color.White : Color.Black;

            var southPanels = DirectionUtility.GetSouthPanels(board, index, enemyColor);
            int count = southPanels.Count();
            if (count == 0) return;

            var lastPanelIndex = int.Parse(southPanels.Last().Name) + 8;
            var lastPanel = board.ElementAt(lastPanelIndex);
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

        public static void EnableEast(IEnumerable<Button> board, Player player, int index)
        {
            var enemyColor = player.PlayerSide == Color.Black ? Color.White : Color.Black;

            var eastPanels = DirectionUtility.GetEastPanels(board, index, enemyColor);
            int count = eastPanels.Count();
            if (count == 0) return;

            var lastPanelIndex = int.Parse(eastPanels.Last().Name) + 1;
            var lastPanel = board.ElementAt(lastPanelIndex);
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

        public static void EnableWest(IEnumerable<Button> board, Player player, int index)
        {
            var enemyColor = player.PlayerSide == Color.Black ? Color.White : Color.Black;

            var westPanels = DirectionUtility.GetWestPanels(board, index, enemyColor);
            int count = westPanels.Count();
            if (count == 0) return;

            var lastPanelIndex = int.Parse(westPanels.Last().Name) - 1;
            var lastPanel = board.ElementAt(lastPanelIndex);
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

        public static void EnableNorthEast(IEnumerable<Button> board, Player player, int index)
        {
            var enemyColor = player.PlayerSide == Color.Black ? Color.White : Color.Black;

            var northEastPanels = DirectionUtility.GetNorthEastPanels(board, index, enemyColor);
            int count = northEastPanels.Count();
            if (count == 0) return;

            var lastPanelIndex = int.Parse(northEastPanels.Last().Name) + 1 - 8;
            var lastPanel = board.ElementAt(lastPanelIndex);
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

        public static void EnableSouthEast(IEnumerable<Button> board, Player player, int index)
        {
            var enemyColor = player.PlayerSide == Color.Black ? Color.White : Color.Black;

            var southEastPanels = DirectionUtility.GetSouthEastPanels(board, index, enemyColor);
            int count = southEastPanels.Count();
            if (count == 0) return;

            var lastPanelIndex = int.Parse(southEastPanels.Last().Name) + 1 + 8;
            var lastPanel = board.ElementAt(lastPanelIndex);
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

        public static void EnableSouthWest(IEnumerable<Button> board, Player player, int index)
        {
            var enemyColor = player.PlayerSide == Color.Black ? Color.White : Color.Black;

            var southWestPanels = DirectionUtility.GetSouthWestPanels(board, index, enemyColor);
            int count = southWestPanels.Count();
            if (count == 0) return;

            var lastPanelIndex = int.Parse(southWestPanels.Last().Name) - 1 + 8;
            var lastPanel = board.ElementAt(lastPanelIndex);
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

        public static void EnableNorthWest(IEnumerable<Button> board, Player player, int index)
        {
            var enemyColor = player.PlayerSide == Color.Black ? Color.White : Color.Black;

            var northWestPanels = DirectionUtility.GetNorthWestPanels(board, index, enemyColor);
            int count = northWestPanels.Count();
            if (count == 0) return;

            var lastPanelIndex = int.Parse(northWestPanels.Last().Name) - 1 - 8;
            var lastPanel = board.ElementAt(lastPanelIndex);
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

        public static void TryAcquiringPanels(IEnumerable<Button> board, Player player, Player enemy, int index)
        {
            var enemyColor = enemy.PlayerSide;
            bool isValid;

            //north
            var northPanels = DirectionUtility.GetNorthPanels(board, index, enemyColor);
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
            var eastPanels = DirectionUtility.GetEastPanels(board, index, enemyColor);
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
            var southPanels = DirectionUtility.GetSouthPanels(board, index, enemyColor);
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
            var westPanels = DirectionUtility.GetWestPanels(board, index, enemyColor);
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
            var northEasPanels = DirectionUtility.GetNorthEastPanels(board, index, enemyColor);
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
            var southEastPanels = DirectionUtility.GetSouthEastPanels(board, index, enemyColor);
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
            var southWestPanels = DirectionUtility.GetSouthWestPanels(board, index, enemyColor);
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
            var northWestPanels = DirectionUtility.GetNorthWestPanels(board, index, enemyColor);
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
    }
}
