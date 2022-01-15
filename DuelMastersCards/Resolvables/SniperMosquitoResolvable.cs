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

        public override Choice Resolve(Duel duel, Decision decision)
        {
            // Return a card from your mana zone to your hand.
            var controller = duel.GetPlayer(Controller);
            if (decision == null)
            {
                if (controller.ManaZone.Cards.Any())
                {
                    if (controller.ManaZone.Cards.Count > 1)
                    {
                        return new GuidSelection(Controller, controller.ManaZone.Cards, 1, 1);
                    }
                    else
                    {
                        return duel.Move(controller.ManaZone.Cards, DuelMastersModels.Zones.ZoneType.ManaZone, DuelMastersModels.Zones.ZoneType.Hand);
                    }
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return duel.Move(duel.GetCard((decision as GuidDecision).Decision.Single()), DuelMastersModels.Zones.ZoneType.ManaZone, DuelMastersModels.Zones.ZoneType.Hand);
            }
        }
    }
}
