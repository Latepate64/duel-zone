using DuelMastersModels;
using DuelMastersModels.Abilities;
using DuelMastersModels.GameEvents;
using System.Linq;

namespace DuelMastersCards.TriggeredAbilities
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
            return gameEvent is TurnEndsEvent e && game.Turns.Single(x => x.Id == e.Turn.Id).ActivePlayer == Owner;
        }

        public override Ability Copy()
        {
            return new AtTheEndOfYourTurnAbility(this);
        }
    }
}
