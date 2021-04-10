namespace DuelMastersModels.PlayerActions.OptionalActions
{
    /// <summary>
    /// An action player is allowed to take.
    /// </summary>
    public abstract class OptionalAction : PlayerAction
    {
        internal OptionalAction(IPlayer player) : base(player) { }

        internal override PlayerAction TryToPerformAutomatically(IDuel duel)
        {
            return this;
        }

        internal abstract PlayerAction Perform(IDuel duel, bool takeAction);
    }
}
