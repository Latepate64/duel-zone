﻿using Cards.CardFilters;
using Engine;
using Engine.ContinuousEffects;

namespace Cards.ContinuousEffects
{
    public class ThisCreatureCannotBeBlockedByAnyCreatureThatHasMaxPowerEffect : UnblockableEffect
    {
        private readonly int _power;

        public ThisCreatureCannotBeBlockedByAnyCreatureThatHasMaxPowerEffect(ThisCreatureCannotBeBlockedByAnyCreatureThatHasMaxPowerEffect effect) : base(effect)
        {
            _power = effect._power;
        }

        public ThisCreatureCannotBeBlockedByAnyCreatureThatHasMaxPowerEffect(int power) : base(new TargetFilter(), new Durations.Indefinite(), new BattleZoneMaxPowerCreatureFilter(power))
        {
            _power = power;
        }

        public override IContinuousEffect Copy()
        {
            return new ThisCreatureCannotBeBlockedByAnyCreatureThatHasMaxPowerEffect(this);
        }

        public override string ToString()
        {
            return $"This creature can't be blocked by any creature that has power {_power} or less.";
        }
    }
}