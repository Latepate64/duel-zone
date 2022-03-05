using System;
using System.Collections.Generic;

namespace Common.Choices
{
    public class AttackTargetSelection : BoundedGuidSelection
    {
        public AttackTargetSelection()
        {
        }

        public AttackTargetSelection(Guid player, IEnumerable<Guid> options, int minimumSelection, int maximumSelection) : base(player, options, minimumSelection, maximumSelection)
        {
        }

        public override string ToString()
        {
            return "Choose a target for the attack.";
        }
    }
}
