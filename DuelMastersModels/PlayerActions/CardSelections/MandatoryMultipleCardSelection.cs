﻿using DuelMastersModels.Cards;
using System.Collections.Generic;
using System.Linq;

namespace DuelMastersModels.PlayerActions.CardSelections
{
    /// <summary>
    /// Player must select a number of cards.
    /// </summary>
    public abstract class MandatoryMultipleCardSelection<TCard> : MultipleCardSelection<TCard> where TCard : ICard
    {
        internal MandatoryMultipleCardSelection(Player player, int amount, ReadOnlyCardCollection<TCard> cards) : base(player, cards, false, amount)
        {
        }

        internal override PlayerAction TryToPerformAutomatically(Duel duel)
        {
            return Cards.Count() <= MaximumSelection ? Perform(duel, Cards) : (this);
        }

        internal override void Validate(IEnumerable<TCard> cards)
        {
            if (!(cards.Count() == MinimumSelection && !cards.Except(Cards).Any()))
            {
                throw new Exceptions.MandatoryMultipleCardSelectionException(ToString());
            }
        }
    }
}
