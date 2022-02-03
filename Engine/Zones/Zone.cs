﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Engine.Zones
{
    public enum ZoneType { Anywhere, BattleZone, Deck, Graveyard, Hand, ManaZone, ShieldZone };

    /// <summary>
    /// A zone is an area where cards can be during a game. There are normally eight zones: deck, hand, battle zone, graveyard, mana zone, shield zone, hyperspatial zone and "super gacharange zone". Each player has their own zones except for the battle zone which is shared by each player.
    /// </summary>
    public abstract class Zone : IDisposable, ICopyable<Zone>
    {
        public List<Card> Cards { get; private set; }

        public IEnumerable<Card> Creatures => Cards.Where(x => x.CardType == CardType.Creature);

        protected Zone(IEnumerable<Card> cards)
        {
            Cards = new List<Card>(cards.ToList());
        }

        public abstract void Add(Card card, Game game);

        public abstract void Remove(Card card, Game game);

        protected virtual void Dispose(bool disposing)
        {
            if (disposing && Cards != null)
            {
                foreach (var card in Cards)
                {
                    card.Dispose();
                }
                Cards = null;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        public abstract Zone Copy();

        public IEnumerable<Card> GetCreatures(Guid owner)
        {
            return Creatures.Where(x => x.Owner == owner);
        }
    }
}