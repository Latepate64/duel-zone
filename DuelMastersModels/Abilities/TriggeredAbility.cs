using DuelMastersModels.GameEvents;
using System;

namespace DuelMastersModels.Abilities
{
    /// <summary>
    /// 603.1. Triggered abilities have a trigger condition and an effect. They are written as “[When/Whenever/At] [trigger condition or event], [effect]. [Instructions (if any).]”
    /// </summary>
    public abstract class TriggeredAbility : ResolvableAbility
    {
        protected TriggeredAbility(OneShotEffect effect) : base(effect)
        {
        }

        protected TriggeredAbility(TriggeredAbility ability) : base(ability)
        {
        }

        public TriggeredAbility Trigger(Guid source, Guid owner)
        {
            var copy = Copy() as TriggeredAbility;
            copy.Source = source;
            copy.Owner = owner;
            copy.OneShotEffect.Source = source;
            copy.OneShotEffect.Controller = owner;
            return copy;
        }

        public abstract bool CanTrigger(GameEvent gameEvent, Game game);
    }
}
