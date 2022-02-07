using System;
using System.Collections.Generic;
using System.Linq;

namespace Common.Choices
{
    public class CardSelection : GuidSelection
    {
        public CardSelection()
        {
        }

        public CardSelection(Guid player, IEnumerable<Card> options, int minimumSelection, int maximumSelection) : base(player, options.Select(x => x.Id), minimumSelection, maximumSelection) { }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}
