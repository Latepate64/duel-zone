using System;

namespace DuelMastersModels.Abilities.Triggered
{
    /// <summary>
    /// 603.1. Triggered abilities have a trigger condition and an effect. They are written as “[When/Whenever/At] [trigger condition or event], [effect]. [Instructions (if any).]”
    /// </summary>
    public abstract class TriggeredAbility : NonStaticAbility
    {
        protected TriggeredAbility() : base()
        {
        }

        protected TriggeredAbility(TriggeredAbility ability) : base(ability)
        {
        }

        public TriggeredAbility Trigger(Guid source, Guid controller)
        {
            var copy = Copy() as TriggeredAbility;
            copy.Source = source;
            copy.Controller = controller;
            return copy;
        }
    }
}
