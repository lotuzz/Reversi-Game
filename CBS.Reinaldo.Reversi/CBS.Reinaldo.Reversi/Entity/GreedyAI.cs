using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace CBS.Reinaldo.Reversi.Entity
{
    public class GreedyAI : Player
    {
        public void AutoMove(IEnumerable<Button> board)
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

            //Thread.Sleep(1000);
            if (maxPanel != null) maxPanel.PerformClick();
            return;
        }
    }
}
