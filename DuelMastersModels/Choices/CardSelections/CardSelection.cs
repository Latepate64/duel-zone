using DuelMastersModels.Cards;
using System.Collections.Generic;

namespace DuelMastersModels.Choices.CardSelections
{
    /// <summary>
    /// Player selects cards.
    /// </summary>
    public abstract class CardSelection<TCard> : Choice where TCard : ICard
    {
        /// <summary>
        /// Cards player can select from.
        /// </summary>
        public IEnumerable<TCard> Cards { get; private set; }

        internal int MinimumSelection { get; set; }

        internal int MaximumSelection { get; set; }

        internal CardSelection(IPlayer player, IEnumerable<TCard> cards, int minimumSelection, int maximumSelection) : base(player)
        {
            MinimumSelection = minimumSelection;
            MaximumSelection = maximumSelection;
            Cards = cards;
        }
    }
}
