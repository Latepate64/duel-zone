namespace Engine.ContinuousEffects
{
    public abstract class BreakerEffect : ContinuousEffect
    {
        protected BreakerEffect(params Condition[] conditions) : base(conditions)
        {
        }

        protected BreakerEffect(ContinuousEffect effect) : base(effect)
        {
        }

        public abstract int GetAmount();
    }
}
