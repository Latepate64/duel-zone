namespace DuelMastersModels
{
    /// <summary>
    /// Specifies the player who goes first in the duel.
    /// </summary>
    public enum StartingPlayerMethod
    {
        /// <summary>
        /// Player who goes first is randomized.
        /// </summary>
        Random = 0,

        /// <summary>
        /// Player 1 goes first.
        /// </summary>
        Player1 = 1,

        /// <summary>
        /// Player 2 goes first.
        /// </summary>
        Player2 = 2,
    }
}
