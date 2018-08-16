namespace DuelMastersModels.GameActions.TurnBasedActions
{
    public class DrawCardAtDrawStep : TurnBasedAction
    {
        public override string Message(Duel duel)
        {
            if (duel == null)
            {
                throw new System.ArgumentNullException("duel");
            }
            return string.Format(System.Globalization.CultureInfo.InvariantCulture, "{0} drew a card.", duel.CurrentTurn.CurrentStep.ActivePlayer.Name);
        }

        public override void Perform(Duel duel)
        {
            if (duel == null)
            {
                throw new System.ArgumentNullException("duel");
            }
            Duel.DrawCard(duel.CurrentTurn.ActivePlayer);
        }
    }
}