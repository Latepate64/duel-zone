namespace Engine.ContinuousEffects
{
    public abstract class CannotUseShieldTriggerEffect : ContinuousEffect
    {
        protected CannotUseShieldTriggerEffect(CannotUseShieldTriggerEffect effect) : base(effect)
        {
        }

        protected CannotUseShieldTriggerEffect(ICardFilter filter, IDuration duration) : base(filter, duration)
        {
        }
    }
}
