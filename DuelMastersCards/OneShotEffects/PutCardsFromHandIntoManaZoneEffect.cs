using DuelMastersModels;
using DuelMastersModels.Abilities;
using DuelMastersModels.Choices;
using System.Linq;

namespace DuelMastersCards.OneShotEffects
{
    public class PutCardsFromHandIntoManaZoneEffect : OneShotEffect
    {
        public int Amount { get; set; }

        public PutCardsFromHandIntoManaZoneEffect(int amount)
        {
            Amount = amount;
        }

        public PutCardsFromHandIntoManaZoneEffect(PutCardsFromHandIntoManaZoneEffect effect) : base(effect)
        {
            Amount = effect.Amount;
        }

        public override OneShotEffect Copy()
        {
            return new PutCardsFromHandIntoManaZoneEffect(this);
        }

        public override void Apply(Game game)
        {
            var player = game.GetPlayer(Controller);
            var cards = player.Hand.Cards;
            if (cards.Any())
            {
                var decision = player.Choose(new GuidSelection(Controller, cards, 0, Amount));
                game.Move(decision.Decision.Select(x => game.GetCard(x)), DuelMastersModels.Zones.ZoneType.Hand, DuelMastersModels.Zones.ZoneType.ManaZone);
            }
        }
    }
}
