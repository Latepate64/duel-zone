using Engine;
using Engine.Abilities;
using Engine.ContinuousEffects;

namespace Cards.ContinuousEffects
{
    class ThisCreatureGetsAbilityUntilTheEndOfTheTurnEffect : AddAbilitiesUntilEndOfTurnEffect
    {
        private readonly IAbility _ability;

        public ThisCreatureGetsAbilityUntilTheEndOfTheTurnEffect(ThisCreatureGetsAbilityUntilTheEndOfTheTurnEffect effect) : base(effect)
        {
            _ability = effect._ability.Copy();
        }

        public ThisCreatureGetsAbilityUntilTheEndOfTheTurnEffect(IAbility ability, params Engine.ICard[] cards) : base(ability, cards)
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
