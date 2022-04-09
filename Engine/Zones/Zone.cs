using System;
using System.Collections.Generic;
using System.Linq;

namespace Engine.Zones
{
    /// <summary>
    /// A zone is an area where cards can be during a game. There are normally eight zones: deck, hand, battle zone, graveyard, mana zone, shield zone, hyperspatial zone and "super gacharange zone". Each player has their own zones except for the battle zone which is shared by each player.
    /// </summary>
    public abstract class Zone : IDisposable, IZone
    {
        public List<ICard> Cards { get; private set; } = new List<ICard>();

        public IEnumerable<ICard> Creatures => Cards.Where(x => x.CardType == Common.CardType.Creature);
        public IEnumerable<ICard> Spells => Cards.Where(x => x.CardType == Common.CardType.Spell);

        protected Zone()
        {
        }

        protected Zone(IZone zone)
        {
            Cards = zone.Cards.Select(x => x.Copy()).ToList();
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
            return Creatures.Where(x => x.Owner == owner);
        }

        public abstract override string ToString();

        public IEnumerable<ICard> GetCreatures(Common.Subtype subtype)
        {
            return Creatures.Where(x => x.HasSubtype(subtype));
        }

        public IEnumerable<ICard> GetCards(Common.Civilization civilization)
        {
            return Cards.Where(x => x.HasCivilization(civilization));
        }

        public IEnumerable<ICard> GetCreatures(Common.Civilization civilization)
        {
            return Creatures.Where(x => x.HasCivilization(civilization));
        }
    }
}
