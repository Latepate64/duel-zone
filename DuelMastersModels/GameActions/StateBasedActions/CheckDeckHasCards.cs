namespace DuelMastersModels.GameActions.StateBasedActions
{
    /// <summary>
    /// 703.4b If a player has no cards left in their deck, that player loses the game.
    /// </summary>
    internal class CheckDeckHasCards : StateBasedAction
    {
        internal override void Perform(Duel duel)
        {
            if (duel == null)
            {
                throw new System.ArgumentNullException("duel");
            }
            if (duel.Player1.Deck.Cards.Count == 0 && duel.Player2.Deck.Cards.Count == 0)
            {
                duel.EndDuelInDraw();
            }
            else if (duel.Player1.Deck.Cards.Count == 0)
            {
                duel.End(duel.Player2);
            }
            else if (duel.Player2.Deck.Cards.Count == 0)
            {
                duel.End(duel.Player1);
            }
        }
    }
}
