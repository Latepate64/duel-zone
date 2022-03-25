namespace Engine.ContinuousEffects
{
    public abstract class BlockerEffect : ContinuousEffect
    {
        public ICardFilter BlockableCreatures { get; }

        protected BlockerEffect(ICardFilter filter, ICardFilter blockableCreatures, params Condition[] conditions) : base(filter, conditions)
        {
            BlockableCreatures = blockableCreatures;
        }

        protected BlockerEffect(BlockerEffect effect) : base(effect)
        {
            BlockableCreatures = effect.BlockableCreatures.Copy();
        }
    }
}
