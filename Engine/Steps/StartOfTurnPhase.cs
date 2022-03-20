﻿using Common.GameEvents;
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
            game.RemoveRevokedObjects(typeof(Durations.UntilStartOfYourNextTurn)); //TODO: Check that it is the correct player's turn.
            var player = game.CurrentTurn.ActivePlayer;
            var ownCreaturesWithSummoningSickness = game.BattleZone.GetCreatures(game.CurrentTurn.ActivePlayer.Id).Where(x => x.SummoningSickness).ToList();
            if (ownCreaturesWithSummoningSickness.Any())
            {
                foreach (var creature in ownCreaturesWithSummoningSickness)
                {
                    creature.SummoningSickness = false;
                }
                game.Process(new SummoningSicknessEvent { Cards = ownCreaturesWithSummoningSickness.Select(x => x.Convert()).ToList() });
            }
            player.Untap(game, game.BattleZone.GetCreatures(game.CurrentTurn.ActivePlayer.Id).Union(player.ManaZone.Cards).ToArray());
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
