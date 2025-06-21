using System.Collections.Generic;
using Interfaces;

namespace Engine.Zones;

public interface IManaZone : IZone
{
    IEnumerable<Card> TappedCards { get; }
    IEnumerable<Card> UntappedCards { get; }

    bool AreAllCivilizationCards(Civilization civ);
    ManaZone Copy();
    IEnumerable<Card> GetNonEvolutionCreaturesThatCostSameOrLessThan(int maximum);
}
