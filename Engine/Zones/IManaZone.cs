using System.Collections.Generic;

namespace Engine.Zones
{
    public interface IManaZone : IZone
    {
        IEnumerable<ICard> TappedCards { get; }
        IEnumerable<ICard> UntappedCards { get; }
    }
}