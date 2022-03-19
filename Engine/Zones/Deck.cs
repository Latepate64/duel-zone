using System;
using System.Collections.Generic;
using System.Linq;

namespace Engine.Zones
{
    /// <summary>
    /// When a game begins, each player’s deck becomes their deck.
    /// </summary>
    public class Deck : Zone
    {
        public Deck() : base() { }

        public Deck(Zone zone) : base(zone)
        {
        }

        public override void Add(ICard card, IGame game)
        {
            Cards.Add(card);
        }

        public override List<ICard> Remove(ICard card, IGame game)
        {
            if (!Cards.Remove(card))
            {
                return new List<ICard>();
            }
            if (!Cards.Any())
            {
                var player = game.GetPlayer(card.Owner);
                game.Process(new Common.GameEvents.DeckoutEvent { Player = player.Copy() });
                game.Lose(player);
            }
            return new List<ICard> { card };
        }

        public void Shuffle()
        {
            foreach (var card in Cards)
            {
                card.KnownTo = new List<Guid>();
            }
            Random random = new Random(Guid.NewGuid().GetHashCode());
            int n = Cards.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                var value = Cards[k];
                Cards[k] = Cards[n];
                Cards[n] = value;
            }
        }

        public override string ToString()
        {
            return "deck";
        }

        public void Setup(IEnumerable<Card> cards, Guid owner)
        {
            cards.ToList().ForEach(x => x.Owner = owner);
            Cards.AddRange(cards);
        }
    }
}
