using Engine.Abilities;
using Engine.ContinuousEffects;
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
        /// <returns></returns>
        public void PerformTurnBasedAction(IGame game)
        {
            IPlayer player = game.CurrentTurn.ActivePlayer;
            game.BattleZone.RemoveSummoningSicknesses(game.CurrentTurn.ActivePlayer);
            if (game.ContinuousEffects.CanPlayerUntapTheCardsInTheirManaZoneAtTheStartOfEachOfTheirTurns(player))
            {
                player.Untap(game, player.ManaZone.Cards.ToArray());
            }

            if (game.ContinuousEffects.DoCreaturesInTheBattleZoneUntapAtTheStartOfEachPlayersTurn())
            {
                IEnumerable<ICard> battleZoneCreatures = game.BattleZone.GetCreatures(game.CurrentTurn.ActivePlayer.Id);
                IEnumerable<ICard> creaturesWithSilentSkill = battleZoneCreatures.Where(x => x.GetAbilities<SilentSkillAbility>().Any());
                IEnumerable<ICard> creaturesWithoutSilentSkill = battleZoneCreatures.Except(creaturesWithSilentSkill);

                // After your other creatures untap, if creature with Silent skill is tapped, you may keep it tapped instead and use its ​Silent Skill ability.
                player.Untap(game, creaturesWithoutSilentSkill.ToArray());

                IEnumerable<ICard> keepTapped = player.ChooseAnyNumberOfCards(creaturesWithSilentSkill, "Choose which creatures you want to keep tapped to use their Silent skill abilities. Unchosen creatures will untap instead.");
                //var keepTapped = player.Choose(new Common.Choices.SilentSkillSelection(player.Id, creaturesWithoutSilentSkill), game).Decision.Select(x => game.GetCard(x));
                player.Untap(game, creaturesWithSilentSkill.Except(keepTapped).ToArray());
                game.AddPendingAbilities(keepTapped.SelectMany(x => x.GetAbilities<SilentSkillAbility>()).ToArray());
            }
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
