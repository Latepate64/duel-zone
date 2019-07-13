using DuelMastersModels.GameActions.TurnBasedActions;
using DuelMastersModels.PlayerActions;
using DuelMastersModels.PlayerActions.AutomaticActions;

namespace DuelMastersModels.Steps
{
    /// <summary>
    /// 502.1. The active player draws a card. This is a turn-based action.
    /// </summary>
    public class DrawStep : Step
    {
        public DrawStep(Player player) : base(player)
        {
        }

        public override PlayerAction PlayerActionRequired(Duel duel)
        {
            return null;
        }

        /// <summary>
        /// 702.3b Immediately after the draw step begins, the active player draws a card.
        /// </summary>
        public override PlayerAction ProcessTurnBasedActions(Duel duel)
        {
            return new DrawCard(duel.CurrentTurn.ActivePlayer);
            /*
            var action = new DrawCardAtDrawStep();
            action.Perform(duel);
            return null;*/
        }
    }
}
