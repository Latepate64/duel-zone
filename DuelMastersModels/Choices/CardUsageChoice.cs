using DuelMastersModels.Cards;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DuelMastersModels.Choices
{
    public class CardUsageChoice : Choice
    {
        public IEnumerable<IGrouping<Card, IEnumerable<IEnumerable<Card>>>> UseableCards { get; }

        public Tuple<Card, IEnumerable<Card>> Selected { get; set; }

        public CardUsageChoice(Guid player, IEnumerable<IGrouping<Card, IEnumerable<IEnumerable<Card>>>> useableCards) : base(player)
        {
            UseableCards = useableCards;
        }

        public CardUsageChoice(Tuple<Card, IEnumerable<Card>> selected, Guid player) : base(player)
        {
            Selected = selected;
        }
    }
}
