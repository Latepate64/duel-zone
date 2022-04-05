using Cards.StaticAbilities;
using Engine;
using Engine.ContinuousEffects;

namespace Cards.ContinuousEffects
{
    class ThisCreatureGetsPowerAttackerUntilTheEndOfTheTurnEffect : AddAbilitiesUntilEndOfTurnEffect
    {
        private readonly int _power;

        public ThisCreatureGetsPowerAttackerUntilTheEndOfTheTurnEffect(ThisCreatureGetsPowerAttackerUntilTheEndOfTheTurnEffect effect) : base(effect)
        {
            _power = effect._power;
        }

        public ThisCreatureGetsPowerAttackerUntilTheEndOfTheTurnEffect(int power, params ICard[] cards) : base(new CardFilters.TargetsFilter(cards), new PowerAttackerAbility(power))
        {
            _power = power;
        }

        public override IContinuousEffect Copy()
        {
            return new ThisCreatureGetsPowerAttackerUntilTheEndOfTheTurnEffect(this);
        }

        public override string ToString()
        {
            return $"This creature has \"power attacker +{_power}\" until the end of the turn.";
        }
    }
}
