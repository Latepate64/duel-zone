using System;
using System.Collections.Generic;

namespace Common.Choices
{
    public class BlockerSelection : BoundedCardSelection
    {
        public BlockerSelection()
        {
        }

        public BlockerSelection(Guid player, IEnumerable<Card> options) : base(player, options, 0, 1)
        {
        }

        public override string ToString()
        {
            return "You may choose a creature to block the attack with.";
        }
    }
}
