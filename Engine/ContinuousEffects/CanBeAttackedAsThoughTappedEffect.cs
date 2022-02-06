using Engine.Durations;

namespace Engine.ContinuousEffects
{
    public class CanBeAttackedAsThoughTappedEffect : ContinuousEffect
    {
        public CanBeAttackedAsThoughTappedEffect(ContinuousEffect effect) : base(effect)
        {
        }

        public CanBeAttackedAsThoughTappedEffect(CardFilter filter, Duration duration) : base(filter, duration)
        {
        }

        public override ContinuousEffect Copy()
        {
            return new CanBeAttackedAsThoughTappedEffect(this);
        }

        public override string ToString()
        {
            return $"{Filter} can be attacked attacked as though those were tapped{GetDurationAsText()}.";
        }
    }
}
