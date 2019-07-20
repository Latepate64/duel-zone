using DuelMastersModels.Cards;

namespace DuelMastersModels.Zones
{
    public class Graveyard : Zone
    {
        public override bool Public { get; } = true;
        public override bool Ordered { get; } = false;

        public Graveyard(Player owner) : base(owner) { }

        public override void Add(Card card, Duel duel)
        {
            Cards.Add(card);
            card.KnownToOwner = true;
            card.KnownToOpponent = true;
        }

        public override void Remove(Card card, Duel duel)
        {
            Cards.Remove(card);
        }
    }
}