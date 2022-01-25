using DuelMastersModels;
using DuelMastersModels.Abilities;
using DuelMastersModels.GameEvents;
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

        public override Ability Copy()
        {
            return new HeartyCapnPolligonAbility(this);
        }

        public override bool CheckInterveningIfClause(Game game)
        {
            // if this creature broke any shields that turn
            return game.CurrentTurn.Phases.SelectMany(x => x.GameEvents).OfType<ShieldsBrokenEvent>().Any(x => x.Attacker.Id == Source);
        }
    }
}
