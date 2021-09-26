using System;

namespace DuelMastersModels.Abilities.TriggeredAbilities
{
    /// <summary>
    /// 603.1. Triggered abilities have a trigger condition and an effect. They are written as “[When/Whenever/At] [trigger condition or event], [effect]. [Instructions (if any).]”
    /// </summary>
    public abstract class TriggeredAbility : NonStaticAbility
    {
        protected TriggeredAbility(Guid source, Guid controller) : base(source, controller)
        {
        }

        protected TriggeredAbility(TriggeredAbility ability) : base(ability)
        {
        }

        public virtual bool CanTrigger(Duel duel)
        {
            return true;
        }
    }
}
