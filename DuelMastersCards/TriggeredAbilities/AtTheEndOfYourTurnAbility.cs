using DuelMastersModels;
using DuelMastersModels.Abilities;
using DuelMastersModels.GameEvents;
using System.Linq;

namespace DuelMastersCards.TriggeredAbilities
{
    public abstract class AtTheEndOfYourTurnAbility : TriggeredAbility
    {
        protected AtTheEndOfYourTurnAbility() : base()
        {
        }

        protected AtTheEndOfYourTurnAbility(AtTheEndOfYourTurnAbility ability) : base(ability)
        {
        }

        public override bool CanTrigger(GameEvent gameEvent, Duel duel)
        {
            return gameEvent is TurnEndsEvent e && duel.Turns.Single(x => x.Id == e.Turn).ActivePlayer == Controller;
        }
    }
}
