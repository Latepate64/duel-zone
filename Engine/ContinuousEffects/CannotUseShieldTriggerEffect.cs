using Engine.Durations;

namespace Engine.ContinuousEffects
{
    public abstract class CannotUseShieldTriggerEffect : ContinuousEffect
    {
        protected CannotUseShieldTriggerEffect(CannotUseShieldTriggerEffect effect) : base(effect)
        {
        }

        protected CannotUseShieldTriggerEffect(ICardFilter filter, params Condition[] conditions) : base(filter, conditions)
        {
        }
    }
}
