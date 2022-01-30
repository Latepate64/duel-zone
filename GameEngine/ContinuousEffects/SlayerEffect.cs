using Engine.Durations;

namespace Engine.ContinuousEffects
{
    public class SlayerEffect : ContinuousEffect
    {
        public SlayerEffect(CardFilter filter, Duration duration) : base(filter, duration)
        {

        }

        public SlayerEffect(SlayerEffect effect) : base(effect)
        {
        }

        public override ContinuousEffect Copy()
        {
            return new SlayerEffect(this);
        }
    }
}
