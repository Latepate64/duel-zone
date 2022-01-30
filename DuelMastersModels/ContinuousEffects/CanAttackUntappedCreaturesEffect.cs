using Engine.Durations;

namespace Engine.ContinuousEffects
{
    public class CanAttackUntappedCreaturesEffect : ContinuousEffect
    {
        public CanAttackUntappedCreaturesEffect(ContinuousEffect effect) : base(effect)
        {
        }

        public CanAttackUntappedCreaturesEffect(CardFilter filter, Duration duration) : base(filter, duration)
        {
        }

        public override ContinuousEffect Copy()
        {
            return new CanAttackUntappedCreaturesEffect(this);
        }
    }
}
