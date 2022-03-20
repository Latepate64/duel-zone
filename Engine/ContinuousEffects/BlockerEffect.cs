namespace Engine.ContinuousEffects
{
    public class BlockerEffect : ContinuousEffect
    {
        public BlockerEffect(ICardFilter filter, params Condition[] conditions) : base(filter, conditions)
        {
        }

        public BlockerEffect(BlockerEffect effect) : base(effect)
        {
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
