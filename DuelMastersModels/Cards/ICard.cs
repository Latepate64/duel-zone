using System.Collections.Generic;

namespace DuelMastersModels.Cards
{
    /// <summary>
    /// Interface for Duel Masters cards.
    /// </summary>
    public interface ICard
    {
        /// <summary>
        /// Civilizations of the card.
        /// </summary>
        IEnumerable<Civilization> Civilizations { get; }

        /// <summary>
        /// Mana cost of the card.
        /// </summary>
        int Cost { get; }
    }
}
