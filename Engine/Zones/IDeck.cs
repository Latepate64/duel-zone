using System.Collections.Generic;

namespace Engine.Zones;

public interface IDeck : IZone
{
    Card TopCard { get; }

    Deck Copy();
    IEnumerable<Card> GetTopCards(int amount);
}
