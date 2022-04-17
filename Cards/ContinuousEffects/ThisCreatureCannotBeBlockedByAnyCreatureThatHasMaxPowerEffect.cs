﻿using Engine;
using Engine.ContinuousEffects;

namespace Cards.ContinuousEffects
{
    public class ThisCreatureCannotBeBlockedByAnyCreatureThatHasMaxPowerEffect : ContinuousEffect, IUnblockableEffect
    {
        private readonly int _power;

        public ThisCreatureCannotBeBlockedByAnyCreatureThatHasMaxPowerEffect(ThisCreatureCannotBeBlockedByAnyCreatureThatHasMaxPowerEffect effect) : base(effect)
        {
            _power = effect._power;
        }

        public ThisCreatureCannotBeBlockedByAnyCreatureThatHasMaxPowerEffect(int power) : base()
        {
            _power = power;
        }

        public bool CannotBeBlocked(ICard attacker, ICard blocker, IGame game)
        {
            return IsSourceOfAbility(attacker, game) && blocker.Power <= _power;
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