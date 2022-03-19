using System;
using System.Collections.Generic;

namespace Common.Choices
{
    public class ShieldTriggerSelection : BoundedCardSelection
    {
        public ShieldTriggerSelection()
        {
        }

        public ShieldTriggerSelection(Guid player, IEnumerable<ICard> options) : base(player, options, 0, 1)
        {
        }

        public override string ToString()
        {
            return "You may use a shield trigger.";
        }
    }
}
