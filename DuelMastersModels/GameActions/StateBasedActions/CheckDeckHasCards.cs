using System.Linq;

namespace DuelMastersModels.GameActions.StateBasedActions
{
    /// <summary>
    /// 703.4b If a player has no cards left in their deck, that player loses the game.
    /// </summary>
    internal class CheckDeckHasCards : StateBasedAction
    {
        internal override void Perform(IDuel duel)
        {
            if (!duel.Player1.Deck.Cards.Any() && !duel.Player2.Deck.Cards.Any())
            {
                duel.EndDuelInDraw();
            }
            else if (!duel.Player1.Deck.Cards.Any())
            {
                duel.End(duel.Player2);
            }
            else if (!duel.Player2.Deck.Cards.Any())
            {
                duel.End(duel.Player1);
            }
        }
    }
}
