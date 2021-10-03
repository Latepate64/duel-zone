using DuelMastersModels;
using DuelMastersModels.Abilities;
using DuelMastersModels.Choices;
using System;
using System.Linq;

namespace DuelMastersCards.TriggeredAbilities
{
    public class AquaSurferAbility : WhenYouPutThisCreatureIntoTheBattleZoneAbility
    {
        public AquaSurferAbility() : base()
        {
        }

        public AquaSurferAbility(AquaSurferAbility ability) : base(ability)
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
                if (duel.CreaturePermanents.Any())
                {
                    return new GuidSelection(Controller, duel.CreaturePermanents.Select(x => x.Id), 0, 1);
                }
                else
                {
                    return null;
                }
            }
            else
            {
                foreach (var creature in (decision as GuidDecision).Decision.Select(x => duel.GetPermanent(x)))
                {
                    duel.GetPlayer(creature.Controller).ReturnFromBattleZoneToHand(creature, duel);
                }
                return null;
            }
        }
    }
}
