﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Engine.Zones
{
    /// <summary>
    /// When a game begins, each player’s deck becomes their deck.
    /// </summary>
    public class Deck : Zone
    {
        public Deck(IEnumerable<Card> cards) : base(cards) { }

        public override void Add(Card card, Game game)
        {
            Cards.Add(card);
        }

        public override bool Remove(Card card, Game game)
        {
            if (!Cards.Remove(card))
            {
                return false;
            }
            if (!Cards.Any())
            {
                var player = game.GetPlayer(card.Owner);
                game.Process(new Common.GameEvents.DeckoutEvent { Player = player.Copy() });
                game.Lose(player);
            }
            return true;
        }

        public void Shuffle()
        {
            foreach (var card in Cards)
            {
                card.KnownBy = new List<Guid>();
            }
            Random random = new Random(Guid.NewGuid().GetHashCode());
            int n = Cards.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                Card value = Cards[k];
                Cards[k] = Cards[n];
                Cards[n] = value;
            }
        }

        public override Zone Copy()
        {
            return new Deck(Cards.Select(x => x.Copy()));
        }

        public override string ToString()
        {
            return "deck";
        }
    }
}
