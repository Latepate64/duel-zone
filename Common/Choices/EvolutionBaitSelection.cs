using System;
using System.Collections.Generic;

namespace Common.Choices
{
    public class EvolutionBaitSelection : BoundedCardSelection
    {
        public EvolutionBaitSelection()
        {
        }

        public EvolutionBaitSelection(Guid player, IEnumerable<ICard> options) : base(player, options, 1, 1)
        {
        }

        public override string ToString()
        {
            return "Choose a creature to evolve from.";
        }
    }
}
