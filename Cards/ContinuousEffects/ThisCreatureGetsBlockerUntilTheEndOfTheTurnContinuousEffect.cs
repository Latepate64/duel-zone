﻿using Engine;
using Engine.ContinuousEffects;
using Engine.Durations;

namespace Cards.ContinuousEffects
{
    class ThisCreatureGetsBlockerUntilTheEndOfTheTurnContinuousEffect : AbilityAddingEffect
    {
        public ThisCreatureGetsBlockerUntilTheEndOfTheTurnContinuousEffect(AbilityAddingEffect effect) : base(effect)
        {
        }

        public ThisCreatureGetsBlockerUntilTheEndOfTheTurnContinuousEffect(params ICard[] cards) : base(new CardFilters.TargetsFilter(cards), new UntilTheEndOfTheTurn(), new StaticAbilities.BlockerAbility())
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