using System;

namespace DuelMastersModels.Abilities.TriggeredAbilities
{
    public abstract class AtTheEndOfTurn : TriggeredAbility
    {
        public Guid Turn { get; }

        protected AtTheEndOfTurn(Guid source, Guid controller, Guid turn) : base(source, controller)
        {
            Turn = turn;
        }

        protected AtTheEndOfTurn(TriggeredAbility ability) : base(ability)
        {
        }

        public override bool CanTrigger(Duel duel)
        {
            return duel.CurrentTurn.Id == Turn;
        }
    }
}
