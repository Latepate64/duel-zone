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

        public bool CanTrigger(Guid turn)
        {
            return turn == Turn;
        }
    }
}
