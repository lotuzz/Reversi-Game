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
            int count = 0;
            var enemyColor = player.PlayerSide == Color.Black ? Color.White : Color.Black;

            Button currentBtn = board.ElementAt(index);

            //north
            index -= 8;
            while(index >= 0)
            {
                currentBtn = board.ElementAt(index);
                if (currentBtn.BackColor != enemyColor) break;

                count++;
                index = index - 8;
            }

            if((currentBtn.BackColor == Color.Lime) && (index >= 0) && (count > 0))
            {
                currentBtn.Enabled = true;
                currentBtn.ForeColor = player.PlayerSide;

                if (int.TryParse(currentBtn.Text, out int btnCount))
                {
                    btnCount += count;
                    currentBtn.Text = btnCount.ToString();
                }
                else
                {
                    currentBtn.Text = count.ToString();
                }
            }
        }

        public static void EnableSouth(IEnumerable<Button> board, Player player, int index)
        {
            int count = 0;
            var enemyColor = player.PlayerSide == Color.Black ? Color.White : Color.Black;

            Button currentBtn = board.ElementAt(index);

            //south
            index += 8;
            while (index <= 63)
            {
                currentBtn = board.ElementAt(index);
                if (currentBtn.BackColor != enemyColor) break;

                count++;
                index += 8;
            }

            if ((currentBtn.BackColor == Color.Lime) && (index <= 63) && (count > 0))
            {
                currentBtn.Enabled = true;
                currentBtn.ForeColor = player.PlayerSide;

                if (int.TryParse(currentBtn.Text, out int btnCount))
                {
                    btnCount += count;
                    currentBtn.Text = btnCount.ToString();
                }
                else
                {
                    currentBtn.Text = count.ToString();
                }
            }
        }

        public static void EnableEast(IEnumerable<Button> board, Player player, int index)
        {
            int count = 0;
            var enemyColor = player.PlayerSide == Color.Black ? Color.White : Color.Black;

            Button currentBtn = board.ElementAt(index);

            //south
            var mod = (index % 8) + 1;
            while (mod <= 7)
            {
                index += 1;
                currentBtn = board.ElementAt(index);
                if (currentBtn.BackColor != enemyColor) break;

                count++;
                mod += 1;
            }

            if ((currentBtn.BackColor == Color.Lime) && (mod <= 7) && (count > 0))
            {
                currentBtn.Enabled = true;
                currentBtn.ForeColor = player.PlayerSide;

                if (int.TryParse(currentBtn.Text, out int btnCount))
                {
                    btnCount += count;
                    currentBtn.Text = btnCount.ToString();
                }
                else
                {
                    currentBtn.Text = count.ToString();
                }
            }
        }

        public static void EnableWest(IEnumerable<Button> board, Player player, int index)
        {
            int count = 0;
            var enemyColor = player.PlayerSide == Color.Black ? Color.White : Color.Black;

            Button currentBtn = board.ElementAt(index);

            //south
            var mod = (index % 8) - 1;
            while (mod >= 0)
            {
                index -= 1;
                currentBtn = board.ElementAt(index);
                if (currentBtn.BackColor != enemyColor) break;

                count++;
                mod -= 1;
            }

            if ((currentBtn.BackColor == Color.Lime) && (mod <= 7) && (count > 0))
            {
                currentBtn.Enabled = true;
                currentBtn.ForeColor = player.PlayerSide;

                if (int.TryParse(currentBtn.Text, out int btnCount))
                {
                    btnCount += count;
                    currentBtn.Text = btnCount.ToString();
                }
                else
                {
                    currentBtn.Text = count.ToString();
                }
            }
        }

        public static void EnableNorthEast(IEnumerable<Button> board, Player player, int index)
        {
            int count = 0;
            var enemyColor = player.PlayerSide == Color.Black ? Color.White : Color.Black;

            Button currentBtn = board.ElementAt(index);

            //Move East then move north
            //Move East
            var mod = (index % 8) + 1;
            if (mod > 7) return;
            else index += 1;

            //Move North
            index -= 8;
            
            while (index >= 0)
            {
                currentBtn = board.ElementAt(index);
                if (currentBtn.BackColor != enemyColor) break;

                count++;
                mod = (index % 8) + 1;
                if (mod > 7) break;
                else index -= 7;
            }

            if ((currentBtn.BackColor == Color.Lime) && (mod <= 7) && (index >= 0) && (count > 0))
            {
                currentBtn.Enabled = true;
                currentBtn.ForeColor = player.PlayerSide;

                if (int.TryParse(currentBtn.Text, out int btnCount))
                {
                    btnCount += count;
                    currentBtn.Text = btnCount.ToString();
                }
                else
                {
                    currentBtn.Text = count.ToString();
                }
            }
        }

        public static void EnableSouthEast(IEnumerable<Button> board, Player player, int index)
        {
            int count = 0;
            var enemyColor = player.PlayerSide == Color.Black ? Color.White : Color.Black;

            Button currentBtn = board.ElementAt(index);

            //Move East then move south
            //Move East
            var mod = (index % 8) + 1;
            if (mod > 7) return;
            else index += 1;

            //Move South
            index += 8;

            while (index <= 63)
            {
                currentBtn = board.ElementAt(index);
                if (currentBtn.BackColor != enemyColor) break;

                count++;
                mod = (index % 8) + 1;
                if (mod > 7) break;
                else index += 9;
            }

            if ((currentBtn.BackColor == Color.Lime) && (mod > 7) && (index <= 63) && (count > 0))
            {
                currentBtn.Enabled = true;
                currentBtn.ForeColor = player.PlayerSide;

                if (int.TryParse(currentBtn.Text, out int btnCount))
                {
                    btnCount += count;
                    currentBtn.Text = btnCount.ToString();
                }
                else
                {
                    currentBtn.Text = count.ToString();
                }
            }
        }

        public static void EnableSouthWest(IEnumerable<Button> board, Player player, int index)
        {
            int count = 0;
            var enemyColor = player.PlayerSide == Color.Black ? Color.White : Color.Black;

            Button currentBtn = board.ElementAt(index);

            //Move West then move south
            //Move West
            var mod = (index % 8) - 1;
            if (mod >= 0) return;
            else index -= 1;

            //Move South
            index += 8;

            while (index <= 63)
            {
                currentBtn = board.ElementAt(index);
                if (currentBtn.BackColor != enemyColor) break;

                count++;
                mod = (index % 8) - 1;
                if (mod >= 0) break;
                else index += 7;
            }

            if ((currentBtn.BackColor == Color.Lime) && (mod >= 0) && (index <= 63) && (count > 0))
            {
                currentBtn.Enabled = true;
                currentBtn.ForeColor = player.PlayerSide;

                if (int.TryParse(currentBtn.Text, out int btnCount))
                {
                    btnCount += count;
                    currentBtn.Text = btnCount.ToString();
                }
                else
                {
                    currentBtn.Text = count.ToString();
                }
            }
        }

        public static void EnableNorthWest(IEnumerable<Button> board, Player player, int index)
        {
            int count = 0;
            var enemyColor = player.PlayerSide == Color.Black ? Color.White : Color.Black;

            Button currentBtn = board.ElementAt(index);

            //Move West then move north
            //Move West
            var mod = (index % 8) - 1;
            if (mod >= 0) return;
            else index -= 1;

            //Move north
            index -= 8;

            while (index >= 0)
            {
                currentBtn = board.ElementAt(index);
                if (currentBtn.BackColor != enemyColor) break;

                count++;
                mod = (index % 8) - 1;
                if (mod >= 0) break;
                else index -= 9;
            }

            if ((currentBtn.BackColor == Color.Lime) && (mod >= 0) && (index >= 0) && (count > 0))
            {
                currentBtn.Enabled = true;
                currentBtn.ForeColor = player.PlayerSide;

                if (int.TryParse(currentBtn.Text, out int btnCount))
                {
                    btnCount += count;
                    currentBtn.Text = btnCount.ToString();
                }
                else
                {
                    currentBtn.Text = count.ToString();
                }
            }
        }

        public static void TryAcquiringPanels(IEnumerable<Button> board, Player player, Player enemy, int index)
        {
            var enemyColor = enemy.PlayerSide;

            //north
            var northIndex = index - 8;
            while (northIndex >= 0)
            {
                var northPanel = board.ElementAt(northIndex);
                if (northPanel.BackColor != enemyColor) break;
                northPanel.BackColor = player.PlayerSide;

                index = index - 8;
            }

            //east
            var eastIndex = index + 1;
            var eastMod = (index % 8) + 1;
            while (eastMod <= 7)
            {
                var eastPanel = board.ElementAt(eastIndex);
                if (eastPanel.BackColor != enemyColor) break;
                eastPanel.BackColor = player.PlayerSide;

                eastMod += 1;
            }
        }
    }
}
