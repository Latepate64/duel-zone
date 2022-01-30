using Engine.Durations;

namespace Engine.ContinuousEffects
{
    public class CannotAttackPlayersEffect : ContinuousEffect
    {
        public CannotAttackPlayersEffect(CardFilter filter, Duration duration) : base(filter, duration)
        {

        }

        public CannotAttackPlayersEffect(CannotAttackPlayersEffect effect) : base(effect)
        {
        }

        public override ContinuousEffect Copy()
        {
            return new CannotAttackPlayersEffect(this);
        }
    }
}
