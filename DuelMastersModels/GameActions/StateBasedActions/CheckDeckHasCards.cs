namespace DuelMastersModels.GameActions.StateBasedActions
{
    /// <summary>
    /// 703.4b If a player has no cards left in their deck, that player loses the game.
    /// </summary>
    public class CheckDeckHasCards : StateBasedAction
    {
        private bool _deck1Empty = false;
        private bool _deck2Empty = false;

        public override string Message(Duel duel)
        {
            if (duel == null)
            {
                throw new System.ArgumentNullException("duel");
            }
            else if (_deck1Empty)
            {
                return Helper(duel.Player1.Name);
            }
            else if (_deck2Empty)
            {
                return Helper(duel.Player2.Name);
            }
            else
            {
                return null;
            }
        }

        private static string Helper(string name)
        {
            return string.Format(System.Globalization.CultureInfo.InvariantCulture, "{0} loses as they have no cards left in their deck.", name);
        }

        public override void Perform(Duel duel)
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
