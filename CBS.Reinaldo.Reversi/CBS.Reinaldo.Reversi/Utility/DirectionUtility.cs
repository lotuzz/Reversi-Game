using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CBS.Reinaldo.Reversi.Utility
{
    public static class DirectionUtility
    {
        public static async Task<IEnumerable<Button>> GetNorthPanels(IEnumerable<Button> board, int startIndex, Color enemyColor)
        {
            Color playerColor = enemyColor == Color.Black ? Color.White : Color.Black;

            List<Button> result = new List<Button>();
            var index = startIndex - 8;
            if (index < 0) return result;

            Button panel = board.ElementAt(index);
            while ((panel.BackColor == enemyColor) && (index >= 0))
            {
                result.Add(panel);

                index -= 8;
                if (index < 0) return new List<Button>();
                panel = board.ElementAt(index);
            }
            
            return result;
        }

        public static async Task<IEnumerable<Button>> GetSouthPanels(IEnumerable<Button> board, int startIndex, Color enemyColor)
        {
            Color playerColor = enemyColor == Color.Black ? Color.White : Color.Black;

            List<Button> result = new List<Button>();
            var index = startIndex + 8;
            if (index > 63) return result;

            Button panel = board.ElementAt(index);
            while ((panel.BackColor == enemyColor) && (index <= 63))
            {
                result.Add(panel);

                index += 8;
                if (index > 63) return new List<Button>();
                panel = board.ElementAt(index);
            }
            
            return result;
        }

        public static async Task<IEnumerable<Button>> GetEastPanels(IEnumerable<Button> board, int startIndex, Color enemyColor)
        {
            Color playerColor = enemyColor == Color.Black ? Color.White : Color.Black;

            List<Button> result = new List<Button>();
            var index = startIndex;
            var mod = (index % 8) + 1;
            if (mod > 7) return result;

            index += 1;
            Button panel = board.ElementAt(index);
            while ((panel.BackColor == enemyColor) && (mod <= 7))
            {
                result.Add(panel);

                mod += 1;
                if (mod > 7) return new List<Button>();
                index += 1;
                panel = board.ElementAt(index);
            }
            
            return result;
        }

        public static async Task<IEnumerable<Button>> GetWestPanels(IEnumerable<Button> board, int startIndex, Color enemyColor)
        {
            Color playerColor = enemyColor == Color.Black ? Color.White : Color.Black;

            List<Button> result = new List<Button>();
            var index = startIndex;
            var mod = (index % 8) - 1;
            if (mod < 0) return result;

            index -= 1;
            Button panel = board.ElementAt(index);
            while ((panel.BackColor == enemyColor) && (mod >= 0))
            {
                result.Add(panel);

                mod -= 1;
                if (mod < 0) return new List<Button>();
                index -= 1;
                panel = board.ElementAt(index);
            }
            
            return result;
        }

        public static async Task<IEnumerable<Button>> GetNorthEastPanels(IEnumerable<Button> board, int startIndex, Color enemyColor)
        {
            Color playerColor = enemyColor == Color.Black ? Color.White : Color.Black;

            List<Button> result = new List<Button>();

            //check North
            var northEastIndex = startIndex - 8;
            if (northEastIndex < 0) return result;

            //check East
            var eastMod = (northEastIndex % 8) + 1;
            if (eastMod > 7) return result;
            else northEastIndex += 1;

            Button panel = board.ElementAt(northEastIndex);
            while ((panel.BackColor == enemyColor) && (northEastIndex >= 0))
            {
                result.Add(panel);

                northEastIndex -= 8;
                if (northEastIndex < 0) return new List<Button>();

                eastMod = (northEastIndex % 8) + 1;
                if (eastMod > 7) return new List<Button>();
                else northEastIndex += 1;

                panel = board.ElementAt(northEastIndex);
            }
            
            return result;
        }

        public static async Task<IEnumerable<Button>> GetNorthWestPanels(IEnumerable<Button> board, int startIndex, Color enemyColor)
        {
            Color playerColor = enemyColor == Color.Black ? Color.White : Color.Black;

            List<Button> result = new List<Button>();

            //check North
            var northWestIndex = startIndex - 8;
            if (northWestIndex < 0) return result;

            //check West
            var westMod = (northWestIndex % 8) - 1;
            if (westMod < 0) return result;
            else northWestIndex -= 1;

            Button panel = board.ElementAt(northWestIndex);
            while ((panel.BackColor == enemyColor) && (northWestIndex >= 0))
            {
                result.Add(panel);

                northWestIndex -= 8;
                if (northWestIndex < 0) return new List<Button>();

                westMod = (northWestIndex % 8) - 1;
                if (westMod < 0) return new List<Button>();
                else northWestIndex -= 1;

                panel = board.ElementAt(northWestIndex);
            }
            
            return result;
        }

        public static async Task<IEnumerable<Button>> GetSouthEastPanels(IEnumerable<Button> board, int startIndex, Color enemyColor)
        {
            Color playerColor = enemyColor == Color.Black ? Color.White : Color.Black;

            List<Button> result = new List<Button>();

            //check South
            var southEastIndex = startIndex + 8;
            if (southEastIndex > 63) return result;

            //check East
            var westMod = (southEastIndex % 8) + 1;
            if (westMod > 7) return result;
            else southEastIndex += 1;

            Button panel = board.ElementAt(southEastIndex);
            while ((panel.BackColor == enemyColor) && (southEastIndex >= 0))
            {
                result.Add(panel);

                southEastIndex += 8;
                if (southEastIndex > 63) return new List<Button>();

                westMod = (southEastIndex % 8) + 1;
                if (westMod > 7) return new List<Button>();
                else southEastIndex += 1;

                panel = board.ElementAt(southEastIndex);
            }

            
            return result;
        }

        public static async Task<IEnumerable<Button>> GetSouthWestPanels(IEnumerable<Button> board, int startIndex, Color enemyColor)
        {
            Color playerColor = enemyColor == Color.Black ? Color.White : Color.Black;

            List<Button> result = new List<Button>();

            //check South
            var southWestIndex = startIndex + 8;
            if (southWestIndex > 63) return result;

            //check West
            var westMod = (southWestIndex % 8) - 1;
            if (westMod < 0) return result;
            else southWestIndex -= 1;

            Button panel = board.ElementAt(southWestIndex);
            while ((panel.BackColor == enemyColor) && (southWestIndex >= 0))
            {
                result.Add(panel);

                southWestIndex += 8;
                if (southWestIndex > 63) return new List<Button>();

                westMod = (southWestIndex % 8) - 1;
                if (westMod < 0) return new List<Button>();
                else southWestIndex -= 1;

                panel = board.ElementAt(southWestIndex);
            }
            
            return result;
        }
    }
}
