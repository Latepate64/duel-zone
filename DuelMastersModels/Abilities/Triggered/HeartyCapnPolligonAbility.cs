using DuelMastersModels.Choices;
using DuelMastersModels.Steps;
using System;
using System.Linq;

namespace DuelMastersModels.Abilities.Triggered
{
    public class HeartyCapnPolligonAbility : AtTheEndOfYourTurn
    {
        public HeartyCapnPolligonAbility(Guid source, Guid controller) : base(source, controller)
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
            duel.GetPlayer(Controller).ReturnFromBattleZoneToHand(duel.GetCard(Source), duel);
            return null;
        }

        public override bool CanTrigger(Duel duel)
        {
            //TODO: It should be checked that source did not leave battle zone after breaking the shield and before this ability triggers.
            return base.CanTrigger(duel) && duel.CurrentTurn.Steps.OfType<DirectAttackStep>().Where(x => x.AttackingCreature == Source).Any();
        }
    }
}
