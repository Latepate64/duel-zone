using DuelMastersModels;
using DuelMastersModels.Abilities;
using DuelMastersModels.Choices;
using System.Linq;

namespace DuelMastersCards.Resolvables
{
    public class SniperMosquitoResolvable : Resolvable
    {
        public SniperMosquitoResolvable() : base()
        {
        }

        public SniperMosquitoResolvable(SniperMosquitoResolvable ability) : base(ability)
        {
        }

        public override Resolvable Copy()
        {
            return new SniperMosquitoResolvable(this);
        }

        public override void Resolve(Duel duel)
        {
            // Return a card from your mana zone to your hand.
            var controller = duel.GetPlayer(Controller);
            if (controller.ManaZone.Cards.Any())
            {
                var decision = controller.Choose(new GuidSelection(Controller, controller.ManaZone.Cards, 1, 1));
                duel.Move(duel.GetCard(decision.Decision.Single()), DuelMastersModels.Zones.ZoneType.ManaZone, DuelMastersModels.Zones.ZoneType.Hand);
            }
        }
    }
}
