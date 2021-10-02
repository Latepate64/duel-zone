using DuelMastersModels.GameEvents;
using System;

namespace DuelMastersModels.Abilities.Triggered
{
    public abstract class AtTheEndOfTurn : TriggeredAbility
    {
        public Guid Turn { get; }

        protected AtTheEndOfTurn(Guid turn) : base()
        {
            Turn = turn;
        }

        protected AtTheEndOfTurn(TriggeredAbility ability) : base(ability)
        {
        }

        public override bool CanTrigger(GameEvent gameEvent, Duel duel)
        {
            return gameEvent is TurnEndsEvent e && e.Turn == Turn;
        }
    }
}
