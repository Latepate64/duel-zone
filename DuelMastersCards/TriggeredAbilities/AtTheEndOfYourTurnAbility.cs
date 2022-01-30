using Engine;
using Engine.Abilities;
using Engine.GameEvents;
using System.Linq;

namespace Cards.TriggeredAbilities
{
    public class AtTheEndOfYourTurnAbility : TriggeredAbility
    {
        public AtTheEndOfYourTurnAbility(OneShotEffect effect) : base(effect)
        {
        }

        public AtTheEndOfYourTurnAbility(AtTheEndOfYourTurnAbility ability) : base(ability)
        {
        }

        public override bool CanTrigger(GameEvent gameEvent, Game game)
        {
            return gameEvent is TurnEndsEvent e && game.Turns.Single(x => x.Id == e.Turn.Id).ActivePlayer == Owner && CheckInterveningIfClause(game);
        }

        public override Ability Copy()
        {
            return new AtTheEndOfYourTurnAbility(this);
        }
    }
}
