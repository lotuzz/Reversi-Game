using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CBS.Reinaldo.Reversi.Utility
{
    public static class DirectionUtility
    {
        public static IEnumerable<Button> GetNorthPanels(IEnumerable<Button> board, int startIndex, Color enemyColor)
        {
            var index = startIndex - 8;
            while (index >= 0)
            {
                var panel = board.ElementAt(index);
                if (panel.BackColor != enemyColor) break;
                yield return panel;

                index -= 8;
            }
        }

        public static IEnumerable<Button> GetSouthPanels(IEnumerable<Button> board, int startIndex, Color enemyColor)
        {
            var index = startIndex + 8;
            while (index <= 63)
            {
                var panel = board.ElementAt(index);
                if (panel.BackColor != enemyColor) break;
                yield return panel;

                index += 8;
            }
        }

        public static IEnumerable<Button> GetEastPanels(IEnumerable<Button> board, int startIndex, Color enemyColor)
        {
            var index = startIndex;
            var mod = (index % 8) + 1;
            while (mod <= 7)
            {
                index += 1;

                var panel = board.ElementAt(index);
                if (panel.BackColor != enemyColor) break;
                yield return panel;

                mod += 1;
            }
        }

        public static IEnumerable<Button> GetWestPanels(IEnumerable<Button> board, int startIndex, Color enemyColor)
        {
            var index = startIndex;
            var mod = (index % 8) - 1;
            while (mod >= 0)
            {
                index -= 1;

                var panel = board.ElementAt(index);
                if (panel.BackColor != enemyColor) break;
                yield return panel;

                mod -= 1;
            }
        }

        public static IEnumerable<Button> GetNorthEastPanels(IEnumerable<Button> board, int startIndex, Color enemyColor)
        {
            //check East
            var northEastIndex = startIndex;
            var eastMod = (northEastIndex % 8) + 1;
            if (eastMod <= 7)
            {
                //move east
                northEastIndex += 1;

                //move north
                northEastIndex -= 8;
                while (northEastIndex >= 0)
                {
                    var northEastPanel = board.ElementAt(northEastIndex);
                    if (northEastPanel.BackColor != enemyColor) break;
                    yield return northEastPanel;

                    eastMod = (northEastIndex % 8) + 1;
                    if (eastMod > 7) break;
                    northEastIndex -= 7;
                }
            }
        }

        public static IEnumerable<Button> GetNorthWestPanels(IEnumerable<Button> board, int startIndex, Color enemyColor)
        {
            //check West
            var northWestIndex = startIndex;
            var westMod = (northWestIndex % 8) - 1;
            if (westMod <= 7)
            {
                //move west
                northWestIndex -= 1;

                //move north
                northWestIndex -= 8;
                while (northWestIndex >= 0)
                {
                    var northWestPanel = board.ElementAt(northWestIndex);
                    if (northWestPanel.BackColor != enemyColor) break;
                    yield return northWestPanel;

                    westMod = (northWestIndex % 8) - 1;
                    if (westMod > 7) break;
                    northWestIndex -= 9;
                }
            }
        }

        public static IEnumerable<Button> GetSouthEastPanels(IEnumerable<Button> board, int startIndex, Color enemyColor)
        {
            //check East
            var southEastIndex = startIndex;
            var eastMod = (southEastIndex % 8) + 1;
            if (eastMod <= 7)
            {
                //move east
                southEastIndex += 1;

                //move south
                southEastIndex += 8;
                while (southEastIndex <= 63)
                {
                    var southEastPanel = board.ElementAt(southEastIndex);
                    if (southEastPanel.BackColor != enemyColor) break;
                    yield return southEastPanel;

                    eastMod = (southEastIndex % 8) + 1;
                    if (eastMod > 7) break;
                    southEastIndex -= 9;
                }
            }
        }

        public static IEnumerable<Button> GetSouthWestPanels(IEnumerable<Button> board, int startIndex, Color enemyColor)
        {
            //check West
            var southWestIndex = startIndex;
            var westMod = (southWestIndex % 8) - 1;
            if (westMod >= 0)
            {
                //move west
                southWestIndex -= 1;

                //move south
                southWestIndex += 8;
                while (southWestIndex <=63)
                {
                    var southWestPanel = board.ElementAt(southWestIndex);
                    if (southWestPanel.BackColor != enemyColor) break;
                    yield return southWestPanel;

                    westMod = (southWestIndex % 8) - 1;
                    if (westMod < 0) break;
                    southWestIndex += 7;
                }
            }
        }
    }
}
