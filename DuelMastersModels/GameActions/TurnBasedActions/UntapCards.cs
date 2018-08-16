namespace DuelMastersModels.GameActions.TurnBasedActions
{
    public class UntapCards : TurnBasedAction
    {
        public override string Message(Duel duel)
        {
            if (duel == null)
            {
                throw new System.ArgumentNullException("duel");
            }
            return string.Format(System.Globalization.CultureInfo.InvariantCulture, "{0} untapped cards in their cards in battle zone and mana zone.", duel.CurrentTurn.CurrentStep.ActivePlayer.Name);
        }

        public override void Perform(Duel duel)
        {
            if (duel == null)
            {
                throw new System.ArgumentNullException("duel");
            }
            foreach (var creature in duel.CurrentTurn.ActivePlayer.BattleZone.Creatures)
            {
                creature.SummoningSickness = false;
            }
            duel.CurrentTurn.ActivePlayer.BattleZone.UntapCards();
            duel.CurrentTurn.ActivePlayer.ManaZone.UntapCards();
        }
    }
}