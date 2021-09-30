using DuelMastersModels.Abilities;
using DuelMastersModels.Abilities.Triggered;
using DuelMastersModels.Choices;
using System;
using System.Linq;

namespace DuelMastersModels.Cards.Creatures
{
    public class SniperMosquitoAbility : WheneverThisCreatureAttacksAbility
    {
        public SniperMosquitoAbility(Guid source, Guid controller) : base(source, controller)
        {
        }

        public SniperMosquitoAbility(TriggeredAbility ability) : base(ability)
        {
        }


        public override Ability Copy()
        {
            return new SniperMosquitoAbility(this);
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
                        return new Selection<Guid>(Controller, controller.ManaZone.Cards.Select(x => x.Id), 1, 1);
                    }
                    else
                    {
                        controller.PutFromManaZoneToHand(controller.ManaZone.Cards.Single(), duel);
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
            else
            {
                controller.PutFromManaZoneToHand(duel.GetCard((decision as GuidDecision).Decision.Single()), duel);
                return null;
            }
        }
    }
}
