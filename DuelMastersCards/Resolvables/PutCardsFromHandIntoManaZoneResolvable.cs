using DuelMastersModels;
using DuelMastersModels.Abilities;
using DuelMastersModels.Choices;
using System.Linq;

namespace DuelMastersCards.Resolvables
{
    public class PutCardsFromHandIntoManaZoneResolvable : Resolvable
    {
        public int Amount { get; set; }

        public PutCardsFromHandIntoManaZoneResolvable(int amount)
        {
            Amount = amount;
        }

        public PutCardsFromHandIntoManaZoneResolvable(PutCardsFromHandIntoManaZoneResolvable resolvable) : base(resolvable)
        {
            Amount = resolvable.Amount;
        }

        public override Resolvable Copy()
        {
            return new PutCardsFromHandIntoManaZoneResolvable(this);
        }

        public override void Resolve(Duel duel)
        {
            var player = duel.GetPlayer(Controller);
            var cards = player.Hand.Cards;
            if (cards.Any())
            {
                var decision = player.Choose(new GuidSelection(Controller, cards, 0, Amount));
                duel.Move(decision.Decision.Select(x => duel.GetCard(x)), DuelMastersModels.Zones.ZoneType.Hand, DuelMastersModels.Zones.ZoneType.ManaZone);
            }
        }
    }
}
