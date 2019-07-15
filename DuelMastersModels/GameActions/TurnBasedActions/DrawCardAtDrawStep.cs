namespace DuelMastersModels.GameActions.TurnBasedActions
{
    public class DrawCardAtDrawStep : TurnBasedAction
    {
        public override void Perform(Duel duel)
        {
            if (duel == null)
            {
                throw new System.ArgumentNullException("duel");
            }
            duel.DrawCard(duel.CurrentTurn.ActivePlayer);
        }
    }
}