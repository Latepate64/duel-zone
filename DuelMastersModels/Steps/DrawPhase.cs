namespace DuelMastersModels.Steps
{
    /// <summary>
    /// 502.1. The active player draws a card. This is a turn-based action.
    /// </summary>
    public class DrawPhase : Phase, ITurnBasedActionable
    {
        public DrawPhase()
        {
        }

        public override Phase GetNextPhase(Game game)
        {
            return new ChargePhase();
        }

        /// <summary>
        /// 702.3b Immediately after the draw step begins, the active player draws a card.
        /// </summary>
        /// <returns></returns>
        public void PerformTurnBasedAction(Game game)
        {
            game.GetPlayer(game.CurrentTurn.ActivePlayer).DrawCards(1, game);
        }

        public override Phase Copy()
        {
            return new DrawPhase(this);
        }

        public DrawPhase(DrawPhase step) : base(step)
        {
        }
    }
}
