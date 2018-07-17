using DuelMastersModels.Cards;

namespace DuelMastersModels.Zones
{
    public class Graveyard : Zone
    {
        public override bool Public { get; } = true;
        public override bool Ordered { get; } = false;

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