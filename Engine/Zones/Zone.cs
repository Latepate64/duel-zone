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
        public List<Card> Cards { get; init; } = [];

        public IEnumerable<Card> Creatures => Cards.Where(x => x.IsCreature);
        public IEnumerable<Card> Spells => Cards.Where(x => x.IsSpell);

        public ZoneType Type { get; }
        public bool HasCards => Cards.Count != 0;

        protected Zone(ZoneType type, params Card[] cards)
        {
            Type = type;
            Cards = [.. cards];
        }

        protected Zone(Zone zone)
        {
            Cards = [.. zone.Cards.Select(x => x.Copy())];
        }

        internal abstract void Add(Card card);

        internal abstract List<Card> Remove(Card card, IGame game);

        protected virtual void Dispose(bool disposing)
        {
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        public IEnumerable<Card> GetCreatures(Guid owner) => Creatures.Where(x => x.Owner.Id == owner);

        public int GetCreatureCount(Guid owner) => GetCreatures(owner).Count();

        public IEnumerable<Card> GetCreatures(Race race) => Creatures.Where(x => x.HasRace(race));

        public IEnumerable<Card> GetCards(Civilization civilization) => Cards.Where(x => x.HasCivilization(
            civilization));

        public int GetCardCount(Civilization civilization) => GetCards(civilization).Count();

        public int GetCreatureCount(Civilization civilization) => GetCreatures(civilization).Count();

        public IEnumerable<Card> GetCreatures(Civilization civilization) => Creatures.Where(x => x.HasCivilization(
            civilization));

        public IEnumerable<Card> GetOtherCreatures(Guid creature) => Creatures.Where(x => x.Id != creature);

        public IEnumerable<Card> GetCreaturesWithMaxPower(int maxPower) => Creatures.Where(x => x.Power <= maxPower);
    }
}
