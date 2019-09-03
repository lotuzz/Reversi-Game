using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CBS.Reinaldo.Reversi.Entity
{
    public class Player
    {
        public List<int> AcquiredPanels { get; } = new List<int>();
        public Color PlayerSide { get; set; }

        public void AcquirePanel(Button panel, Player enemy = null)
        {
            int item = int.Parse(panel.Name);
            if (enemy != null)
            {
                var remove = enemy.RemovePanel(item);
                if (!remove) throw new System.Exception($"Fail remove item from {enemy.PlayerSide.Name.ToString()} Player");
            }
            AcquiredPanels.Add(item);
            panel.BackColor = PlayerSide;
        }
        
        public bool RemovePanel(int item)
        {
            return AcquiredPanels.Remove(item);
        }
    }
}
