using DuelMastersModels;
using DuelMastersModels.Abilities;
using DuelMastersModels.GameEvents;
using System;

namespace DuelMastersCards.TriggeredAbilities
{
    public abstract class AtTheEndOfTurnAbility : TriggeredAbility
    {
        public Guid Turn { get; }

        protected AtTheEndOfTurnAbility(Guid turn) : base()
        {
            Turn = turn;
        }

        protected AtTheEndOfTurnAbility(AtTheEndOfTurnAbility ability) : base(ability)
        {
        }

        public override bool CanTrigger(GameEvent gameEvent, Duel duel)
        {
            return gameEvent is TurnEndsEvent e && e.Turn == Turn;
        }
    }
}
