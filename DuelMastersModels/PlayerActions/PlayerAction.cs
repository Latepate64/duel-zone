namespace DuelMastersModels.PlayerActions
{
    /// <summary>
    /// Represents an action a player must perform.
    /// </summary>
    public abstract class PlayerAction : IPlayerAction
    {
        /// <summary>
        /// Player performing the action.
        /// </summary>
        public Player Player { get; private set; }

        /// <summary>
        /// Creates a player action.
        /// </summary>
        /// <param name="player">Player who will perform the action.</param>
        protected PlayerAction(Player player)
        {
            Player = player;
        }

        /// <summary>
        /// Tries to perform the player action automatically if possible. Returns the player action itself if it is not possible to perform action automatically, otherwise returns new player action based on what happened during the automatic performance (may return null, in that case the performance does not require further player actions).
        /// </summary>
        /// <param name="duel"></param>
        /// <returns></returns>
        internal abstract PlayerAction TryToPerformAutomatically(Duel duel);

        /*
        /// <summary>
        /// Text representation of the player action.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Action for player {Player.Name}.";
        }
        */
    }
}