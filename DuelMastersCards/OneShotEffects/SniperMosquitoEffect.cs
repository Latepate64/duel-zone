using DuelMastersModels;
using DuelMastersModels.Abilities;
using DuelMastersModels.Choices;
using System.Linq;

namespace DuelMastersCards.OneShotEffects
{
    public class SniperMosquitoEffect : OneShotEffect
    {
        public SniperMosquitoEffect() : base()
        {
        }

        public SniperMosquitoEffect(SniperMosquitoEffect effect) : base(effect)
        {
        }

        public override OneShotEffect Copy()
        {
            return new SniperMosquitoEffect(this);
        }

        public override void Apply(Game game)
        {
            // Return a card from your mana zone to your hand.
            var controller = game.GetPlayer(Controller);
            if (controller.ManaZone.Cards.Any())
            {
                var decision = controller.Choose(new GuidSelection(Controller, controller.ManaZone.Cards, 1, 1));
                game.Move(game.GetCard(decision.Decision.Single()), DuelMastersModels.Zones.ZoneType.ManaZone, DuelMastersModels.Zones.ZoneType.Hand);
            }
        }
    }
}
