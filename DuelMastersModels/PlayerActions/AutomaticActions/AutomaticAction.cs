namespace DuelMastersModels.PlayerActions.AutomaticActions
{
    internal abstract class AutomaticAction : PlayerAction
    {
        protected AutomaticAction(IPlayer player) : base(player) { }

        internal override PlayerAction TryToPerformAutomatically(Duel duel)
        {
            PlayerAction newAction = Perform(duel);
            return newAction;
        }

        internal abstract PlayerAction Perform(Duel duel);
    }
}
