namespace Engine.ContinuousEffects
{
    public abstract class CannotUseCardEffect : ContinuousEffect
    {
        protected CannotUseCardEffect(CannotUseCardEffect effect) : base(effect)
        {
        }

        protected CannotUseCardEffect(ICardFilter filter, params Condition[] conditions) : base(filter, conditions)
        {
        }
    }
}
