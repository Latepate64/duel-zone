namespace Engine.ContinuousEffects
{
    public class BlockerEffect : ContinuousEffect
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

        public override ContinuousEffect Copy()
        {
            return new BlockerEffect(this);
        }

        public override string ToString()
        {
            return "Blocker";
        }
    }
}
