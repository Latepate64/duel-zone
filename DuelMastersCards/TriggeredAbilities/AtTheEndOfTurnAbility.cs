using DuelMastersModels;
using DuelMastersModels.Abilities;
using DuelMastersModels.GameEvents;
using System;

namespace DuelMastersCards.TriggeredAbilities
{
    public class AtTheEndOfTurnAbility : TriggeredAbility
    {
        public Guid Turn { get; }

        public AtTheEndOfTurnAbility(Guid turn, Resolvable resolvable) : base(resolvable)
        {
            Turn = turn;
        }

        public AtTheEndOfTurnAbility(AtTheEndOfTurnAbility ability) : base(ability)
        {
        }

        public override bool CanTrigger(GameEvent gameEvent, Duel duel)
        {
            return gameEvent is TurnEndsEvent e && e.Turn.Id == Turn;
        }

        public override Ability Copy()
        {
            return new AtTheEndOfTurnAbility(this);
        }
    }
}
