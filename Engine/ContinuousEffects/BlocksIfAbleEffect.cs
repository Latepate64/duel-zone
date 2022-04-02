namespace Engine.ContinuousEffects
{
    public abstract class BlocksIfAbleEffect : ContinuousEffect
    {
        protected BlocksIfAbleEffect(ICardFilter filter, IDuration duration) : base(filter, duration)
        {
        }

        protected BlocksIfAbleEffect(BlocksIfAbleEffect effect) : base(effect)
        {
        }
    }
}
