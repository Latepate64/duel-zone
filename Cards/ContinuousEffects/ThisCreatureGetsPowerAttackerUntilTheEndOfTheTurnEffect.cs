using Cards.StaticAbilities;
using Engine;
using Engine.ContinuousEffects;
using Engine.Durations;

namespace Cards.ContinuousEffects
{
    class ThisCreatureGetsPowerAttackerUntilTheEndOfTheTurnEffect : AbilityAddingEffect
    {
        public ThisCreatureGetsPowerAttackerUntilTheEndOfTheTurnEffect(ThisCreatureGetsPowerAttackerUntilTheEndOfTheTurnEffect effect) : base(effect)
        {
        }

        public ThisCreatureGetsPowerAttackerUntilTheEndOfTheTurnEffect(params ICard[] cards) : base(new CardFilters.TargetsFilter(cards), new UntilTheEndOfTheTurn(), new PowerAttackerAbility(2000))
        {
        }

        public override IContinuousEffect Copy()
        {
            return new ThisCreatureGetsPowerAttackerUntilTheEndOfTheTurnEffect(this);
        }

        public override string ToString()
        {
            return "This creature has \"power attacker +2000\" until the end of the turn.";
        }
    }
}
