using System;
using System.Collections.Generic;
using System.Linq;

namespace Engine.Zones
{
    /// <summary>
    /// A zone is an area where cards can be during a game. There are normally eight zones: deck, hand, battle zone,
    /// graveyard, mana zone, shield zone, hyperspatial zone and "super gacharange zone". Each player has their own
    /// zones except for the battle zone which is shared by each player.
    /// </summary>
    public abstract class Zone : IDisposable
    {
        readonly List<Card> cards = [];
        public ZoneType Type { get; }

        public IEnumerable<Card> Creatures => cards.Where(x => x.IsCreature);
        public IEnumerable<Card> Spells => cards.Where(x => x.IsSpell);

        public int Size => cards.Count;
        public bool HasCards => Size != 0;
        public IEnumerable<Card> Cards => cards;

        protected Zone(ZoneType type, params Card[] cards)
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

        internal void Add(Card card)
        {
            cards.Add(card);
        }

        internal IEnumerable<Card> Remove(Card card) => cards.Remove(card) ? [card] : [];

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

        public IEnumerable<Card> GetCards(Civilization civilization) => cards.Where(x => x.HasCivilization(
            civilization));

        public int GetCardCount(Civilization civilization) => GetCards(civilization).Count();

        public int GetCreatureCount(Civilization civilization) => GetCreatures(civilization).Count();

        public IEnumerable<Card> GetCreatures(Civilization civilization) => Creatures.Where(x => x.HasCivilization(
            civilization));

        public IEnumerable<Card> GetOtherCreatures(Guid creature) => Creatures.Where(x => x.Id != creature);

        public IEnumerable<Card> GetCreaturesWithMaxPower(int maxPower) => Creatures.Where(x => x.Power <= maxPower);

        internal bool Contains(Card card) => cards.Contains(card);

        internal void Shuffle(IRandomizer randomizer)
        {
            randomizer.Shuffle(cards);
        }

        public IEnumerable<Card> Dragons => Creatures.Where(x => x.IsDragon);

        public IEnumerable<Card> CardsWithName(string name) => cards.Where(x => x.Name == name);

        public IEnumerable<Card> NonCivilizationCards(Civilization civ) => cards.Where(x => !x.HasCivilization(civ));

        public IEnumerable<Card> CardsWithManaCost(int manaCost) => cards.Where(x => x.ManaCost == manaCost);
    }
}
