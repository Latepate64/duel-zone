using Engine;
using Engine.Abilities;
using Engine.ContinuousEffects;

namespace Cards.ContinuousEffects
{
    class ThisCreatureGetsAbilityUntilTheEndOfTheTurnEffect : AbilityAddingEffect
    {
        private readonly IAbility _ability;

        public ThisCreatureGetsAbilityUntilTheEndOfTheTurnEffect(ThisCreatureGetsAbilityUntilTheEndOfTheTurnEffect effect) : base(effect)
        {
            _ability = effect._ability.Copy();
        }

        public ThisCreatureGetsAbilityUntilTheEndOfTheTurnEffect(ICardFilter filter, IAbility ability) : base(filter, new Durations.UntilTheEndOfTheTurn(), ability)
        {
            _ability = ability;
        }

        public override IContinuousEffect Copy()
        {
            return new ThisCreatureGetsAbilityUntilTheEndOfTheTurnEffect(this);
        }

        public override string ToString()
        {
            return $"This creature gets \"{_ability.ToString().ToLower()}\" until the end of the turn.";
        }
    }
}
