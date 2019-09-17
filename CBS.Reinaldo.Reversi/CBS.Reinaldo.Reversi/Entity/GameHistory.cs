using System;

namespace CBS.Reinaldo.Reversi.Entity
{
    public class GameHistory
    {
        public string White { get; set; }
        public string Black { get; set; }
        public DateTime DatePlayed { get; set; }
        public string Winner { get; set; }
    }
}
