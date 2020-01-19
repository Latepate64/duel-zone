using DuelMastersModels.Cards;

namespace DuelMastersModels.PlayerActions.CardSelections
{
    /// <summary>
    /// Player selects cards.
    /// </summary>
    public abstract class CardSelection<TZoneCard> : PlayerAction where TZoneCard : IZoneCard
    {
        /// <summary>
        /// Cards player can select from.
        /// </summary>
        public ReadOnlyCardCollection<TZoneCard> Cards { get; private set; }

        internal int MinimumSelection { get; set; }

        internal int MaximumSelection { get; set; }

        internal CardSelection(Player player, int minimumSelection, int maximumSelection, ReadOnlyCardCollection<TZoneCard> cards) : base(player)
        {
            MinimumSelection = minimumSelection;
            MaximumSelection = maximumSelection;
            Cards = cards;
        }
    }
}
