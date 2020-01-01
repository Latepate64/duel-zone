namespace DuelMastersModels.PlayerActions.OptionalActions
{
    /// <summary>
    /// An action player is allowed to take.
    /// </summary>
    public abstract class OptionalAction : PlayerAction
    {
        internal OptionalAction(Player player) : base(player) { }

        internal override PlayerAction TryToPerformAutomatically(Duel duel)
        {
            return this;
        }

        internal abstract PlayerAction Perform(Duel duel, bool takeAction);
    }
}
