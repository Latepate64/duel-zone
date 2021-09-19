using DuelMastersModels.Cards;
using System.Collections.Generic;

namespace DuelMastersModels.Choices
{
    public interface ICardUsageChoice
    {
        IEnumerable<Card> UseCards { get; }
    }
}