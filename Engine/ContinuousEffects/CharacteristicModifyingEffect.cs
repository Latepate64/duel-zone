using Engine.Durations;

namespace Engine.ContinuousEffects
{
    public abstract class CharacteristicModifyingEffect : ContinuousEffect
    {
        protected CharacteristicModifyingEffect(ICardFilter filter, IDuration duration, params Condition[] conditions) : base(filter, duration, conditions)
        {
        }

        protected CharacteristicModifyingEffect(CharacteristicModifyingEffect effect) : base(effect)
        {
        }
    }
}
