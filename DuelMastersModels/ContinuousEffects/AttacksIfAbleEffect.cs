using DuelMastersModels.Durations;

namespace DuelMastersModels.ContinuousEffects
{
    public class AttacksIfAbleEffect : ContinuousEffect
    {
        public AttacksIfAbleEffect(CardFilter filter, Duration duration) : base(filter, duration)
        {

        }

        public AttacksIfAbleEffect(AttacksIfAbleEffect effect) : base(effect)
        {
        }

        public override ContinuousEffect Copy()
        {
            return new AttacksIfAbleEffect(this);
        }
    }
}
