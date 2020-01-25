using DuelMastersModels.Cards;

namespace DuelMastersModels.PlayerActions.CardSelections
{
    /// <summary>
    /// Player selects cards.
    /// </summary>
    public abstract class CardSelection<TCard> : PlayerAction where TCard : ICard
    {
        /// <summary>
        /// Cards player can select from.
        /// </summary>
        public ReadOnlyCardCollection<TCard> Cards { get; private set; }

        internal int MinimumSelection { get; set; }

        internal int MaximumSelection { get; set; }

        internal CardSelection(Player player, int minimumSelection, int maximumSelection, ReadOnlyCardCollection<TCard> cards) : base(player)
        {
            MinimumSelection = minimumSelection;
            MaximumSelection = maximumSelection;
            Cards = cards;
        }
    }
}
