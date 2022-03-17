namespace Engine.ContinuousEffects
{
    public abstract class BreakerEffect : ContinuousEffect
    {
        protected BreakerEffect(params Condition[] conditions) : base(new TargetFilter(), conditions)
        {
        }

        protected BreakerEffect(ContinuousEffect effect) : base(effect)
        {
        }

        public abstract int GetAmount();
    }
}
