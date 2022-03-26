namespace Engine.ContinuousEffects
{
    public abstract class UnchoosableEffect : ContinuousEffect
    {
        protected UnchoosableEffect(ICardFilter filter, IDuration duration) : base(filter, duration)
        {
        }

        protected UnchoosableEffect(UnchoosableEffect effect) : base(effect)
        {
        }
    }
}
