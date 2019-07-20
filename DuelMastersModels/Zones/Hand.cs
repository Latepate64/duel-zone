using DuelMastersModels.Cards;

namespace DuelMastersModels.Zones
{
    public class Hand : Zone
    {
        public override bool Public { get; } = false;
        public override bool Ordered { get; } = false;

        public Hand(Player owner) : base(owner) { }

        public override void Add(Card card, Duel duel)
        {
            Cards.Add(card);
            card.KnownToOwner = true;
            card.KnownToOpponent = false;
        }

        public override void Remove(Card card, Duel duel)
        {
            Cards.Remove(card);
        }
    }
}