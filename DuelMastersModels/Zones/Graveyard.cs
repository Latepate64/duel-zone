using DuelMastersModels.Cards;
using System.Collections.Generic;
using System.Linq;

namespace DuelMastersModels.Zones
{
    /// <summary>
    /// A player’s graveyard is their discard pile. Discarded cards, destroyed creatures and spells cast are put in their owner's graveyard.
    /// </summary>
    public class Graveyard : Zone, ICopyable<Graveyard>
    {
        public Graveyard(IEnumerable<Card> cards) : base(cards) { }

        internal override bool Public { get; } = true;
        internal override bool Ordered { get; } = false;

        public override void Add(Card card, Duel duel)
        {
            card.RevealedTo = duel.Players.Select(x => x.Id);
            _cards.Add(card);
        }

        public override void Remove(Card card)
        {
            if (!_cards.Remove(card))
            {
                throw new System.NotSupportedException(card.ToString());
            }
        }

        public Graveyard Copy()
        {
            return new Graveyard(Cards.Select(x => x.Copy()));
        }
    }
}