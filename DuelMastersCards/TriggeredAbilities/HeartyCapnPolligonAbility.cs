using DuelMastersModels;
using DuelMastersModels.Abilities;
using DuelMastersModels.GameEvents;
using DuelMastersModels.Steps;
using System.Linq;

namespace DuelMastersCards.TriggeredAbilities
{
    public class HeartyCapnPolligonAbility : AtTheEndOfYourTurnAbility
    {
        public HeartyCapnPolligonAbility(OneShotEffect effect) : base(effect)
        {
        }

        public HeartyCapnPolligonAbility(AtTheEndOfYourTurnAbility ability) : base(ability)
        {
        }

        public override bool CanTrigger(GameEvent gameEvent, Game game)
        {
            var foo1 = base.CanTrigger(gameEvent, game);
            var foo2 = game.CurrentTurn.Steps.OfType<DirectAttackStep>().Where(x => x.AttackingCreature == Source).Any();
            return foo1 && foo2;
        }
    }
}
