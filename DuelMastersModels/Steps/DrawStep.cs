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

        public override IPlayerAction PlayerActionRequired(IDuel duel)
        {
            return null;
        }

        /// <summary>
        /// 702.3b Immediately after the draw step begins, the active player draws a card.
        /// </summary>
        public override IPlayerAction ProcessTurnBasedActions(IDuel duel)
        {
            return new DrawCard(duel.TurnManager.CurrentTurn.ActivePlayer);
            /*
            var action = new DrawCardAtDrawStep();
            action.Perform(duel);
            return null;*/
        }
    }
}
