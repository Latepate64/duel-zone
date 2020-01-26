using DuelMastersModels.Cards;
using System.Collections.Generic;

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
        public IEnumerable<TCard> Cards { get; private set; }

        internal int MinimumSelection { get; set; }

        internal int MaximumSelection { get; set; }

        internal CardSelection(Player player, IEnumerable<TCard> cards, int minimumSelection, int maximumSelection) : base(player)
        {
            MinimumSelection = minimumSelection;
            MaximumSelection = maximumSelection;
            Cards = cards;
        }
    }
}
