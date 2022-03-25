using Engine.Durations;

namespace Engine.ContinuousEffects
{
    public abstract class IgnoreCannotAttackPlayersEffects : ContinuousEffect
    {
        protected IgnoreCannotAttackPlayersEffects(IgnoreCannotAttackPlayersEffects effect) : base(effect)
        {
        }

        protected IgnoreCannotAttackPlayersEffects(ICardFilter filter, IDuration duration) : base(filter, duration)
        {
        }
    }
}
