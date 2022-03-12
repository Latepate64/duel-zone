using Engine.Durations;

namespace Engine.ContinuousEffects
{
    public abstract class CharacteristicModifyingEffect : ContinuousEffect
    {
        protected CharacteristicModifyingEffect() { }

        protected CharacteristicModifyingEffect(CardFilter filter, Duration duration) : base(filter, duration)
        {
        }

        protected CharacteristicModifyingEffect(CharacteristicModifyingEffect effect) : base(effect)
        {
        }

        public abstract void Apply(Game game);
    }
}
