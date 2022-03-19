using Common.GameEvents;
using Engine.Durations;

namespace Engine.Steps
{
    /// <summary>
    /// 511.1. The ability to trigger at every "turn's end" triggers. The induced effect is a turn We declare solutions to be resolved from the layer and process them in order.
    /// </summary>
    public class EndOfTurnPhase : Phase, ITurnBasedActionable
    {
        public EndOfTurnPhase() : base(PhaseOrStep.EndOfTurn)
        {
        }

        public override IPhase GetNextPhase(IGame game)
        {
            return null;
        }

        public EndOfTurnPhase(EndOfTurnPhase step) : base(step) { }

        public override IPhase Copy()
        {
            return new EndOfTurnPhase(this);
        }

        public void PerformTurnBasedAction(IGame game)
        {
            game.RemoveRevokedObjects(typeof(UntilTheEndOfTheTurn));
        }
    }
}
