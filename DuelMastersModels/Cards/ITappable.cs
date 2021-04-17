namespace DuelMastersModels.Cards
{
    /// <summary>
    /// Interface for cards that can be tapped or untapped.
    /// </summary>
    public interface ITappable
    {
        /// <summary>
        /// Determines whether the card is tapped or untapped.
        /// </summary>
        bool Tapped { get; set; }
    }
}
