namespace DuelMastersModels.PlayerActions.AutomaticActions
{
    internal abstract class AutomaticAction : PlayerAction
    {
        protected AutomaticAction(Player player) : base(player) { }

        internal override PlayerAction TryToPerformAutomatically(Duel duel)
        {
            PlayerAction newAction = Perform(duel);
            duel.CurrentTurn.CurrentStep.PlayerActions.Add(this);
            return newAction;
        }

        internal abstract PlayerAction Perform(Duel duel);
    }
}
