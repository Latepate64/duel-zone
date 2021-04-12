using DuelMastersModels.Choices;

namespace DuelMastersModels.Steps
{
    /// <summary>
    /// 501.1 The active player determines which cards they control will untap. Then they untap them all simultaneously. This is a turn-based action. Normally, all of a player’s cards untap, but effects can keep one or more of a player’s cards from untapping.
    /// </summary>
    public class StartOfTurnStep : Step
    {
        public StartOfTurnStep(IPlayer player, bool skipDrawStep) : base(player)
        {
            SkipDrawStep = skipDrawStep;
        }

        public bool SkipDrawStep { get; private set; }

        public override IStep GetNextStep()
        {
            // 500.6. The player who plays first skips the draw step of their first turn.
            if (SkipDrawStep)
            {
                return new ChargeStep(ActivePlayer);
            }
            else
            {
                return new DrawStep(ActivePlayer);
            }
        }

        /// <summary>
        /// 501.1 The active player determines which cards they control will untap. Then they untap them all simultaneously. This is a turn-based action. Normally, all of a player’s cards untap, but effects can keep one or more of a player’s cards from untapping.
        /// </summary>
        /// <returns></returns>
        public override IChoice PerformTurnBasedAction()
        {
            State = StepState.TurnBasedAction;
            return ActivePlayer.UntapCardsInBattleZoneAndManaZone();
        }
    }
}
