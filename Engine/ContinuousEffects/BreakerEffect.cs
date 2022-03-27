namespace Engine.ContinuousEffects
{
    public abstract class BreakerEffect : ContinuousEffect
    {
        protected BreakerEffect(IDuration duration, params Condition[] conditions) : base(new TargetFilter(), duration, conditions)
        {
        }

        protected BreakerEffect(BreakerEffect effect) : base(effect)
        {
        }

        public abstract int GetAmount();
    }
}
