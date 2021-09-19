﻿using DuelMastersModels.Cards;
using System.Collections.Generic;
using System.Linq;

namespace DuelMastersModels.Choices.CardSelections
{
    /// <summary>
    /// Player must select a card.
    /// </summary>
    public abstract class MandatoryCardSelection : SingleCardSelection
    {
        internal MandatoryCardSelection(IPlayer player, IEnumerable<Card> cards) : base(player, cards, false)
        { }

        internal override void Validate(Card card)
        {
            if (!Cards.Contains(card))
            {
                throw new Exceptions.MandatoryCardSelectionException(ToString());
            }
        }
    }
}