﻿using Common.GameEvents;
using Engine;
using Engine.ContinuousEffects;

namespace Cards.ContinuousEffects
{
    abstract class UntilEndOfTurnEffect : ContinuousEffect, IDuration
    {
        protected UntilEndOfTurnEffect(ContinuousEffect effect) : base(effect)
        {
        }

        protected UntilEndOfTurnEffect(ICardFilter filter) : base(filter, null)
        {
        }

        public bool ShouldExpire(IGameEvent gameEvent)
        {
            return gameEvent is PhaseBegunEvent phase && phase.PhaseOrStep == PhaseOrStep.EndOfTurn;
        }
    }
}