using DuelMastersModels.Choices;

namespace DuelMastersModels.Steps
{
    /// <summary>
    /// 501.1 The active player determines which cards they control will untap. Then they untap them all simultaneously. This is a turn-based action. Normally, all of a player’s cards untap, but effects can keep one or more of a player’s cards from untapping.
    /// </summary>
    internal class StartOfTurnStep : Step, ITurnBasedActionable
    {
        internal StartOfTurnStep(IPlayer player) : base(player)
        {
        }

        /// <summary>
        /// 702.3a The active player untaps their cards in the battle zone and mana zone simultaneously. 
        /// </summary>
        public IChoice PerformTurnBasedActions(IDuel duel)
        {
            return ActivePlayer.UntapCardsInBattleZoneAndManaZone();
        }
    }
}
