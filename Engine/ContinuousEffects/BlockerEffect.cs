namespace Engine.ContinuousEffects
{
    public class BlockerEffect : ContinuousEffect
    {
        public BlockerEffect()
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
