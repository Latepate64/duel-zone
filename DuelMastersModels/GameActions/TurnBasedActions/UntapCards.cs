namespace DuelMastersModels.GameActions.TurnBasedActions
{
    internal class UntapCards : TurnBasedAction
    {
        internal override void Perform(IDuel duel)
        {
            foreach (Cards.BattleZoneCreature creature in duel.TurnManager.CurrentTurn.ActivePlayer.BattleZone.Creatures)
            {
                creature.SummoningSickness = false;
            }
            duel.TurnManager.CurrentTurn.ActivePlayer.BattleZone.UntapCards();
            duel.TurnManager.CurrentTurn.ActivePlayer.ManaZone.UntapCards();
        }
    }
}