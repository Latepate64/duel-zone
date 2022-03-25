namespace Engine.ContinuousEffects
{
    public abstract class BlockerEffect : ContinuousEffect
    {
        public ICardFilter BlockableCreatures { get; }

        public BlockerEffect(ICardFilter filter, ICardFilter blockableCreatures, params Condition[] conditions) : base(filter, conditions)
        {
            BlockableCreatures = blockableCreatures;
        }

        public BlockerEffect(BlockerEffect effect) : base(effect)
        {
            BlockableCreatures = effect.BlockableCreatures.Copy();
        }
    }
}
