using System.Collections.Generic;

namespace Engine.Zones;

public interface IDeck : IZone
{
    ICard TopCard { get; }

    Deck Copy();
    IEnumerable<ICard> GetTopCards(int amount);
}
