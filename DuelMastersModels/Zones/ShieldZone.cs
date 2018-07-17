using DuelMastersModels.Cards;

namespace DuelMastersModels.Zones
{
    public class ShieldZone : Zone
    {
        public override bool Public { get; } = false;
        public override bool Ordered { get; } = true;

        public override void Add(Card card)
        {
            Cards.Add(card);
        }

        public override void Remove(Card card)
        {
            Cards.Remove(card);
        }
    }
}