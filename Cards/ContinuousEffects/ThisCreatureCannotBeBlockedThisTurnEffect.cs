﻿using Engine;
using Engine.ContinuousEffects;

namespace Cards.ContinuousEffects
{
    class ThisCreatureCannotBeBlockedThisTurnEffect : UntilEndOfTurnEffect, IUnblockableEffect
    {
        public ThisCreatureCannotBeBlockedThisTurnEffect() : base()
        {
        }

        public bool Applies(ICard attacker, ICard blocker, IGame game)
        {
            return attacker.Id == game.GetAbility(SourceAbility).Source;
        }

        public override IContinuousEffect Copy()
        {
            return new ThisCreatureCannotBeBlockedThisTurnEffect();
        }

        public override string ToString()
        {
            return "This creature can't be blocked this turn.";
        }
    }
}
