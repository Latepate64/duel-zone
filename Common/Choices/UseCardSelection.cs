using System;
using System.Collections.Generic;

namespace Common.Choices
{
    public class UseCardSelection : BoundedCardSelection
    {
        public UseCardSelection()
        {
        }

        public UseCardSelection(Guid player, IEnumerable<ICard> options) : base(player, options, 0, 1)
        {
        }

        public override string ToString()
        {
            return "You may use a card from your hand.";
        }
    }
}
