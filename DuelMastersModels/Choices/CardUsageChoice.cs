using System;
using System.Collections.Generic;
using System.Linq;

namespace DuelMastersModels.Choices
{
    public class CardUsageChoice : Choice
    {
        public IEnumerable<IGrouping<Guid, IEnumerable<IEnumerable<Guid>>>> Options { get; }

        public Tuple<Guid, IEnumerable<Guid>> Selected { get; set; }

        public CardUsageChoice(Guid player, IEnumerable<IGrouping<Guid, IEnumerable<IEnumerable<Guid>>>> useableCards) : base(player)
        {
            Options = useableCards;
        }

        public CardUsageChoice(Tuple<Guid, IEnumerable<Guid>> selected, Guid player) : base(player)
        {
            Selected = selected;
        }
    }
}
