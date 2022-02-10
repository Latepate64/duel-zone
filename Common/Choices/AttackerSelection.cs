using System;
using System.Collections.Generic;

namespace Common.Choices
{
    public class AttackerSelection : CardSelection
    {
        public AttackerSelection()
        {
        }

        public AttackerSelection(Guid player, IEnumerable<Card> options, int minimumSelection) : base(player, options, minimumSelection, 1)
        {
        }

        public override string ToString()
        {
            return "You may choose a creature to attack with.";
        }
    }
}
