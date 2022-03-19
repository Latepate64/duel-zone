using System;
using System.Collections.Generic;
using System.Linq;

namespace Common.Choices
{
    public abstract class CardSelection : GuidSelection
    {
        protected CardSelection() { }

        protected CardSelection(Guid player, IEnumerable<ICard> options) : base(player, options.Select(x => x.Id)) { }
    }
}
