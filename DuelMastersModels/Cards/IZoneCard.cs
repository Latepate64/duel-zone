namespace DuelMastersModels.Cards
{
    public interface IZoneCard
    {
        /// <summary>
        /// Name of the card.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Set in which the card appears.
        /// </summary>
        string CardSet { get; }

        /// <summary>
        /// Collector's number of the card.
        /// </summary>
        string Id { get; }

        /// <summary>
        /// Civilizations of the card.
        /// </summary>
        ReadOnlyCivilizationCollection Civilizations { get; }

        /// <summary>
        /// Rarity of the card.
        /// </summary>
        Rarity Rarity { get; }

        /// <summary>
        /// Mana cost of the card.
        /// </summary>
        int Cost { get; }

        /// <summary>
        /// Text that defines the abilities of the card.
        /// </summary>
        string Text { get; }

        /// <summary>
        /// Flavor text of the card.
        /// </summary>
        string Flavor { get; }

        /// <summary>
        /// Illustrator of the card.
        /// </summary>
        string Illustrator { get; }
    }
}
