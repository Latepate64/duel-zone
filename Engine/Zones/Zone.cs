using System;
using System.Collections.Generic;
using System.Linq;
using Interfaces;
using Interfaces.Zones;

namespace Engine.Zones;

/// <summary>
/// A zone is an area where cards can be during a game. There are normally eight zones: deck, hand, battle zone,
/// graveyard, mana zone, shield zone, hyperspatial zone and "super gacharange zone". Each player has their own
/// zones except for the battle zone which is shared by each player.
/// </summary>
public abstract class Zone : IDisposable, IZone
{
    readonly List<ICard> cards = [];
    public ZoneType Type { get; }

    public IEnumerable<ICreature> Creatures => cards.OfType<ICreature>();
    public IEnumerable<ISpell> Spells => cards.OfType<ISpell>();

    public int Size => cards.Count;
    public bool HasCards => Size != 0;
    public IEnumerable<ICard> Cards => cards;

    protected Zone(ZoneType type, params ICard[] cards)
    {
        Type = type;
        this.cards = [.. cards];
    }

    protected Zone(Zone zone)
    {
        cards = [.. zone.Cards.Select(x => x.Copy())];
    }

    public override bool Equals(object obj)
    {
        return obj is Zone zone && cards.SequenceEqual(zone.cards) && Type == zone.Type;
    }

    public void Add(ICard card)
    {
        cards.Add(card);
    }

    public IEnumerable<ICard> Remove(ICard card) => cards.Remove(card) ? [card] : [];

    protected virtual void Dispose(bool disposing)
    {
    }

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }

    public IEnumerable<ICreature> GetCreatures(Guid owner) => Creatures.Where(x => x.Owner.Id == owner);

    public int GetCreatureCount(Guid owner) => GetCreatures(owner).Count();

    public IEnumerable<ICreature> GetCreatures(params Race[] races) => Creatures.Where(creature => creature.Races.Any(
        race => races.Contains(race)));

    public IEnumerable<ICard> GetCards(Civilization civilization) => cards.Where(x => x.HasCivilization(
        civilization));

    public int GetCardCount(Civilization civilization) => GetCards(civilization).Count();

    public int GetCreatureCount(Civilization civilization) => GetCreatures(civilization).Count();

    public IEnumerable<ICreature> GetCreatures(Civilization civilization) => Creatures.Where(x => x.HasCivilization(
        civilization));

    public IEnumerable<ICreature> GetOtherCreatures(Guid creature) => Creatures.Where(x => x.Id != creature);

    public IEnumerable<ICreature> GetCreaturesWithMaxPower(int maxPower) => Creatures.Where(x => x.Power <= maxPower);

    public bool Contains(ICard card) => cards.Contains(card);

    public void Shuffle(IRandomizer randomizer)
    {
        randomizer.Shuffle(cards);
    }

    public IEnumerable<ICreature> Dragons => Creatures.Where(x => x.IsDragon);

    public IEnumerable<ICard> CardsWithName(string name) => cards.Where(x => x.Name == name);

    public IEnumerable<ICard> NonCivilizationCards(Civilization civ) => cards.Where(x => !x.HasCivilization(civ));

    public IEnumerable<ICard> CardsWithManaCost(int manaCost) => cards.Where(x => x.ManaCost == manaCost);

    public void SetOwner(IPlayerV2 owner)
    {
        cards.ForEach(c => c.OwnerV2 = owner);
    }

    public abstract IZone Copy();
}
