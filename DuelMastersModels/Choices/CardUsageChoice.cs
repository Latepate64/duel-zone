using DuelMastersModels.Cards;
using System.Collections.Generic;
using System.Linq;

namespace DuelMastersModels.Choices
{
    public class CardUsageChoice : Choice
    {
        public IEnumerable<IGrouping<Card, IEnumerable<IEnumerable<Card>>>> UseableCards { get; }

        public IGrouping<Card, IEnumerable<Card>> Selected { get; set; }

        public CardUsageChoice(Player player, IEnumerable<IGrouping<Card, IEnumerable<IEnumerable<Card>>>> useableCards) : base(player)
        {
            UseableCards = useableCards;
        }
    }
}
