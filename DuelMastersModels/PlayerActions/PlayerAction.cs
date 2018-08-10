namespace DuelMastersModels.PlayerActions
{
    /// <summary>
    /// Represents an action a player must perform.
    /// </summary>
    public abstract class PlayerAction
    {
        /// <summary>
        /// Player performing the action.
        /// </summary>
        public Player Player { get; private set; }

        protected PlayerAction(Player player)
        {
            Player = player;
        }

        /// <summary>
        /// Performs the action.
        /// </summary>
        public abstract void Perform(Duel duel);
    }
}
