namespace Engine.ContinuousEffects
{
    public abstract class BreakerEffect : ContinuousEffect
    {
        protected BreakerEffect()
        {
        }

        protected BreakerEffect(ContinuousEffect effect) : base(effect)
        {
        }

        public abstract int GetAmount();
    }
}
