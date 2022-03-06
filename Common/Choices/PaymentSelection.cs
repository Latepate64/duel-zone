using System;
using System.Collections.Generic;

namespace Common.Choices
{
    public class PaymentSelection : BoundedCardSelection
    {
        public PaymentSelection()
        {
        }

        public PaymentSelection(Guid player, IEnumerable<Card> options, int minimumSelection, int maximumSelection) : base(player, options, minimumSelection, maximumSelection)
        {
        }

        public override string ToString()
        {
            return "Choose cards to pay the mana cost with.";
        }
    }
}
