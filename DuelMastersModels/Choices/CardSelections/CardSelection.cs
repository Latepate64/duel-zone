using System.Collections.Generic;
using System.Linq;

namespace DuelMastersModels.Choices.CardSelections
{
    /// <summary>
    /// Player selects cards.
    /// </summary>
    public class CardSelection<T> : Choice
    {
        /// <summary>
        /// Cards player can select from.
        /// </summary>
        public IEnumerable<T> Cards { get; private set; }

        public IEnumerable<T> SelectedCards { get; set; }

        internal int MinimumSelection { get; set; }

        internal int MaximumSelection { get; set; }

        internal CardSelection(Player player, IEnumerable<T> cards, int minimumSelection = 0, int maximumSelection = 1) : base(player)
        {
            MinimumSelection = minimumSelection;
            MaximumSelection = maximumSelection;
            Cards = cards;
            if (cards.Count() <= minimumSelection)
            {
                SelectedCards = cards;
            }
        }
    }
}
