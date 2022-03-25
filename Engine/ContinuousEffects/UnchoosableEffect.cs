namespace Engine.ContinuousEffects
{
    public abstract class UnchoosableEffect : ContinuousEffect
    {
        protected UnchoosableEffect(ICardFilter filter) : base(filter)
        {
        }

        protected UnchoosableEffect(UnchoosableEffect effect) : base(effect)
        {
        }
    }
}
