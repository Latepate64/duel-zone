using System.Collections.Generic;
using Interfaces;

namespace Engine.Zones;

public interface IManaZone : IZone
{
    IEnumerable<ICard> TappedCards { get; }
    IEnumerable<ICard> UntappedCards { get; }

    bool AreAllCivilizationCards(Civilization civ);
    ManaZone Copy();
    IEnumerable<ICard> GetNonEvolutionCreaturesThatCostSameOrLessThan(int maximum);
}
