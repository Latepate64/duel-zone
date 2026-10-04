using System;
using System.Collections.Generic;
using System.Linq;
using Interfaces;
using Interfaces.Zones;

namespace Engine.Zones;

/// <summary>
/// A zone is an area where cards can be during a game. There are normally eight
/// zones: deck, hand, battle zone, graveyard, mana zone, shield zone,
/// hyperspatial zone and "super gacharange zone". Each player has their own
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
        cards = [.. zone.cards.Select(x => x.Copy())];
        Type = zone.Type;
    }

    public override bool Equals(object obj)
    {
        if (obj is not Zone zone) return false;
        if (!cards.SequenceEqual(zone.cards)) return false;
        if (!Type.Equals(zone.Type)) return false;
        return true;
    }

    public override int GetHashCode()
    {
        var hash = new HashCode();
        hash.Add(Type);
        foreach (var x in cards)
        {
            hash.Add(x);
        }
        return hash.ToHashCode();
    }

    public void Add(ICard card)
    {
        cards.Add(card);
    }

    public IEnumerable<ICard> Remove(ICard card)
    {
        return cards.Remove(card) ? [card] : [];
    }

    protected virtual void Dispose(bool disposing)
    {
    }

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }

    public IEnumerable<ICreature> GetCreatures(Guid owner)
    {
        return Creatures.Where(x => x.Owner.Id == owner);
    }

    public int GetCreatureCount(Guid owner)
    {
        return GetCreatures(owner).Count();
    }

    public IEnumerable<ICreature> GetCreatures(params Race[] races)
    {
        return Creatures.Where(creature => creature.Races.Any(
            race => races.Contains(race)));
    }

    public IEnumerable<ICard> GetCards(Civilization civilization)
    {
        return cards.Where(x => x.HasCivilization(civilization));
    }

    public int GetCardCount(Civilization civilization)
    {
        return GetCards(civilization).Count();
    }

    public int GetCreatureCount(Civilization civilization)
    {
        return GetCreatures(civilization).Count();
    }

    public IEnumerable<ICreature> GetCreatures(Civilization civilization)
    {
        return Creatures.Where(x => x.HasCivilization(civilization));
    }

    public IEnumerable<ICreature> GetOtherCreatures(Guid creature)
    {
        return Creatures.Where(x => x.Id != creature);
    }

    public IEnumerable<ICreature> GetCreaturesWithMaxPower(int maxPower)
    {
        return Creatures.Where(x => x.Power <= maxPower);
    }

    public bool Contains(ICard card)
    {
        return cards.Contains(card);
    }

    public void Shuffle(IRandomizer randomizer)
    {
        randomizer.Shuffle(cards);
    }

    public IEnumerable<ICreature> Dragons => Creatures.Where(x => x.IsDragon);

    public IEnumerable<ICard> CardsWithName(string name)
    {
        return cards.Where(x => x.Name == name);
    }

    public IEnumerable<ICard> NonCivilizationCards(Civilization civ)
    {
        return cards.Where(x => !x.HasCivilization(civ));
    }

    public IEnumerable<ICard> CardsWithManaCost(int manaCost)
    {
        return cards.Where(x => x.ManaCost == manaCost);
    }

    public void SetOwner(IPlayerV2 owner)
    {
        cards.ForEach(c => c.OwnerV2 = owner);
    }

    public abstract IZone Copy();
}
