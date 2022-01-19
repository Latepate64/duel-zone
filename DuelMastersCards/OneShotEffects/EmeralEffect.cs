using DuelMastersModels;
using DuelMastersModels.Abilities;
using DuelMastersModels.Choices;
using System.Linq;

namespace DuelMastersCards.OneShotEffects
{
    public class EmeralEffect : OneShotEffect
    {
        public EmeralEffect(EmeralEffect effect) : base(effect)
        {
        }

        public EmeralEffect() : base()
        {
        }

        public override OneShotEffect Copy()
        {
            return new EmeralEffect(this);
        }

        public override void Apply(Duel duel)
        {
            // You may add a card from your hand to your shields face down.
            var controller = duel.GetPlayer(Controller);
            if (controller.Hand.Cards.Any())
            {
                var decision = controller.Choose(new GuidSelection(Controller, controller.Hand.Cards, 0, 1));
                var cards = (decision as GuidDecision).Decision;
                if (cards.Any())
                {
                    duel.Move(cards.Select(x => duel.GetCard(x)), DuelMastersModels.Zones.ZoneType.Hand, DuelMastersModels.Zones.ZoneType.ShieldZone);

                    // If you do, choose one of your shields and put it into your hand. You can't use the "shield trigger" ability of that shield.
                    if (controller.ShieldZone.Cards.Any())
                    {
                        var decision2 = controller.Choose(new GuidSelection(Controller, controller.ShieldZone.Cards, 1, 1));
                        duel.PutFromShieldZoneToHand(duel.GetCard(decision2.Decision.Single()), false);
                    }
                }
            }
        }
    }
}
