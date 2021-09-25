using DuelMastersModels.Cards;
using System.Collections.Generic;
using System.Linq;

namespace DuelMastersModels.Zones
{
    /// <summary>
    /// The hand is where a player holds cards that have been drawn. Cards can be put into a player’s hand by other effects as well. At the beginning of the game, each player draws five cards.
    /// </summary>
    public class Hand : Zone, ICopyable<Hand>
    {
        public Hand(IEnumerable<Card> cards) : base(cards) { }

        internal override bool Public { get; } = false;
        internal override bool Ordered { get; } = false;

        public override void Add(Card card, Duel duel)
        {
            _cards.Add(card);
        }

        public override void Remove(Card card)
        {
            if (!_cards.Remove(card))
            {
                throw new System.NotSupportedException(card.ToString());
            }
        }

        public Hand Copy()
        {
            return new Hand(Cards.Select(x => x.Copy()));
        }
    }
}