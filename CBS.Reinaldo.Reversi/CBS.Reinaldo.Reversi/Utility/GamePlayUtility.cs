using CBS.Reinaldo.Reversi.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public static bool IsPossibleToMove(IEnumerable<Button> board, Player currentTurn)
        {
            BoardUtility.EnablePossiblePanel(board, currentTurn);
            foreach (var panel in board)
            {
                if (int.TryParse(panel.Text, out var count) && panel.ForeColor == currentTurn.PlayerSide)
                {
                    BoardUtility.ResetPanelAccessAndText(board);
                    return true;
                }
            }

            BoardUtility.ResetPanelAccessAndText(board);
            return false;
        }
    }
}
