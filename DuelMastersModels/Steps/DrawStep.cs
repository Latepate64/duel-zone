using DuelMastersModels.Choices;

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

        public override IChoice PlayerActionRequired(IDuel duel)
        {
            return null;
        }

        /// <summary>
        /// 702.3b Immediately after the draw step begins, the active player draws a card.
        /// </summary>
        public override IChoice ProcessTurnBasedActions(IDuel duel)
        {
            ActivePlayer.DrawCards(1);
            return null;
        }
    }
}
