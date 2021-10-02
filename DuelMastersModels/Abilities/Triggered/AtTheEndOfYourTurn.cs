using System;
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

        public virtual bool CanTrigger(Duel duel, Guid turn, Guid controller)
        {
            return duel.Turns.Single(x => x.Id == turn).ActivePlayer == controller;
        }
    }
}
