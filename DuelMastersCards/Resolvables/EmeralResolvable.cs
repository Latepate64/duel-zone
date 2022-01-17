using DuelMastersModels;
using DuelMastersModels.Abilities;
using DuelMastersModels.Choices;
using System.Linq;

namespace DuelMastersCards.Resolvables
{
    public class EmeralResolvable : Resolvable
    {
        public EmeralResolvable(EmeralResolvable ability) : base(ability)
        {
        }

        public EmeralResolvable() : base()
        {
        }

        public override Resolvable Copy()
        {
            return new EmeralResolvable(this);
        }

        public override void Resolve(Duel duel)
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
