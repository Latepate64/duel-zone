namespace DuelMastersModels.PlayerActions.OptionalActions
{
    /// <summary>
    /// An action player is allowed to take.
    /// </summary>
    public abstract class OptionalAction : PlayerAction
    {
        internal OptionalAction(IPlayer player) : base(player) { }

        public override IPlayerAction TryToPerformAutomatically(IDuel duel)
        {
            return this;
        }

        internal abstract IPlayerAction Perform(IDuel duel, bool takeAction);
    }
}
