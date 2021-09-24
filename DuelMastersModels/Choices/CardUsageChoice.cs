using System;
using System.Collections.Generic;
using System.Linq;

namespace DuelMastersModels.Choices
{
    public class CardUsageChoice : Choice
    {
        public IEnumerable<IGrouping<Guid, IEnumerable<IEnumerable<Guid>>>> Options { get; }

        public CardUsageChoice(Guid player, IEnumerable<IGrouping<Guid, IEnumerable<IEnumerable<Guid>>>> useableCards) : base(player)
        {
            Options = useableCards;
        }
    }

    public class CardUsageDecision : Decision
    {
        public Tuple<Guid, IEnumerable<Guid>> Decision { get; private set; }

        public CardUsageDecision(Tuple<Guid, IEnumerable<Guid>> decision)
        {
            Decision = decision;
        }
    }
}
