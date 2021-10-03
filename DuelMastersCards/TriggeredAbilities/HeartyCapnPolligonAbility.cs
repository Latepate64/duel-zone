using DuelMastersModels;
using DuelMastersModels.Abilities;
using DuelMastersModels.Choices;
using DuelMastersModels.GameEvents;
using DuelMastersModels.Steps;
using System.Linq;

namespace DuelMastersCards.TriggeredAbilities
{
    public class HeartyCapnPolligonAbility : AtTheEndOfYourTurnAbility
    {
        public HeartyCapnPolligonAbility() : base()
        {
        }

        public HeartyCapnPolligonAbility(HeartyCapnPolligonAbility ability) : base(ability)
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

        public override bool CanTrigger(GameEvent gameEvent, Duel duel)
        {
            var foo1 = base.CanTrigger(gameEvent, duel);
            var foo2 = duel.CurrentTurn.Steps.OfType<DirectAttackStep>().Where(x => x.AttackingCreature == SourcePermanent).Any();
            return foo1 && foo2;
        }
    }
}
