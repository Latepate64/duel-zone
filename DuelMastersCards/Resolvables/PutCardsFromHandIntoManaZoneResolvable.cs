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

        public override void Resolve(Duel duel, Decision decision)
        {
            if (decision == null)
            {
                var cards = duel.GetPlayer(Controller).Hand.Cards;
                if (cards.Any())
                {
                    duel.SetAwaitingChoice(new GuidSelection(Controller, cards, 0, Amount));
                }
            }
            else
            {
                duel.Move((decision as GuidDecision).Decision.Select(x => duel.GetCard(x)), DuelMastersModels.Zones.ZoneType.Hand, DuelMastersModels.Zones.ZoneType.ManaZone);
            }
        }
    }
}
