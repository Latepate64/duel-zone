using Common.GameEvents;
using Engine;

namespace Cards.Durations
{
    public class UntilTheEndOfTheTurn : Duration
    {
        public override IDuration Copy()
        {
            return new UntilTheEndOfTheTurn();
        }

        public override bool ShouldExpire(IGameEvent gameEvent)
        {
            return gameEvent is PhaseBegunEvent phase && phase.PhaseOrStep == PhaseOrStep.EndOfTurn;
        }

        public override string ToString()
        {
            return "until the end of the turn";
        }
    }
}
