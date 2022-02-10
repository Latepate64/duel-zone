using System;
using System.Collections.Generic;
using System.Linq;

namespace Common.Choices
{
    public class AbilitySelection : GuidSelection
    {
        public AbilitySelection()
        {
        }

        public AbilitySelection(Guid player, IEnumerable<Guid> options, int minimumSelection, int maximumSelection) : base(player, options, minimumSelection, maximumSelection)
        {
        }

        public override string ToString()
        {
            return "Choose an ability to resolve.";
        }
    }
}
