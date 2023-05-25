using System.Collections.Generic;

namespace Engine.Zones
{
    public interface IManaZone : IZone, ICopyable<IManaZone>
    {
        IEnumerable<ICard> TappedCards { get; }
        IEnumerable<ICard> UntappedCards { get; }

        IEnumerable<ICard> GetNonEvolutionCreaturesThatCostSameOrLessThan(int maximum);
    }
}