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
        public List<Card> Cards { get; private set; } = new List<Card>();

        public IEnumerable<Card> Creatures => Cards.Where(x => x.CardType == Common.CardType.Creature);

        protected Zone()
        {
        }

        protected Zone(Zone zone)
        {
            Cards = zone.Cards.Select(x => x.Copy()).ToList();
        }

        public abstract void Add(Card card, Game game);

        public abstract List<Card> Remove(Card card, Game game);

        protected virtual void Dispose(bool disposing)
        {
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        public IEnumerable<Card> GetCreatures(Guid owner)
        {
            return Creatures.Where(x => x.Owner == owner);
        }

        public abstract override string ToString();
    }
}
