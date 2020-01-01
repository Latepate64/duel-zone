namespace DuelMastersModels.GameActions.TurnBasedActions
{
    internal class DrawCardAtDrawStep : TurnBasedAction
    {
        internal override void Perform(Duel duel)
        {
            if (duel == null)
            {
                throw new System.ArgumentNullException("duel");
            }
            duel.DrawCard(duel.CurrentTurn.ActivePlayer);
        }
    }
}