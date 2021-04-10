namespace DuelMastersModels.PlayerActions.AutomaticActions
{
    internal abstract class AutomaticAction : PlayerAction
    {
        protected AutomaticAction(IPlayer player) : base(player) { }

        public override IPlayerAction TryToPerformAutomatically(IDuel duel)
        {
            IPlayerAction newAction = Perform(duel);
            return newAction;
        }

        internal abstract IPlayerAction Perform(IDuel duel);
    }
}
