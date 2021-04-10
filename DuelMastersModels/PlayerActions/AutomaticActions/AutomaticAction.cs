namespace DuelMastersModels.PlayerActions.AutomaticActions
{
    internal abstract class AutomaticAction : PlayerAction
    {
        protected AutomaticAction(IPlayer player) : base(player) { }

        internal override PlayerAction TryToPerformAutomatically(IDuel duel)
        {
            PlayerAction newAction = Perform(duel);
            return newAction;
        }

        internal abstract PlayerAction Perform(IDuel duel);
    }
}
