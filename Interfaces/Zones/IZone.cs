namespace Interfaces.Zones;

public interface IZone
{
    ZoneType Type { get; }
    IEnumerable<ICreature> Creatures { get; }
    IEnumerable<ISpell> Spells { get; }
    int Size { get; }
    bool HasCards { get; }
    IEnumerable<ICard> Cards { get; }
    IEnumerable<ICreature> Dragons { get; }

    void Add(ICard newObject);
    IEnumerable<ICard> CardsWithManaCost(int manaCost);
    IEnumerable<ICard> CardsWithName(string name);
    void Dispose();
    bool Equals(object obj);
    int GetCardCount(Civilization civilization);
    IEnumerable<ICard> GetCards(Civilization civilization);
    int GetCreatureCount(Guid owner);
    int GetCreatureCount(Civilization civilization);
    IEnumerable<ICreature> GetCreatures(Guid owner);
    IEnumerable<ICreature> GetCreatures(params Race[] races);
    IEnumerable<ICreature> GetCreatures(Civilization civilization);
    IEnumerable<ICreature> GetCreaturesWithMaxPower(int maxPower);
    IEnumerable<ICreature> GetOtherCreatures(Guid creature);
    IEnumerable<ICard> NonCivilizationCards(Civilization civ);
    IEnumerable<ICard> Remove(ICard card);
    void SetOwner(IPlayerV2 owner);
    IZone Copy();
    bool Contains(ICard card);
    void Shuffle(IRandomizer randomizer);
}
