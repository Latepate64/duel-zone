using DuelMastersModels.Abilities;
using DuelMastersModels.Abilities.TriggeredAbilities;
using DuelMastersModels.Choices;
using System;
using System.Linq;

namespace DuelMastersModels.Cards.Creatures
{
    public class AquaSurfer : Creature
    {
        public AquaSurfer(Creature creature) : base(creature)
        {
            ShieldTrigger = true;
            TriggerAbilities.Add(new AquaSurferAbility(Id));
        }

        public AquaSurfer() : base(6, Civilization.Water, 2000, Race.LiquidPeople)
        {
        }

        public override Card Copy()
        {
            return new AquaSurfer(this);
        }
    }

    public class AquaSurferAbility : TriggeredAbility
    {
        public AquaSurferAbility(TriggeredAbility ability) : base(ability)
        {
        }

        public AquaSurferAbility(Guid source) : base(new WhenYouPutThisCreatureIntoTheBattleZone(), source)
        {
        }

        public override Ability Copy()
        {
            return new AquaSurferAbility(this);
        }

        public override Choice Resolve(Duel duel, Decision decision)
        {
            // You may choose a creature in the battle zone and return it to its owner's hand.
            if (decision == null)
            {
                var controller = duel.GetPlayer(Controller);
                var opponent = duel.GetOpponent(controller);
                if (opponent.BattleZone.Creatures.Any())
                {
                    return new Selection<Guid>(Controller, opponent.BattleZone.Creatures.Select(x => x.Id));
                }
                else
                {
                    return null;
                }
            }
            else
            {
                foreach (var creature in (decision as GuidDecision).Decision.Select(x => duel.GetCreature(x)))
                {
                    duel.GetOwner(creature).ReturnFromBattleZoneToHand(creature, duel);
                }
                return null;
            }
        }
    }
}
