namespace DuelMastersModels.GameActions.TurnBasedActions
{
    public class UntapCards : TurnBasedAction
    {
        public override void Perform(Duel duel)
        {
            if (duel == null)
            {
                throw new System.ArgumentNullException("duel");
            }
            duel.CurrentTurn.ActivePlayer.BattleZone.UntapCards();
            duel.CurrentTurn.ActivePlayer.ManaZone.UntapCards();
        }
    }
}