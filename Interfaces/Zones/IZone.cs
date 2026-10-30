namespace Interfaces.Zones;

public interface IZone
{
    ZoneType Type { get; }
    IEnumerable<ICreature> Creatures { get; }
    int Size { get; }
    bool HasCards { get; }
    IEnumerable<ICard> Cards { get; }

    void Add(ICard newObject);
    IEnumerable<ICard> CardsWithName(string name);
    void Dispose();
    int GetCardCount(Civilization civilization);
    IEnumerable<ICreature> GetCreatures(params Race[] races);
    IEnumerable<ICreature> GetCreatures(Civilization civilization);
    IEnumerable<ICard> NonCivilizationCards(Civilization civ);
    IEnumerable<ICard> Remove(ICard card);
    void SetOwner(IPlayer owner);
    IZone Copy();
    bool Contains(ICard card);
    void Shuffle(IRandomizer randomizer);
    IEnumerable<ICard> GetCards(ICardFilter filter);
    int GetNumberOfCards(ICardFilter filter);
}
