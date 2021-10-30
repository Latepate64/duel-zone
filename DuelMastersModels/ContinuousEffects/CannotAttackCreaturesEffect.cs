using DuelMastersModels.Durations;

namespace DuelMastersModels.ContinuousEffects
{
    public class CannotAttackCreaturesEffect : ContinuousEffect
    {
        public CannotAttackCreaturesEffect(CardFilter filter, Duration duration) : base(filter, duration)
        {

        }

        public CannotAttackCreaturesEffect(CannotAttackCreaturesEffect effect) : base(effect)
        {
        }

        public override ContinuousEffect Copy()
        {
            return new CannotAttackCreaturesEffect(this);
        }
    }
}
