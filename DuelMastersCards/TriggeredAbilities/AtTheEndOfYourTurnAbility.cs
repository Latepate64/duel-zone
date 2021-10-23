using DuelMastersModels;
using DuelMastersModels.Abilities;
using DuelMastersModels.GameEvents;
using System.Linq;

namespace DuelMastersCards.TriggeredAbilities
{
    public class AtTheEndOfYourTurnAbility : TriggeredAbility
    {
        public AtTheEndOfYourTurnAbility(Resolvable resolvable) : base(resolvable)
        {
        }

        public AtTheEndOfYourTurnAbility(AtTheEndOfYourTurnAbility ability) : base(ability)
        {
        }

        public override bool CanTrigger(GameEvent gameEvent, Duel duel)
        {
            return gameEvent is TurnEndsEvent e && duel.Turns.Single(x => x.Id == e.Turn.Id).ActivePlayer == Controller;
        }

        public override Ability Copy()
        {
            return new AtTheEndOfYourTurnAbility(this);
        }
    }
}
