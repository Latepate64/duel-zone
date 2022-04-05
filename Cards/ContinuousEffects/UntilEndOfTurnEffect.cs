using Common.GameEvents;
using Engine;
using Engine.ContinuousEffects;

namespace Cards.ContinuousEffects
{
    abstract class UntilEndOfTurnEffect : ContinuousEffect, IDuration
    {
        protected UntilEndOfTurnEffect() : base()
        {
        }

        protected UntilEndOfTurnEffect(UntilEndOfTurnEffect effect) : base(effect)
        {
        }

        public bool ShouldExpire(IGameEvent gameEvent)
        {
            return gameEvent is PhaseBegunEvent phase && phase.PhaseOrStep == PhaseOrStep.EndOfTurn;
        }
    }
}
