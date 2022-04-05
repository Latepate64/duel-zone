using Engine;
using Engine.ContinuousEffects;

namespace Cards.ContinuousEffects
{
    class ThisCreatureGetsBlockerUntilTheEndOfTheTurnContinuousEffect : AddAbilitiesUntilEndOfTurnEffect
    {
        public ThisCreatureGetsBlockerUntilTheEndOfTheTurnContinuousEffect(ThisCreatureGetsBlockerUntilTheEndOfTheTurnContinuousEffect effect) : base(effect)
        {
        }

        public ThisCreatureGetsBlockerUntilTheEndOfTheTurnContinuousEffect(params ICard[] cards) : base(new CardFilters.TargetsFilter(cards), new StaticAbilities.BlockerAbility())
        {
        }

        public override IContinuousEffect Copy()
        {
            return new ThisCreatureGetsBlockerUntilTheEndOfTheTurnContinuousEffect();
        }

        public override string ToString()
        {
            return "This creature has \"blocker\" until the end of the turn.";
        }
    }
}
