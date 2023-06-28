namespace Engine.Steps
{
    /// <summary>
    /// 502.1. The active player draws a card. This is a turn-based action.
    /// </summary>
    public class DrawPhase : Phase, ITurnBasedActionable
    {
        public DrawPhase() : base(PhaseOrStep.Draw)
        {
        }

        public override IPhase GetNextPhase(IGame game)
        {
            return new ChargePhase();
        }

        /// <summary>
        /// 702.3b Immediately after the draw step begins, the active player draws a card.
        /// </summary>
        /// <returns></returns>
        public void PerformTurnBasedAction(IGame game)
        {
           game.CurrentTurn.ActivePlayer.DrawCards(1, null);
        }

        public override IPhase Copy()
        {
            return new DrawPhase(this);
        }

        public DrawPhase(DrawPhase step) : base(step)
        {
        }
    }
}
