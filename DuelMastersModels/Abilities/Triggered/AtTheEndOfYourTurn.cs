using System;

namespace DuelMastersModels.Abilities.TriggeredAbilities
{
    public abstract class AtTheEndOfYourTurn : TriggeredAbility
    {
        protected AtTheEndOfYourTurn(Guid source, Guid controller) : base(source, controller)
        {
        }

        protected AtTheEndOfYourTurn(TriggeredAbility ability) : base(ability)
        {
        }

        public override bool CanTrigger(Duel duel)
        {
            return duel.CurrentTurn.ActivePlayer == Controller;
        }
    }
}
