using CBS.Reinaldo.Reversi.Entity;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace CBS.Reinaldo.Reversi.DataRepository
{
    public class OthelloRepository
    {
        private string _Directory { get; set; } = "DataRepository/OthelloGameData.json";
        private List<GameHistory> _GameHistories { get; set; } = new List<GameHistory>();

        public OthelloRepository ()
        {
            using (StreamReader reader = new StreamReader(_Directory))
            {
                string json = reader.ReadToEnd();
                _GameHistories = JsonConvert.DeserializeObject<List<GameHistory>>(json);
            }
        }

        public List<GameHistory> GetAll()
        {
            return _GameHistories;
        }

        public void Insert(GameHistory history)
        {
            _GameHistories.Add(history);
            if(_GameHistories.Count > 5)
            {
                _GameHistories.RemoveAt(0);
            }
        }

        public void SaveChanges()
        {
            var json = JsonConvert.SerializeObject(_GameHistories, Formatting.Indented);
            File.WriteAllText(_Directory, json);
        }
    }
}
