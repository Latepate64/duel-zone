using Engine.Durations;

namespace Engine.ContinuousEffects
{
    public class BlockerEffect : ContinuousEffect
    {
        public BlockerEffect(CardFilter filter, Duration duration) : base(filter, duration)
        {

        }

        public BlockerEffect(BlockerEffect effect) : base(effect)
        {
        }

        public override ContinuousEffect Copy()
        {
            return new BlockerEffect(this);
        }
    }
}
