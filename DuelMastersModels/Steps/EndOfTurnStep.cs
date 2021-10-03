using DuelMastersModels.Choices;
using DuelMastersModels.Effects.Durations;
using DuelMastersModels.GameEvents;

namespace DuelMastersModels.Steps
{
    /// <summary>
    /// 511.1. The ability to trigger at every "turn's end" triggers. The induced effect is a turn We declare solutions to be resolved from the layer and process them in order.
    /// </summary>
    public class EndOfTurnStep : TurnBasedActionStep
    {
        public EndOfTurnStep()
        {
        }

        public override Step GetNextStep(Duel duel)
        {
            return null;
        }

        public EndOfTurnStep(EndOfTurnStep step) : base(step) { }

        public override Step Copy()
        {
            return new EndOfTurnStep(this);
        }

        public override Choice PerformTurnBasedAction(Duel duel, Decision decision)
        {
            _ = duel.ContinuousEffects.RemoveAll(x => x.Duration is UntilTheEndOfTheTurn);
            duel.Trigger(new TurnEndsEvent(duel.CurrentTurn.Id));
            return null;
        }
    }
}
