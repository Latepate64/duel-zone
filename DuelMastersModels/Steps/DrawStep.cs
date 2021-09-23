using DuelMastersModels.Choices;

namespace DuelMastersModels.Steps
{
    /// <summary>
    /// 502.1. The active player draws a card. This is a turn-based action.
    /// </summary>
    public class DrawStep : TurnBasedActionStep
    {
        public DrawStep()
        {
        }

        public override Step GetNextStep()
        {
            return new ChargeStep();
        }

        /// <summary>
        /// 702.3b Immediately after the draw step begins, the active player draws a card.
        /// </summary>
        /// <returns></returns>
        public override Choice PerformTurnBasedAction(Duel duel, Choice choice)
        {
            duel.CurrentTurn.ActivePlayer.DrawCards(1);
            return null;
        }
    }
}
