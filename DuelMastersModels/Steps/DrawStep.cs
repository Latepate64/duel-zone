using DuelMastersModels.GameActions.TurnBasedActions;
using DuelMastersModels.PlayerActions;

namespace DuelMastersModels.Steps
{
    /// <summary>
    /// 502.1. The active player draws a card. This is a turn-based action.
    /// </summary>
    public class DrawStep : Step
    {
        public DrawStep(Player player) : base(player, "Draw")
        {
        }

        public override PlayerAction PlayerActionRequired()
        {
            return null;
        }

        /// <summary>
        /// 702.3b Immediately after the draw step begins, the active player draws a card.
        /// </summary>
        public override void ProcessTurnBasedActions(Duel duel)
        {
            var action = new DrawCardAtDrawStep();
            action.Perform(duel);
        }
    }
}
