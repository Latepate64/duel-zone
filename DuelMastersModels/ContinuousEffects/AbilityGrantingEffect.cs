using DuelMastersModels.Abilities;
using DuelMastersModels.Durations;

namespace DuelMastersModels.ContinuousEffects
{
    public class AbilityGrantingEffect : ContinuousEffect
    {
        public Ability Ability { get; }

        public AbilityGrantingEffect(AbilityGrantingEffect effect) : base(effect)
        {
            Ability = effect.Ability;
        }

        public AbilityGrantingEffect(CardFilter filter, Duration duration, Ability ability) : base(filter, duration)
        {
            Ability = ability;
        }

        public override ContinuousEffect Copy()
        {
            return new AbilityGrantingEffect(this);
        }
    }
}
