using System;
using System.Collections.Generic;
using System.Linq;

namespace Engine.Zones
{
    /// <summary>
    /// A zone is an area where cards can be during a game. There are normally eight zones: deck, hand, battle zone, graveyard, mana zone, shield zone, hyperspatial zone and "super gacharange zone". Each player has their own zones except for the battle zone which is shared by each player.
    /// </summary>
    public abstract class Zone : IDisposable
    {
        public List<ICard> Cards { get; init; } = [];

        public IEnumerable<ICard> Creatures => Cards.Where(x => x.CardType == CardType.Creature);
        public IEnumerable<ICard> Spells => Cards.Where(x => x.CardType == CardType.Spell);

        public ZoneType Type { get; }
        public bool HasCards => Cards.Count != 0;

        protected Zone(ZoneType type, params ICard[] cards)
        {
            Type = type;
            Cards = [.. cards];
        }

        protected Zone(Zone zone)
        {
            Cards = [.. zone.Cards.Select(x => x.Copy())];
        }

        public abstract void Add(ICard card, IGame game);

        public abstract List<ICard> Remove(ICard card, IGame game);

        protected virtual void Dispose(bool disposing)
        {
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        public IEnumerable<ICard> GetCreatures(Guid owner)
        {
            return Creatures.Where(x => x.Owner.Id == owner);
        }

        public abstract override string ToString();

        public IEnumerable<ICard> GetCreatures(Race race)
        {
            return Creatures.Where(x => x.HasRace(race));
        }

        public IEnumerable<ICard> GetCards(Civilization civilization)
        {
            return Cards.Where(x => x.HasCivilization(civilization));
        }

        public IEnumerable<ICard> GetCreatures(Civilization civilization)
        {
            return Creatures.Where(x => x.HasCivilization(civilization));
        }

        public IEnumerable<ICard> GetOtherCreatures(Guid creature)
        {
            return Creatures.Where(x => x.Id != creature);
        }
    }
}
