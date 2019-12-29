namespace DuelMastersModels.PlayerActions.OptionalActions
{
    public abstract class OptionalAction : PlayerAction
    {
        protected OptionalAction(Player player) : base(player) { }

        internal override PlayerAction TryToPerformAutomatically(Duel duel)
        {
            return this;
        }

        public abstract PlayerAction Perform(Duel duel, bool takeAction);
    }
}
