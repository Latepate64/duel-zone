namespace DuelMastersModels.PlayerActions.AutomaticActions
{
    public abstract class AutomaticAction : PlayerAction
    {
        protected AutomaticAction(Player player) : base(player) { }

        public override PlayerAction TryToPerformAutomatically(Duel duel)
        {
            PlayerAction newAction = Perform(duel);
            duel.CurrentTurn.CurrentStep.PlayerActions.Add(this);
            return newAction;
        }

        public abstract PlayerAction Perform(Duel duel);
    }
}
