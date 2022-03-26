using Cards.StaticAbilities;
using Engine;
using Engine.ContinuousEffects;

namespace Cards.ContinuousEffects
{
    class ThisCreatureGetsPowerAttackerAndDoubleBreakerUntilTheEndOfTheTurnEffect : AbilityAddingEffect
    {
        public ThisCreatureGetsPowerAttackerAndDoubleBreakerUntilTheEndOfTheTurnEffect(ThisCreatureGetsPowerAttackerAndDoubleBreakerUntilTheEndOfTheTurnEffect effect) : base(effect)
        {
        }

        public ThisCreatureGetsPowerAttackerAndDoubleBreakerUntilTheEndOfTheTurnEffect(params ICard[] cards) : base(new CardFilters.TargetsFilter(cards), new Durations.UntilTheEndOfTheTurn(), new PowerAttackerAbility(4000), new DoubleBreakerAbility())
        {
        }

        public override IContinuousEffect Copy()
        {
            return new ThisCreatureGetsPowerAttackerAndDoubleBreakerUntilTheEndOfTheTurnEffect(this);
        }

        public override string ToString()
        {
            return "This creature has \"power attacker +4000\" and \"double breaker\" until the end of the turn.";
        }
    }
}
