﻿using DuelMastersModels.GameEvents;

namespace DuelMastersModels.Steps
{
    /// <summary>
    /// 501.1 The active player determines which cards they control will untap. Then they untap them all simultaneously. This is a turn-based action. Normally, all of a player’s cards untap, but effects can keep one or more of a player’s cards from untapping.
    /// </summary>
    public class StartOfTurnStep : TurnBasedActionStep
    {
        public StartOfTurnStep(bool skipDrawStep)
        {
            SkipDrawStep = skipDrawStep;
        }

        public override Step GetNextStep(Game game)
        {
            // 500.6. The player who plays first skips the draw step of their first turn.
            if (SkipDrawStep)
            {
                return new ChargeStep();
            }
            else
            {
                return new DrawStep();
            }
        }

        /// <summary>
        /// 501.1 The active player determines which cards they control will untap. Then they untap them all simultaneously. This is a turn-based action. Normally, all of a player’s cards untap, but effects can keep one or more of a player’s cards from untapping.
        /// </summary>
        /// <returns></returns>
        public override void PerformTurnBasedAction(Game game)
        {
            game.Process(new TurnStartsEvent(game.CurrentTurn));
            var player = game.GetPlayer(game.CurrentTurn.ActivePlayer);
            foreach (var creature in game.BattleZone.GetCreatures(game.CurrentTurn.ActivePlayer))
            {
                creature.SummoningSickness = false;
            }
            game.BattleZone.UntapCards(game.CurrentTurn.ActivePlayer);
            player.ManaZone.UntapCards();
        }

        internal bool SkipDrawStep { get; set; }

        public StartOfTurnStep(StartOfTurnStep step) : base(step)
        {
            SkipDrawStep = step.SkipDrawStep;
        }

        public override Step Copy()
        {
            return new StartOfTurnStep(this);
        }
    }
}
