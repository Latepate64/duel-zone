using Engine;
using Engine.GameEvents;
using Engine.Steps;

namespace Cards.ContinuousEffects
{
    abstract class UntilEndOfTurnEffect : ContinuousEffect, IExpirable
    {
        protected UntilEndOfTurnEffect() : base()
        {
        }

        protected UntilEndOfTurnEffect(UntilEndOfTurnEffect effect) : base(effect)
        {
        }

        public bool ShouldExpire(IGameEvent gameEvent, IGame game)
        {
            return gameEvent is PhaseBegunEvent phase && phase.Phase.Type == PhaseOrStep.EndOfTurn;
        }
    }
}
