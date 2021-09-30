using System;

namespace DuelMastersModels.Abilities.Triggered
{
    public abstract class WheneverThisCreatureAttacksAbility : TriggeredAbility
    {
        protected WheneverThisCreatureAttacksAbility(Guid source, Guid controller) : base(source, controller)
        {
        }

        protected WheneverThisCreatureAttacksAbility(TriggeredAbility ability) : base(ability)
        {
        }
    }
}
