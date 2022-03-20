﻿using System;
using System.Collections.Generic;

namespace Common.Choices
{
    public class ChargeManaSelection : BoundedCardSelection
    {
        public ChargeManaSelection()
        {
        }

        public ChargeManaSelection(Guid player, IEnumerable<ICard> options) : base(player, options, 0, 1)
        {
        }

        public override string ToString()
        {
            return "You may put a card from your hand into your mana zone.";
        }
    }
}
