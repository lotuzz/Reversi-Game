using System.Collections.Generic;
using System.Drawing;

namespace CBS.Reinaldo.Reversi.Entity
{
    public class Player
    {
        public List<int> AcquiredPanels { get; set; } = new List<int>();
        public Color PlayerSide { get; set; }
    }
}
