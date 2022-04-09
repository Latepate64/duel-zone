using System;
using System.Collections.Generic;

namespace Common.Choices
{
    public class ShieldBreakSelection : BoundedCardSelection
    {
        public ShieldBreakSelection()
        {
        }

        public ShieldBreakSelection(Guid player, IEnumerable<ICard> options, int amount) : base(player, options, amount, amount)
        {
        }

        public override string ToString()
        {
            return "Choose shields to break.";
        }
    }
}
