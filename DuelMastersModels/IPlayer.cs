using DuelMastersModels.Cards;

namespace DuelMastersModels
{
    /// <summary>
    /// Interface for people playing Duel Masters.
    /// </summary>
    public interface IPlayer
    {
        /// <summary>
        /// The name of the player.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Represents the cards the player is going to use in a duel.
        /// </summary>
        ReadOnlyCardCollection<ICard> DeckBeforeDuel { get; }
    }
}
