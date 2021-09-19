﻿using DuelMastersModels.Cards;
using System.Collections.Generic;

namespace DuelMastersModels.Choices.CardSelections
{
    /// <summary>
    /// Player selects cards.
    /// </summary>
    public abstract class CardSelection : Choice
    {
        /// <summary>
        /// Cards player can select from.
        /// </summary>
        public IEnumerable<Card> Cards { get; private set; }

        internal int MinimumSelection { get; set; }

        internal int MaximumSelection { get; set; }

        internal CardSelection(IPlayer player, IEnumerable<Card> cards, int minimumSelection, int maximumSelection) : base(player)
        {
            MinimumSelection = minimumSelection;
            MaximumSelection = maximumSelection;
            Cards = cards;
        }
    }
}
