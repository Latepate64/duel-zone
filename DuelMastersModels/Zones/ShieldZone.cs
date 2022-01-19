using System.Collections.Generic;
using System.Linq;

namespace DuelMastersModels.Zones
{
    /// <summary>
    /// At the beginning of the game, each player puts five shields into their shield zone. Castles are put into the shield zone to fortify a shield.
    /// </summary>
    public class ShieldZone : Zone
    {
        public ShieldZone(IEnumerable<Card> cards) : base(cards) { }

        public override void Add(Card card, Duel duel)
        {
            Cards.Add(card);
        }

        public override void Remove(Card card, Duel duel)
        {
            if (!Cards.Remove(card))
            {
                throw new System.NotSupportedException(card.ToString());
            }
        }

        public override Zone Copy()
        {
            return new ShieldZone(Cards.Select(x => x.Copy()));
        }

        public override string ToString()
        {
            return "shield zone";
        }
    }
}