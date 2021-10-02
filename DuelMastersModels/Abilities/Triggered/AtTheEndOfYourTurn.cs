using DuelMastersModels.GameEvents;
using System.Linq;

namespace DuelMastersModels.Abilities.Triggered
{
    public abstract class AtTheEndOfYourTurn : TriggeredAbility
    {
        protected AtTheEndOfYourTurn() : base()
        {
        }

        protected AtTheEndOfYourTurn(TriggeredAbility ability) : base(ability)
        {
        }

        public override bool CanTrigger(GameEvent gameEvent, Duel duel)
        {
            return gameEvent is TurnEndsEvent e && duel.Turns.Single(x => x.Id == e.Turn).ActivePlayer == Controller;
        }
    }
}
