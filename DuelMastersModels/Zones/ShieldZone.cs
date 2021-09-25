using DuelMastersModels.Cards;
using System.Collections.Generic;
using System.Linq;

namespace DuelMastersModels.Zones
{
    /// <summary>
    /// At the beginning of the game, each player puts five shields into their shield zone. Castles are put into the shield zone to fortify a shield.
    /// </summary>
    public class ShieldZone : Zone, ICopyable<ShieldZone>
    {
        public ShieldZone(IEnumerable<Card> cards) : base(cards) { }

        internal override bool Public { get; } = false;
        internal override bool Ordered { get; } = true;

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

        public ShieldZone Copy()
        {
            return new ShieldZone(Cards.Select(x => x.Copy()));
        }
    }
}