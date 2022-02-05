using System;
using System.Collections.Generic;

namespace Common.Choices
{
    public class UseCardSelection : GuidSelection
    {
        public UseCardSelection()
        {
        }

        public UseCardSelection(Guid player, IEnumerable<Card> options) : base(player, options, 0, 1)
        {
        }

        public override string ToString()
        {
            return "You may use a card from your hand.";
        }
    }
}
