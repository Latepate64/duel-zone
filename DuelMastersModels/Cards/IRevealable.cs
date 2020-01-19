namespace DuelMastersModels.Cards
{
    /// <summary>
    /// Interface for card that may be revealed.
    /// </summary>
    public interface IRevealable
    {
        /// <summary>
        /// Determines whether the owner of the card knows what the card is.
        /// </summary>
        bool KnownToOwner { get; }

        /// <summary>
        /// Determines whether the opponent of the owner of the card knows what the card is.
        /// </summary>
        bool KnownToOpponent { get; }
    }
}
