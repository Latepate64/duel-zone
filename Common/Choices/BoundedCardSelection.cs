using System;
using System.Collections.Generic;
using System.Linq;

namespace Common.Choices
{
    public abstract class BoundedCardSelection : BoundedGuidSelection
    {
        protected BoundedCardSelection() { }

        protected BoundedCardSelection(Guid player, IEnumerable<ICard> options, int minimumSelection, int maximumSelection) : base(player, options.Select(x => x.Id), minimumSelection, maximumSelection) { }
    }
}
