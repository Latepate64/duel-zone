using DuelMastersModels.Cards;

namespace DuelMastersModels.Zones
{
    public class ManaZone : Zone
    {
        public override bool Public { get; } = true;
        public override bool Ordered { get; } = false;

        public ManaZone(Player owner) : base(owner) { }

        public override void Add(Card card, Duel duel)
        {
            if (card.Civilizations.Count > 1)
            {
                card.Tapped = true;
            }
            Cards.Add(card);
        }

        public override void Remove(Card card, Duel duel)
        {
            Cards.Remove(card);
            card.Tapped = false;
        }
    }
}