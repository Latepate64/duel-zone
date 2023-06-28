using System.Collections.Generic;
using System.Linq;

namespace Engine.Steps
{
    /// <summary>
    /// 501.1 The active player determines which cards they control will untap. Then they untap them all simultaneously. This is a turn-based action. Normally, all of a player’s cards untap, but effects can keep one or more of a player’s cards from untapping.
    /// </summary>
    public class StartOfTurnPhase : Phase, ITurnBasedActionable
    {
        public StartOfTurnPhase(bool skipDrawStep) : base(PhaseOrStep.StartOfTurn)
        {
            SkipDrawStep = skipDrawStep;
        }

        public override IPhase GetNextPhase(IGame game)
        {
            // 500.6. The player who plays first skips the draw step of their first turn.
            if (SkipDrawStep)
            {
                return new ChargePhase();
            }
            else
            {
                return new DrawPhase();
            }
        }

        /// <summary>
        /// 501.1 The active player determines which cards they control will untap. Then they untap them all simultaneously. This is a turn-based action. Normally, all of a player’s cards untap, but effects can keep one or more of a player’s cards from untapping.
        /// </summary>
        public void PerformTurnBasedAction(IGame game)
        {
            IPlayer player = game.ActivePlayer;
            game.RemoveSummoningSicknesses(player);
            if (game.CanPlayerUntapTheCardsInTheirManaZoneAtTheStartOfEachOfTheirTurns(player))
            {
                player.Untap(game, player.ManaZone.Cards.ToArray());
            }
            if (game.DoCreaturesInTheBattleZoneUntapAtTheStartOfEachPlayersTurn())
            {
                UntapBattleZoneCreatures(game, player);
            }
        }

        private static void UntapBattleZoneCreatures(IGame game, IPlayer player)
        {
            IEnumerable<ICard> creaturesWithSilentSkill = game.GetBattleZoneCreaturesWithSilentSkill(player);

            // After your other creatures untap, if creature with Silent skill is tapped, you may keep it tapped instead and use its ​Silent Skill ability.
            player.Untap(game, game.GetBattleZoneCreatures(player).Except(creaturesWithSilentSkill).ToArray());
            IEnumerable<ICard> cardsThatStayTapped = player.ChooseWhichCreaturesToKeepTappedToUseTheirSilentSkillAbilities(creaturesWithSilentSkill);
            player.Untap(game, creaturesWithSilentSkill.Except(cardsThatStayTapped).ToArray());
            game.AddPendingSilentSkillAbilities(cardsThatStayTapped);
        }

        internal bool SkipDrawStep { get; set; }

        public StartOfTurnPhase(StartOfTurnPhase step) : base(step)
        {
            SkipDrawStep = step.SkipDrawStep;
        }

        public override IPhase Copy()
        {
            return new StartOfTurnPhase(this);
        }
    }
}
