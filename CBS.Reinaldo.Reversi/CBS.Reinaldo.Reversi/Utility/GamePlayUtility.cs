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

        /// <summary>
        /// Enable possible panels (if any)
        /// </summary>
        /// <param name="board"></param>
        /// <param name="currentTurn"></param>
        /// <returns>true if any possible panel, false if not any</returns>
        public static bool IsPossibleToMove(IEnumerable<Button> board, Player currentTurn)
        {
            var posiblePanels = BoardUtility.EnablePossiblePanel(board, currentTurn).Result;
            if(posiblePanels > 0)
            {
                return true;
            }

            return false;
        }
    }
}
