using DuelMastersModels.PlayerActions;
using DuelMastersModels.PlayerActions.AutomaticActions;

namespace DuelMastersModels.Steps
{
    /// <summary>
    /// 502.1. The active player draws a card. This is a turn-based action.
    /// </summary>
    internal class DrawStep : Step
    {
        internal DrawStep(IPlayer player) : base(player)
        {
        }

        internal override PlayerAction PlayerActionRequired(IDuel duel)
        {
            return null;
        }

        /// <summary>
        /// 702.3b Immediately after the draw step begins, the active player draws a card.
        /// </summary>
        internal override PlayerAction ProcessTurnBasedActions(IDuel duel)
        {
            return new DrawCard(duel.CurrentTurn.ActivePlayer);
            /*
            var action = new DrawCardAtDrawStep();
            action.Perform(duel);
            return null;*/
        }
    }
}
