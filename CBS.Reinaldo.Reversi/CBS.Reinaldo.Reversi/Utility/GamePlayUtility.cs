using CBS.Reinaldo.Reversi.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CBS.Reinaldo.Reversi.Utility
{
    public static class GamePlayUtility
    {
        public static void MakeMove(Player currentPlayer, Control btn)
        {
            btn.BackColor = currentPlayer.PlayerSide;
            currentPlayer.AcquirePanel((Button)btn);
        }

        public static async Task<bool> IsPossibleToMove(IEnumerable<Button> board, Player currentTurn)
        {
            await BoardUtility.EnablePossiblePanel(board, currentTurn);
            foreach (var panel in board)
            {
                if (int.TryParse(panel.Text, out var count) && panel.ForeColor == currentTurn.PlayerSide)
                {
                    return true;
                }
            }

            BoardUtility.DisablePanelAndResetText(board);
            return false;
        }
    }
}
