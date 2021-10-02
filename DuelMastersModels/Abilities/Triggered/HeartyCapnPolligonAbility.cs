using DuelMastersModels.Choices;
using DuelMastersModels.Steps;
using System;
using System.Linq;

namespace DuelMastersModels.Abilities.Triggered
{
    public class HeartyCapnPolligonAbility : AtTheEndOfYourTurn
    {
        public HeartyCapnPolligonAbility() : base()
        {
        }

        public HeartyCapnPolligonAbility(TriggeredAbility ability) : base(ability)
        {
        }

        public override Ability Copy()
        {
            return new HeartyCapnPolligonAbility(this);
        }

        public override Choice Resolve(Duel duel, Decision decision)
        {
            // At the end of each of your turns, if this creature broke any shields that turn, return it to your hand.
            duel.GetPlayer(Controller).ReturnFromBattleZoneToHand(duel.GetPermanent(Source), duel);
            return null;
        }

        public override bool CanTrigger(Duel duel, Guid turn, Guid controller)
        {
            return base.CanTrigger(duel, turn, controller) && duel.CurrentTurn.Steps.OfType<DirectAttackStep>().Where(x => x.AttackingCreature == Source).Any();
        }
    }
}
