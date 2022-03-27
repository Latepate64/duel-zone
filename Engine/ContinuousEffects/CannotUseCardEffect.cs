namespace Engine.ContinuousEffects
{
    public abstract class CannotUseCardEffect : ContinuousEffect
    {
        protected CannotUseCardEffect(CannotUseCardEffect effect) : base(effect)
        {
        }

        protected CannotUseCardEffect(ICardFilter filter, IDuration duration, params Condition[] conditions) : base(filter, duration, conditions)
        {
        }
    }
}
