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

        public override Step GetNextStep(Game game)
        {
            return new ChargeStep();
        }

        /// <summary>
        /// 702.3b Immediately after the draw step begins, the active player draws a card.
        /// </summary>
        /// <returns></returns>
        public override void PerformTurnBasedAction(Game game)
        {
            game.GetPlayer(game.CurrentTurn.ActivePlayer).DrawCards(1, game);
        }

        public override Step Copy()
        {
            return new DrawStep(this);
        }

        public DrawStep(DrawStep step) : base(step)
        {
        }
    }
}
