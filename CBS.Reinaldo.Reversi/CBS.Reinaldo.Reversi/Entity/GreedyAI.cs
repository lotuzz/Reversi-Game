using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CBS.Reinaldo.Reversi.Entity
{
    public class GreedyAI : Player
    {
        public GreedyAI(Player player)
        {
            AcquiredPanels = player.AcquiredPanels;
            PlayerSide = player.PlayerSide;
        }

        public async Task AutoMove(IEnumerable<Button> board)
        {
            Button maxPanel = new Button()
            {
                Text = "0"
            };
            foreach(var panel in board)
            {
                var maxPanelCount = int.Parse(maxPanel.Text);
                int panelCount;
                try
                {
                    panelCount = int.Parse(panel.Text);
                }
                catch
                {
                    continue;
                }

                if (panelCount >= maxPanelCount) maxPanel = panel;
            }

            //await Task.Delay(2000);
            if (maxPanel != null)
            {
                maxPanel.Enabled = true;
                maxPanel.PerformClick();
            }
            return;
        }
    }
}
