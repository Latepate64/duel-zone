using DuelMastersModels;
using DuelMastersModels.Abilities;
using DuelMastersModels.GameEvents;
using DuelMastersModels.Steps;
using System.Linq;

namespace DuelMastersCards.TriggeredAbilities
{
    public class HeartyCapnPolligonAbility : AtTheEndOfYourTurnAbility
    {
        public HeartyCapnPolligonAbility(Resolvable resolvable) : base(resolvable)
        {
        }

        public HeartyCapnPolligonAbility(AtTheEndOfYourTurnAbility ability) : base(ability)
        {
        }

        public override bool CanTrigger(GameEvent gameEvent, Duel duel)
        {
            var foo1 = base.CanTrigger(gameEvent, duel);
            var foo2 = duel.CurrentTurn.Steps.OfType<DirectAttackStep>().Where(x => x.AttackingCreature == Source).Any();
            return foo1 && foo2;
        }
    }
}
