namespace Interfaces.Zones;

public interface IManaZone : IZone
{
    IEnumerable<ICard> TappedCards { get; }
    IEnumerable<ICard> UntappedCards { get; }

    bool AreAllCivilizationCards(Civilization civ);
    IEnumerable<ICard> GetNonEvolutionCreaturesThatCostSameOrLessThan(int maximum);
}
