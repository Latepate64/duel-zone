using Engine;
using Engine.GameEvents;

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
            throw new System.NotImplementedException();
            //return gameEvent is PhaseBegunEvent phase && phase.PhaseOrStep == PhaseOrStep.EndOfTurn;
        }
    }
}
