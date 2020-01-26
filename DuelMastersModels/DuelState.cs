namespace DuelMastersModels
{
    /// <summary>
    /// Represents the state of a duel.
    /// </summary>
    public enum DuelState
    {
        /// <summary>
        /// Duel has not started yet.
        /// </summary>
        Setup,

        /// <summary>
        /// Duel is in progress.
        /// </summary>
        InProgress,

        /// <summary>
        /// Duel is over.
        /// </summary>
        Over,
    }
}
