using Engine.Durations;

namespace Engine.ContinuousEffects
{
    public class SpeedAttackerEffect : ContinuousEffect
    {
        public SpeedAttackerEffect(CardFilter filter, Duration duration) : base(filter, duration)
        {
        }

        public SpeedAttackerEffect(SpeedAttackerEffect effect) : base(effect)
        {
        }

        public override ContinuousEffect Copy()
        {
            return new SpeedAttackerEffect(this);
        }
    }
}
