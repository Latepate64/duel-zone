using DuelMastersModels.Abilities;
using DuelMastersModels.Abilities.Triggered;
using DuelMastersModels.Abilities.TriggeredAbilities;
using DuelMastersModels.Choices;
using System;
using System.Linq;

namespace DuelMastersModels.Cards.Creatures
{
    public class SniperMosquito : Creature
    {
        public SniperMosquito(Guid owner) : base(owner, 1, Civilization.Nature, 2000, Race.GiantInsect)
        {
            TriggeredAbilities.Add(new SniperMosquitoAbility(Id, owner));
        }

        public SniperMosquito(Creature creature) : base(creature)
        {
        }

        public override Card Copy()
        {
            return new SniperMosquito(this);
        }
    }

    public class SniperMosquitoAbility : WheneverThisCreatureAttacksAbility
    {
        public SniperMosquitoAbility(Guid source, Guid controller) : base(source, controller)
        {
        }

        public SniperMosquitoAbility(TriggeredAbility ability) : base(ability)
        {
        }


        public override NonStaticAbility Copy()
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
                    if (controller.ManaZone.Cards.Count() > 1)
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
