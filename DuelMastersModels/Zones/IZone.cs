using DuelMastersModels.Cards;
using System.Collections.Generic;

namespace DuelMastersModels.Zones
{
    public interface IZone<TCard> where TCard : ICard
    {
        IEnumerable<TCard> Cards { get; }
    }
}