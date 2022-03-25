using Engine.Durations;

namespace Engine.ContinuousEffects
{
    public abstract class CanBeAttackedAsThoughTappedEffect : ContinuousEffect
    {
        protected CanBeAttackedAsThoughTappedEffect(CanBeAttackedAsThoughTappedEffect effect) : base(effect)
        {
        }

        protected CanBeAttackedAsThoughTappedEffect(ICardFilter filter, IDuration duration) : base(filter, duration)
        {
        }
    }
}
